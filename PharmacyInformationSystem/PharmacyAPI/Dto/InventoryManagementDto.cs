using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.Dto
{
    public class InventoryManagementDto
    {
        public long PhamracyID { get; set; }
        public long MedicationID { get; set; }
        public long Quantity { get; set; }

        public InventoryManagementDto()
        {}

        public InventoryManagementDto(long phamracyID, long medicationID, long quantity)
        {
            PhamracyID = phamracyID;
            MedicationID = medicationID;
            Quantity = quantity;
        }
    }
}
