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
            SeedMedicationPromotion();
        }

        private void SeedMedicationPromotion()
        {
            Medication med1 = new Medication(4, "Synthroid", "J&J", MedicineApprovalStatus.Accepted, 150, "Taken once per day", "None.", "None.");
            Medication med2 = new Medication(5, "Ventolin", "Merck & Co. Inc.", MedicineApprovalStatus.Waiting, 200, "Taken twice per day", "None.", "Not advised for pregnant women.");
            Medication med3 = new Medication(6, "Januvia", "Pfizer Inc.", MedicineApprovalStatus.Accepted, 750, "Taken once once every 5 hours", "None.", "Not advised for children.");
            List<Medication> medications = new List<Medication>();
            medications.Add(med1);
            medications.Add(med2);
            medications.Add(med3);
            MedicationPromotion medicationPromotion = new MedicationPromotion(222, "First promotion", "Promotion description", new List<Medication>(), DateTime.Now, DateTime.Now.AddDays(40));
            medicationPromotion.PromotedMedications = medications;
            context.Add(medicationPromotion);
            context.SaveChanges();
        }
    }
}
