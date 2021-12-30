using PharmacyClassLib.Model;
using PharmacyClassLib.Repository.PharmacyOfferRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using PharmacyClassLib.Model.Relations;
using PharmacyClassLib.Service.Interface;

namespace PharmacyClassLib.Service
{
    public class PharmacyOfferComponentService:IPharmacyOfferComponentService
    {
        private IPharmacyOfferRepository pharmacyOfferRepository;
        private IPharmacyOfferComponentRepository pharmacyOfferComponentRepository;
        public void DeleteComponentFromOffer(long componentId, long offerId){
            PharmacyOffer pharmacyOffer = pharmacyOfferRepository.Get(offerId);
            pharmacyOffer.Components.ToList().RemoveAll((component) => component.Id == componentId);
            pharmacyOfferRepository.Update(pharmacyOffer);
        }

        public List<PharmacyOfferComponent> GetComponentFromOffer(long offerId)
        {
            return pharmacyOfferRepository.Get(offerId).Components.ToList();
        }

    }
}
