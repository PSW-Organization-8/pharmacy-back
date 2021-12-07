using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyClassLib.Model
{
    public class OfferComponent
    {
        public Medication Medication { get; set; }
        public long Quantity { get; set; }

        public OfferComponent(Medication medication, long quantity)
        {
            Medication = medication;
            Quantity = quantity;
        }

    }
}
