using Microsoft.AspNetCore.Mvc;
using PharmacyAPI.Dto;
using PharmacyAPI.Mapper;
using PharmacyClassLib.Model;
using PharmacyClassLib.Service;
using PharmacyClassLib.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PharmacyOfferController
    {
        private readonly IPharmacyOfferService pharmacyOfferService;
        private readonly IPharmacyService pharmacyService;

        public PharmacyOfferController(IPharmacyOfferService pharmacyOfferService, IPharmacyService pharmacyService)
        {
            this.pharmacyOfferService = pharmacyOfferService;
            this.pharmacyService = pharmacyService;
        }

        [HttpGet]
        public List<PharmacyOfferViewDTO> GetAll()
        {
            List<PharmacyOfferViewDTO> retval = new List<PharmacyOfferViewDTO>();
            foreach (PharmacyOffer offer in pharmacyOfferService.GetAll())
                retval.Add(OfferToDtoView(offer));
            return retval;
        }


        [HttpGet("{id?}")]
        public PharmacyOfferViewDTO Get(long id)
        {
            return OfferToDtoView(pharmacyOfferService.Get(id));
        }

        [HttpGet("offer/{offerId?}")]
        public List<PharmacyOfferViewDTO> GetByOffer(long offerId)
        {
            List<PharmacyOfferViewDTO> retval = new List<PharmacyOfferViewDTO>();
            foreach (PharmacyOffer offer in pharmacyOfferService.GetByHospitalOffer(offerId))
                retval.Add(OfferToDtoView(offer));
            return retval;
        }

        [HttpGet("pharmacy/{pharmacyId?}")]
        public List<PharmacyOfferViewDTO> GetByPharmacy(long pharmacyId)
        {
            List<PharmacyOfferViewDTO> retval = new List<PharmacyOfferViewDTO>();
            foreach (PharmacyOffer offer in pharmacyOfferService.GetByPharmacy(pharmacyId))
                retval.Add(OfferToDtoView(offer));
            return retval;
        }

        [HttpPost]
        public PharmacyOffer Create([FromBody] PharmacyOfferDTO dto)
        {
            return pharmacyOfferService.Create(PharmacyOfferMapper.PharmacyDTOToOffer(dto));
        }

        [HttpDelete("{id?}")]
        public void Delete(long id)
        {
            pharmacyOfferService.Delete(id);
        }

        [HttpPut("{id?}")]
        public bool MarkAsChosen(long id)
        {
            return pharmacyOfferService.MarkAsChosen(id);
        }


        private PharmacyOfferViewDTO OfferToDtoView(PharmacyOffer offer)
        {
            if (offer == null)
                return null;

            Pharmacy pharmacy = pharmacyService.Get(offer.PharmacyId);
            if (pharmacy != null)
            {
                return new PharmacyOfferViewDTO(offer.Id, offer.OfferIdentification, pharmacy.Name, offer.Price, offer.IsChosen, offer.HospitalName,
                    offer.TimePosted, pharmacyOfferService.GetComponentsView(offer.Id));

            }

            return null;
        }

    }
}
