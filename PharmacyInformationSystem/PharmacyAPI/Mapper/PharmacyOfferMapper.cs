﻿using PharmacyAPI.Dto;
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
            PharmacyOffer offer = new PharmacyOffer { Id = dto.Id, PharmacyId= dto.PharmacyId, TenderId = dto.TenderId, TimePosted= DateTime.Now };
            return offer; 
        }

    }
}
