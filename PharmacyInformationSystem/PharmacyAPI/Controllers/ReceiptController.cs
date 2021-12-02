using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptController : ControllerBase
    {
        public ReceiptController() { }

        [HttpGet]
        public IActionResult SaveReceipt(string patientName)
        {
            string filePath = Directory.GetCurrentDirectory();
            string[] name = patientName.Split(" ");
            string fileName = "Receipt" + name[0] + name[1] + ".pdf";
            string localFile = Path.Combine(filePath, fileName);
            string fileServer = @"\public\"+fileName;

            using (SftpClient client = new SftpClient(new PasswordConnectionInfo("192.168.56.1", "tester", "password")))
            {
                client.Connect();
                using (Stream stream = System.IO.File.OpenWrite(localFile))
                {
                    client.DownloadFile(fileServer, stream, null);
                }
                client.Disconnect();
            }
            return Ok();

        }
    }
}
