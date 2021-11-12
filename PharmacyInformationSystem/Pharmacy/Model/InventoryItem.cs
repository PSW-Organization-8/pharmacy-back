using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyClassLib.Model
{
    public class InventoryItem
    {
        public Medication Medication { get; set; }
        public long Quantity { get; set; }

        public InventoryItem(Medication medication, long quantity)
        {
            Medication = medication;
            Quantity = quantity;
        }
    }
}
