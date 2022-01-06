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
    class MedicationPromotionService : IMedicationPromotionService
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
            return this.medicationPromotionRepository.GetAll();
        }
    }
}
