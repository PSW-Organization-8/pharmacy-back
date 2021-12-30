using PharmacyClassLib.Model.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.Dto
{
    public class PharmacyOfferDTO
    {
        public long Id { get; set; }
        public long TenderId { get; set; }
        public long PharmacyId { get; set; }
        public List<OfferComponentDto> Components { get; set; }

        public PharmacyOfferDTO()
        {

        }

        public PharmacyOfferDTO(long id, long tenderId, long pharmacyId, List<OfferComponentDto> components)
        {
            Id = id;
            PharmacyId = pharmacyId;
            TenderId = tenderId;
            Components = components;
        }

    }
}
