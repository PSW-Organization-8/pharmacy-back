using PharmacyClassLib.Model.Commercials;
using PharmacyClassLib.Repository.MedicationPromotionRepository;
using PharmacyClassLib.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyClassLib.Service
{
    public class MedicationPromotionService : IMedicationPromotionService
    {
        private readonly IMedicationPromotionRepository medicationPromotionRepository;


        public MedicationPromotionService (IMedicationPromotionRepository medicationPromotionRepository){
            this.medicationPromotionRepository=medicationPromotionRepository;
        }

        public long AddMedicationPromotion(MedicationPromotion medicationPromotion)
        {
            //todo uraditi citanje lijekova iz baze ukoliko dobijemo samo id sa frontenda
            return this.medicationPromotionRepository.Create(medicationPromotion).Id;
        }

        public bool DeletePromotion(long id)
        {
            return this.medicationPromotionRepository.Delete(id);
        }

        public List<MedicationPromotion> Get()
        {
            List<MedicationPromotion> promotions = new List<MedicationPromotion>();

            MedicationPromotion p1 = new MedicationPromotion();
            p1.Title = "BENU PHARMACY";
            p1.Description = "Diazepam 1.5$ JUST TODAY";

            MedicationPromotion p2 = new MedicationPromotion();
            p2.Title = "GALEN PHARMACY";
            p2.Description = "Candesartan 1.5$ JUST TODAY";

            MedicationPromotion p3 = new MedicationPromotion();
            p3.Title = "FREDI PHARMACY";
            p3.Description = "Nitrofurantoin 8$ JUST TODAY";

            MedicationPromotion p4 = new MedicationPromotion();
            p4.Title = "GALENIUS PHARMACY";
            p4.Description = "Azithromycin 1$ JUST TODAY";

            MedicationPromotion p5 = new MedicationPromotion();
            p5.Title = "GODWILL PHARMACY";
            p5.Description = "Paracetamol for adults 2.5$ JUST TODAY";

            MedicationPromotion p6 = new MedicationPromotion();
            p6.Title = "DR. MAX PHARMACY";
            p6.Description = "Lansoprazole 8$ JUST TODAY";

            promotions.Add(p1);
            promotions.Add(p2);
            promotions.Add(p3);
            promotions.Add(p4);
            promotions.Add(p5);
            promotions.Add(p6);

            //return medicationPromotionRepository.GetAll();
            return promotions;
        }
    }
}
