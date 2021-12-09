﻿using PharmacyClassLib.Model;
using PharmacyClassLib.Repository;
using PharmacyClassLib.Repository.MedicationIngredientRepository;
using PharmacyClassLib.Service;
using Renci.SshNet;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace PharmacyClassLib.Service
{
    public class MedicationService : IMedicationService
    {
        private readonly IMedicationRepository medicationRepository;
        private readonly IMedicationIngredientService ingredientService;
        private readonly IIngredientInMedicationService ingredientInMedicationService;

        public MedicationService(IMedicationRepository medicationRepository, IMedicationIngredientService ingredientService, IIngredientInMedicationService ingredientInMedicationService)
        {
            this.medicationRepository = medicationRepository;
            this.ingredientService = ingredientService;
            this.ingredientInMedicationService = ingredientInMedicationService;
        }

        public Medication Create(Medication newMedication)
        {
            return medicationRepository.Create(newMedication);
        }

        public bool Delete(long id)
        {
            bool success = false;
            if (Get(id) != null)
            {
                success = true;
                ingredientInMedicationService.RemoveMedicineReferences(id);
                medicationRepository.Delete(id);
            }
            return success;
        }

        public Medication Get(long id)
        {
            Medication medication = medicationRepository.Get(id);
            if (medication != null)
            {
                medication.MedicationIngredients = ingredientInMedicationService.GetIngredientByMedication(medication.Id);
            }
            return medication;
        }
        public Medication GetMedication(string name)
        {
            List<Medication> medications = medicationRepository.GetAll();
            foreach (Medication medication in medicationRepository.GetAll())
            {
                if (medication.Name.Equals(name)) return medication;
                
            }
            return null;
        }

        public List<Medication> GetAll()
        {
            List<Medication> medications = new List<Medication>();
            foreach (Medication medication in medicationRepository.GetAll())
            {
                medication.MedicationIngredients = ingredientInMedicationService.GetIngredientByMedication(medication.Id);
                medications.Add(medication);
            }
            return medications;
        }

        public List<Medication> Search(string text, List<string> ingredients)
        {
            List<Medication> medications = new List<Medication>();
            List<Medication> nameFilter = GetAll().Where(medication => medication.Name.ToUpper().Contains(text.ToUpper())).ToList();

            foreach (Medication medication in nameFilter)
            {
                bool add = false;

                foreach (string ingredient in ingredients)
                {
                    List<MedicationIngredient> matchingIngredients = medication.MedicationIngredients.Where(medIngredient => medIngredient.Name.ToUpper().Contains(ingredient.ToUpper())).ToList();
                    if (matchingIngredients.Count() > 0)
                    {
                        add = true;
                        break;
                    }              
                }

                if (add || ingredients.Count == 0)
                {
                    medications.Add(medication);
                }
            }

            return medications;
        }

        public bool Update(Medication medication)
        {
            bool success = false;
            if (Get(medication.Id) != null)
            {
                success = true;
                medicationRepository.Update(medication);
            }
            return success;
        }
        public bool isExistMedication(string name)
        {
            List<Medication> medications = medicationRepository.GetAll();
            foreach (Medication medication in medications)
            {
                if (medication.Name.Equals(name)) return true;
            }
            return false;
        }
        public void GenerateReport(string medicationName)
        {
            String filePath = Directory.GetCurrentDirectory();
            String fileName = "MedicationSpecification_" + medicationName + ".pdf";
            PdfDocument doc = new PdfDocument();
            PdfPageBase page = doc.Pages.Add();
            page.Canvas.DrawString(WriteContent(medicationName), new PdfFont(PdfFontFamily.Helvetica, 11f), new PdfSolidBrush(Color.Black), 10, 10);
            if (System.IO.File.Exists(Path.Combine(filePath, fileName)))
            {
                System.IO.File.Delete(Path.Combine(filePath, fileName));
            }
            StreamWriter File = new StreamWriter(Path.Combine(filePath, fileName), true);
            
            doc.SaveToStream(File.BaseStream);
            // File.Write(WriteContent(duration));

            File.Close();
            doc.Close();

            SendReport(Path.Combine(filePath, fileName));

        }
        private string WriteContent(String medicationName)
        {
            Medication medication = GetMedication(medicationName);
            string content = " \n\n Medication name:" + medicationName + " .\n";
            content += " Manufacturer:" + medication.Manufacturer + " .\n";
            content += " Usage:" + medication.Usage + " .\n";
            content += " Precautions:" + medication.Precautions + " .\n";
            content += " PotentialDangers:" + medication.PotentialDangers + " .\n";

            return content;
        }

        private void SendReport(String filePath)
        {
            using (SftpClient client = new SftpClient(new PasswordConnectionInfo("192.168.56.1", "tester", "password")))
            {
                client.Connect();

                using (Stream stream = File.OpenRead(filePath))
                {
                    client.UploadFile(stream, @"\public\" + Path.GetFileName(filePath), null);
                }
                client.Disconnect();
            }
        }

    }
}
