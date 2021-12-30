using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.Dto
{
    public class OfferComponentDto
    {
        public long MedicationId { get; set; }
        public Double Price { get; set; }
        public int Quantity { get; set; }
    }
}
