using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyClassLib.Model
{
    public class MedicationDistribution
    {
        public Pharmacy Pharmacy { get; set; }
        public long Quantity { get; set; }

        public MedicationDistribution(Pharmacy pharmacy, long quantity)
        {
            Pharmacy = pharmacy;
            Quantity = quantity;
        }
    }
}
