using PharmacyClassLib.Model;
using PharmacyClassLib.Model.Relations;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyClassLib.Service.Interface
{
    public interface IPharmacyOfferService
    {
        List<PharmacyOffer> GetAll();

        List<PharmacyOffer> GetByHospitalOffer(long offerIdentification);

        List<PharmacyOffer> GetByPharmacy(long pharmacyId);

        PharmacyOffer Get(long id);

        PharmacyOffer Create(PharmacyOffer newOffer);

        Boolean Delete(long id);

        List<PharmacyOfferComponent> GetComponents(long offerId);

        Boolean DeleteComponent(long id);

        PharmacyOfferComponent CreateComponent(PharmacyOfferComponent newComponent);

        List<OfferComponent> GetComponentsView(long offerId);

        Boolean MarkAsChosen(long id);

    }
}
