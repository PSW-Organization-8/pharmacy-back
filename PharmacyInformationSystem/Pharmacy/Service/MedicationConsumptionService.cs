using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PharmacyClassLib.Service
{
    public class MedicationConsumptionService
    {
        public MedicationConsumptionService()
        {

        }

        public void SaveReport()
        {
            String filePath = Directory.GetCurrentDirectory();
            filePath = Path.Combine(filePath, @"..\DataFiles\Reports");
            String fileName = "MedicationConsumptionReport.pdf";
            String localFile = Path.Combine(filePath, fileName);
            String fileServer = @"\public\MedicationConsumptionReport.pdf";

            using (SftpClient client = new SftpClient(new PasswordConnectionInfo("192.168.56.1", "tester", "password")))
            {
                client.Connect();
                if (File.Exists(localFile)) {
                    File.Delete(localFile);
                }
                using (Stream stream = File.OpenWrite(localFile))
                {
                    client.DownloadFile(fileServer, stream, null);
                }
                client.Disconnect();
            }

        }
    }
}
