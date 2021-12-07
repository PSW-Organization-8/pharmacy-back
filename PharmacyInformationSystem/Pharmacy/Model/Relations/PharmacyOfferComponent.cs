using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PharmacyClassLib.Model.Relations
{
    public class PharmacyOfferComponent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long OfferID { get; set; }
        public long MedicationID { get; set; }
        public long Quantity { get; set; }

        public PharmacyOfferComponent() { }

        public PharmacyOfferComponent(long id, long offerID, long medicationID, long quantity)
        {
            Id = id;
            OfferID = offerID;
            MedicationID = medicationID;
            Quantity = quantity;
        }
    }
}
