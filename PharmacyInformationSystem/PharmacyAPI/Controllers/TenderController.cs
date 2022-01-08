using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyAPI.Dto;
using PharmacyClassLib.Model;
using PharmacyClassLib.Model.Relations;
using PharmacyClassLib.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenderController : ControllerBase
    {
        private readonly ITenderingService tenderingService;
        private readonly IPharmacyOfferService pharmacyOfferService;
        private readonly IInventoryLogService inventoryLogService;
        public TenderController(ITenderingService tenderingService, IPharmacyOfferService pharmacyOfferService, IInventoryLogService inventoryLogService)
        {
            this.tenderingService = tenderingService;
            this.pharmacyOfferService = pharmacyOfferService;
            this.inventoryLogService = inventoryLogService;
           
        }

        [HttpGet]
        public List<Tender> GetAllTenders()
        {
            return tenderingService.GetAllWithMedication();
        }
        [HttpPost]
        [Route("receiveTenderOutcome")]
        public bool ReceiveNotificationAboutTenderOutcome(TenderOutcomeDTO tenderOutcome)
        {
            // prima id ponude iz apoteke i bool da li je pobedila ili nije
            // ocekivana vracena vrednost ukoliko je pobednik: true ako postoji ponudjeni broj lekova, false ako ne postoji ponudjeni broj lekova
            if (tenderOutcome.Winner == false)
            {
                return false;
            }

            // ako je pobednik
            
            return pharmacyOfferService.ExecuteExchange(tenderOutcome.OfferIdInPharmacy);
        }
    }
}
