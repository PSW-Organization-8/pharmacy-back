using PharmacyClassLib.Model;
using PharmacyClassLib.Model.Commercials;
using PharmacyClassLib.Model.Enums;
using PharmacyClassLib.Model.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyClassLib.ModelConfiguration
{
    public class PharmacySeeder

    {
        private MyDbContext context;
        public PharmacySeeder(MyDbContext context)
        {
            this.context = context;
        }

        public void SeedData()
        {
            SeedNews();
            SeedMedicationPromotion();
            SeedMedication();
            //SeedIngradients();
            //SeedIngradientsInMedications();
        }

        private void SeedNews()
        {
            News news = new News(1, "Nova vijest", "neki tekst", DateTime.Now, DateTime.Now.AddDays(5));
            context.Add(news);
            context.SaveChanges();
        }

        private void SeedMedication()
        {
            Medication med1=new Medication(1, "Synthroid", "J&J", MedicineApprovalStatus.Accepted, 150, "Taken once per day", "None.", "None.");
            Medication med2=new Medication(2, "Ventolin", "Merck & Co. Inc.", MedicineApprovalStatus.Waiting, 200, "Taken twice per day", "None.", "Not advised for pregnant women.");
            Medication med3=new Medication(3, "Januvia", "Pfizer Inc.", MedicineApprovalStatus.Accepted, 750, "Taken once once every 5 hours", "None.", "Not advised for children.");
            context.Add(med1);
            context.Add(med2);
            context.Add(med3);
            context.SaveChanges();
        }

        private void SeedIngradients()
        {
            MedicationIngredient ingredient1 = new MedicationIngredient(1, "Vitamin C");
            MedicationIngredient ingredient2 = new MedicationIngredient(2, "Phosphorus");
            MedicationIngredient ingredient3 = new MedicationIngredient(3, "Calcium");
            context.Add(ingredient1);
            context.Add(ingredient2);
            context.Add(ingredient3);
            context.SaveChanges();

            
        }

        private void SeedIngradientsInMedications()
        {
            context.Add(new IngredientInMedication(1, 1, 1));
            context.Add(new IngredientInMedication(2, 2, 2));
            context.Add(new IngredientInMedication(3, 1, 2));
            context.SaveChanges();
        }

        private void SeedMedicationPromotion()
        {
            Medication med1 = new Medication(1, "Synthroid", "J&J", MedicineApprovalStatus.Accepted, 150, "Taken once per day", "None.", "None.");
            Medication med2 = new Medication(2, "Ventolin", "Merck & Co. Inc.", MedicineApprovalStatus.Waiting, 200, "Taken twice per day", "None.", "Not advised for pregnant women.");
            Medication med3 = new Medication(3, "Januvia", "Pfizer Inc.", MedicineApprovalStatus.Accepted, 750, "Taken once once every 5 hours", "None.", "Not advised for children.");
            List<Medication> medications = new List<Medication>();
            medications.Add(med1);
            medications.Add(med2);
            medications.Add(med3);
            MedicationPromotion medicationPromotion = new MedicationPromotion(1, "First promotion", "Promotion description", new List<Medication>(), DateTime.Now, DateTime.Now.AddDays(40));
            medicationPromotion.PromotedMedications = medications;
            context.Add(medicationPromotion);
            context.SaveChanges();
        }
    }
}
