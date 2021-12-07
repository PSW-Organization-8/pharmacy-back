using PharmacyClassLib.Model.Relations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PharmacyClassLib.Model
{
    public class PharmacyOffer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long PharmacyId { get; set; }
        public long OfferIdentification { get; set; }
        public double Price { get; set; }
        public Boolean IsChosen { get; set; }
        public string HospitalName { get; set; }
        public DateTime TimePosted { get; set; }
        public List<PharmacyOfferComponent> Components { get; set; }

        public PharmacyOffer(long id, long pharmacyId, long offerIdentification, double price, bool isChosen, string hospitalName, DateTime timePosted)
        {
            Id = id;
            PharmacyId = pharmacyId;
            OfferIdentification = offerIdentification;
            Price = price;
            IsChosen = isChosen;
            HospitalName = hospitalName;
            TimePosted = timePosted;
            Components = new List<PharmacyOfferComponent>();
        }
    }
}
