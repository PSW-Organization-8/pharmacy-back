using Microsoft.AspNetCore.Mvc;
using PharmacyAPI.Dto;
using PharmacyClassLib.Service;
using System;
using System.Collections.Generic;
using System.IO;
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
        public IActionResult SaveConsumptionReport()
        {
            
            //NotificationDTO notificationDTO = new NotificationDTO(medicationConsumptionService.SaveReport());
            //string neki = medicationConsumptionService.SaveReport();
            /* byte[] buff = null;
             string nesto = medicationConsumptionService.SaveReport();
             // Initialize FileStream object
             FileStream fs = new FileStream(nesto, FileMode.Open, FileAccess.Read);
             BinaryReader br = new BinaryReader(fs);
             long numBytes = new FileInfo(nesto).Length;

             // Load the file contents in the byte array
             buff = br.ReadBytes((int)numBytes);
             fs.Close();*/
            var fileStream = new FileStream(medicationConsumptionService.SaveReport(),
                                     FileMode.Open,
                                     FileAccess.Read
                                   );
            var fsResult = new FileStreamResult(fileStream, "application/pdf");
            return fsResult;
        }
    }
}
