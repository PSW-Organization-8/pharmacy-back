using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyClassLib.Model;
using PharmacyClassLib.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PharmacyAPI.Dto;

namespace PharmacyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenderController : ControllerBase
    {
        private readonly ITenderingService tenderingService;
        public TenderController(ITenderingService tenderingService)
        {
            this.tenderingService = tenderingService;
           
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
            // ukoliko nije pobednik nije bitno sta ce se vratiti
            if (tenderOutcome.Winner == false)
            {
                return false;
            }

            // ako je pobednik
            return true;
        }
    }
}
