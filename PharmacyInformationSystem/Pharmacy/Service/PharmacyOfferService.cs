using PharmacyClassLib.Model;
using PharmacyClassLib.Model.Relations;
using PharmacyClassLib.Repository.PharmacyOfferRepository;
using PharmacyClassLib.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyClassLib.Service
{
    public class PharmacyOfferService : IPharmacyOfferService
    {
        private readonly IPharmacyOfferRepository pharmacyOfferRepository;
        private readonly IPharmacyOfferComponentRepository pharmacyOfferComponentRepository;
        private readonly IMedicationService medicationService;
        private readonly IPharmacyService pharmacyService;
        private readonly IHospitalRegistrationService hospitalService;
        private readonly IInventoryLogService inventoryLogService;

        public PharmacyOfferService(IPharmacyOfferRepository pharmacyOfferRepository, 
            IPharmacyOfferComponentRepository pharmacyOfferComponentRepository, 
            IMedicationService medicationService, 
            IPharmacyService pharmacyService, 
            IHospitalRegistrationService hospitalService,
            IInventoryLogService inventoryLogService)
        {
            this.pharmacyOfferRepository = pharmacyOfferRepository;
            this.pharmacyOfferComponentRepository = pharmacyOfferComponentRepository;
            this.medicationService = medicationService;
            this.pharmacyService = pharmacyService;
            this.hospitalService = hospitalService;
            this.inventoryLogService = inventoryLogService;
        }

        public PharmacyOffer Create(PharmacyOffer newOffer)
        {
            PharmacyOffer retVal = null;
            
            if (pharmacyService.Get(newOffer.PharmacyId) != null && hospitalService.Get(newOffer.HospitalName) != null)
            {
                retVal = pharmacyOfferRepository.Create(newOffer);
                foreach (PharmacyOfferComponent component in newOffer.Components)
                {
                    PharmacyOfferComponent newComponent = new PharmacyOfferComponent(0, retVal.Id, component.MedicationID, component.Quantity);
                    CreateComponent(newComponent);
                }
            }

            return retVal;
        }

        public PharmacyOfferComponent CreateComponent(PharmacyOfferComponent newComponent)
        {
            return pharmacyOfferComponentRepository.Create(newComponent);
        }

        public bool Delete(long id)
        {
            foreach (PharmacyOfferComponent component in GetComponents(id))            
                DeleteComponent(component.Id);
            
            return pharmacyOfferRepository.Delete(id);
        }

        public bool DeleteComponent(long id)
        {
            return pharmacyOfferComponentRepository.Delete(id);
        }

        public PharmacyOffer Get(long id)
        {
            PharmacyOffer offer = pharmacyOfferRepository.Get(id);
            if (offer != null)
            {
                offer.Components = GetComponents(id);
            }

            return offer;
        }

        public List<PharmacyOffer> GetAll()
        {
            return pharmacyOfferRepository.GetAll();
        }

        public List<PharmacyOffer> GetByHospitalOffer(long offerIdentification)
        {
            List<PharmacyOffer> offers = new List<PharmacyOffer>();

            foreach (PharmacyOffer offer in GetAll())
            {
                if (offer.OfferIdentification == offerIdentification)
                    offers.Add(Get(offer.Id));                
            }

            return offers;
        }

        public List<PharmacyOffer> GetByPharmacy(long pharmacyId)
        {
            List<PharmacyOffer> offers = new List<PharmacyOffer>();

            foreach (PharmacyOffer offer in GetAll())
            {
                if (offer.PharmacyId == pharmacyId)
                    offers.Add(Get(offer.Id));
            }

            return offers;
        }

        public List<PharmacyOfferComponent> GetComponents(long offerId)
        {
            List<PharmacyOfferComponent> components = new List<PharmacyOfferComponent>();
            foreach (PharmacyOfferComponent component in pharmacyOfferComponentRepository.GetAll())
            {
                if (component.OfferID == offerId)
                    components.Add(component);
            }
            return components;
        }

        public List<OfferComponent> GetComponentsView(long offerId)
        {
            List<OfferComponent> components = new List<OfferComponent>();
            foreach (PharmacyOfferComponent component in GetComponents(offerId))
            {
                Medication medication = medicationService.Get(component.MedicationID);
                if (medication != null)
                {
                    OfferComponent componentView = new OfferComponent(medication, component.Quantity);
                    components.Add(componentView);
                }
            }
            return components;
        }

        public bool MarkAsChosen(long id)
        {
            PharmacyOffer offer = Get(id);
            bool retVal = false;

            if (offer != null && !offer.IsChosen)            
            {
                retVal = true;
                foreach (PharmacyOfferComponent component in offer.Components)
                {
                    if (!inventoryLogService.CheckIfLogExistsInPharmacy(offer.PharmacyId, component.MedicationID, component.Quantity))
                    {
                        retVal = false;
                        break;
                    }
                }

                if (retVal)
                {
                    offer.IsChosen = true;
                    pharmacyOfferRepository.Update(offer);

                    foreach (PharmacyOfferComponent component in offer.Components)
                    {
                        inventoryLogService.RemoveMedication(offer.PharmacyId, component.MedicationID, component.Quantity);                        
                    }
                }
            }

            return retVal;
        }

    }
}
