using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.Dto
{
    public class TenderOutcomeDTO
    {
        public long OfferIdInPharmacy { get; set; }
        public bool Winner { get; set; }

        public TenderOutcomeDTO() { }

        public TenderOutcomeDTO(long offerIdInPharmacy, bool winner)
        {
            OfferIdInPharmacy = offerIdInPharmacy;
            Winner = winner;
        }
    }
}
