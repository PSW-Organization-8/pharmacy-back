using PharmacyClassLib.Model;
using PharmacyClassLib.Model.Relations;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyClassLib.Service.Interface
{
    public interface IPharmacyOfferService
    {
        PharmacyOffer Create(PharmacyOffer offer);
        //PharmacyOffer CreateOffer(List<PharmacyOfferComponent> pharmacyOfferComponents);

        bool Delete(long id);

    }
}
