using PharmacyAPI.Dto;
using PharmacyClassLib.Model.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.Mapper
{
    public class OfferComponentMapper
    {
        public static PharmacyOfferComponent OfferComponentDtoToOfferComponent(OfferComponentDto dto)
        {
            return new PharmacyOfferComponent(dto.MedicationId, dto.Quantity, dto.Price);
        }
    }
}
