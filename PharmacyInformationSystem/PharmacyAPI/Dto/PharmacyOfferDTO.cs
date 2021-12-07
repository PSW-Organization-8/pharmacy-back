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
        public long OfferIdentification { get; set; }
        public long PharmacyId { get; set; }
        public double Price { get; set; }
        public Boolean IsChosen { get; set; }
        public string HospitalName { get; set; }
        public DateTime TimePosted { get; set; }
        public List<PharmacyOfferComponent> Components { get; set; }

        public PharmacyOfferDTO()
        {

        }

        public PharmacyOfferDTO(long id, long offerIdentification, long pharmacyId, double price, bool isChosen, string hospitalName, DateTime timePosted, List<PharmacyOfferComponent> components)
        {
            Id = id;
            OfferIdentification = offerIdentification;
            PharmacyId = pharmacyId;
            Price = price;
            IsChosen = isChosen;
            HospitalName = hospitalName;
            TimePosted = timePosted;
            Components = components;
        }

    }
}
