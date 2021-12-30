using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyClassLib.Model;
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
        public TenderController(ITenderingService tenderingService)
        {
            this.tenderingService = tenderingService;
           
        }

        [HttpGet]
        public List<Tender> GetAllTenders()
        {
            return tenderingService.GetAllWithMedication();
        }
    }
}
