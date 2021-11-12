using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PharmacyClassLib.Model.Relations
{
    public class InventoryLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long PharmacyID { get; set; }
        public long MedicationID { get; set; }
        public long Quantity { get; set; }

        public InventoryLog(long id, long pharmacyID, long medicationID, long quantity)
        {
            Id = id;
            PharmacyID = pharmacyID;
            MedicationID = medicationID;
            Quantity = quantity;
        }
    }
}
