using PharmacyClassLib.Model;
using PharmacyClassLib.Repository;
using PharmacyClassLib.Repository.MedicationIngredientRepository;
using PharmacyClassLib.Service;
using System;
using System.Collections.Generic;
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
            foreach (Medication medication in GetAll())
            {
                if (medication.Name.ToUpper().Contains(text.ToUpper()))
                {
                    bool add = false;

                    foreach (string ingredient in ingredients)
                    {
                        foreach(MedicationIngredient medIngredient in medication.MedicationIngredients)
                        {
                            if (medIngredient.Name.ToUpper().Contains(ingredient.ToUpper()))
                            {
                                add = true;
                                break;
                            }
                        }
                    }

                    if (add || ingredients.Count == 0)
                    {
                        medications.Add(medication);
                    }
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

    }
}
