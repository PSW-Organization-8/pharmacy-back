using PharmacyAPI.Dto;
using PharmacyClassLib.Model;
using PharmacyClassLib.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.Mapper
{
    public class PharmacyOfferMapper
    {
        public static PharmacyOffer PharmacyDTOToOffer(PharmacyOfferDTO dto)
        {
            PharmacyOffer offer = new PharmacyOffer(dto.Id, dto.PharmacyId, dto.OfferIdentification, dto.Price, dto.IsChosen, dto.HospitalName, DateTime.Now);
            offer.Components = dto.Components;
            return offer;
        }

    }
}
