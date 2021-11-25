using Microsoft.AspNetCore.Mvc;
using PharmacyClassLib.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MedicationConsumptionController : ControllerBase
    {

        private readonly MedicationConsumptionService medicationConsumptionService = new MedicationConsumptionService();

        [HttpGet]
        public void SaveConsumptionReport()
        {
            medicationConsumptionService.SaveReport();
          
        }


    }
}
