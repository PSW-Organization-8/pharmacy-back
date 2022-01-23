using PharmacyClassLib.Model;
using PharmacyClassLib.Model.Relations;
using PharmacyClassLib.Repository;
using PharmacyClassLib.Repository.PharmacyOfferRepository;
using PharmacyClassLib.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PharmacyClassLib.Service
{
    public class PharmacyOfferService : IPharmacyOfferService
    {
        private readonly IPharmacyOfferRepository pharmacyOfferRepository;
        private readonly IMedicationRepository medicationRepository;
        private readonly TenderCommunicationRabbitMQ tenderCommunicationRabbitMq;
        private readonly IInventoryLogService inventoryLogService;

        public PharmacyOfferService(IPharmacyOfferRepository pharmacyOfferRepository, IMedicationRepository medicationRepository, TenderCommunicationRabbitMQ tenderCommunicationRabbitMq, IInventoryLogService inventoryLogService)
        {
            this.pharmacyOfferRepository = pharmacyOfferRepository;
            this.medicationRepository = medicationRepository;
            this.tenderCommunicationRabbitMq = tenderCommunicationRabbitMq;
            this.inventoryLogService = inventoryLogService;
        }

        public PharmacyOffer Create(PharmacyOffer offer) {
            PharmacyOffer pharmacyOffer = this.pharmacyOfferRepository.Create(offer);
            pharmacyOffer.Components.ToList().ForEach(component => component.MedicationName = medicationRepository.Get(component.MedicationId).Name);
            tenderCommunicationRabbitMq.SendTenderOfferToAppropriateHospital(pharmacyOffer);
            return pharmacyOffer;
        }

        /*
        public PharmacyOffer CreateOffer(List<PharmacyOfferComponent> pharmacyOfferComponents)
        {
            pharmacyOfferComponents.ForEach(component => component.MedicationId = medicationRepository.Get(component.Id));
            PharmacyOffer pharmacyOffer = new PharmacyOffer(pharmacyOfferComponents);
            return pharmacyOffer;
        }
        */

        public bool Delete(long id)
        {
            return pharmacyOfferRepository.Delete(id);
        }

        public bool ExecuteExchange(long offerId)
        {
            PharmacyOffer pharmacyOffer = GetOffer(offerId);
            foreach (PharmacyOfferComponent offerComponent in pharmacyOffer.Components)
            {
                if (!inventoryLogService.RemoveMedication(pharmacyOffer.PharmacyId, offerComponent.MedicationId, offerComponent.Quantity))
                {
                    return false;
                }
            }
            return true;
        }

        public PharmacyOffer GetOffer(long id)
        {
            return pharmacyOfferRepository.GetOfferWithComponents(id);
        }
    }
}
