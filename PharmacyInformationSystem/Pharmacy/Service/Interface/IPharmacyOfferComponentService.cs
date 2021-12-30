using PharmacyClassLib.Model.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyClassLib.Service.Interface
{
    public interface IPharmacyOfferComponentService
    {
        void DeleteComponentFromOffer(long componentId, long offerId);

        List<PharmacyOfferComponent> GetComponentFromOffer(long offerId);
    }
}
