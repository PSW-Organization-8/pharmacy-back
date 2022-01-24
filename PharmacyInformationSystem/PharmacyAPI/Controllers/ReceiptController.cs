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
        public IActionResult SaveReceipt(string fileName)
        {
            string filePath = Directory.GetCurrentDirectory();
            filePath = Path.Combine(filePath, @"..\DataFiles\Prescriptions");
            string localFile = Path.Combine(filePath, fileName);
            string fileServer = @"\public\"+fileName;
            try
            {
                using (SftpClient client = new SftpClient(new PasswordConnectionInfo("192.168.56.1", "tester", "password")))
                {
                    client.Connect();
                    using (Stream stream = System.IO.File.OpenWrite(localFile))
                    {
                        client.DownloadFile(fileServer, stream, null);
                    }
                    client.Disconnect();
                }
            }
            catch(Exception) {
                return BadRequest("Error! Receipt not sent to pharmacy!");
            }
            return Ok();

        }

        [HttpPost]
        public IActionResult SaveQRReceipt([FromBody] string file)
        {
            try
            {
                string filePath = Directory.GetCurrentDirectory();
                filePath = Path.Combine(filePath, @"..\DataFiles\Prescriptions");
                IEnumerable<string> headers = Request.Headers["fileName"];
                var fileName = headers.FirstOrDefault();
                string localFile = Path.Combine(filePath, fileName);
                Byte[] bytes = Convert.FromBase64String(file);
                System.IO.File.WriteAllBytes(localFile, bytes);
                return Ok();
            }
            catch(Exception) {
                return BadRequest();
            }
        }
    }
}
