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

        public PharmacyOfferService(IPharmacyOfferRepository pharmacyOfferRepository, IMedicationRepository medicationRepository, TenderCommunicationRabbitMQ tenderCommunicationRabbitMq)
        {
            this.pharmacyOfferRepository = pharmacyOfferRepository;
            this.medicationRepository = medicationRepository;
            this.tenderCommunicationRabbitMq = tenderCommunicationRabbitMq;
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

    }
}
