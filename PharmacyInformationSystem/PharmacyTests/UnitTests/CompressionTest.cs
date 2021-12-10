using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmacyAPI.BackgroundService;
using Shouldly;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Xunit;

namespace PharmacyTests.UnitTests
{
    public class CompressionTest
    {
        private CompressionOfOldFiles compressionOfOldFiles = new CompressionOfOldFiles();
        private readonly string prescriptionsZipFilePath;
        private readonly string reportsZipFilePaht;
        private readonly string prescriptionPdfFilePath;
        private readonly string reportPdfFilePath;

        public CompressionTest()
        {
            string filePath = Directory.GetCurrentDirectory();
            filePath = Directory.GetParent(filePath).ToString();
            filePath = Directory.GetParent(filePath).ToString();
            filePath = Directory.GetParent(filePath).ToString();
            filePath = Directory.GetParent(filePath).ToString();

            this.prescriptionsZipFilePath = Path.Combine(filePath, "DataFiles" + Path.DirectorySeparatorChar + "Prescriptions" 
                + Path.DirectorySeparatorChar + "prescriptions_" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".zip");
            this.reportsZipFilePaht = Path.Combine(filePath, "DataFiles" + Path.DirectorySeparatorChar + "Reports" 
                + Path.DirectorySeparatorChar + "reports_" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".zip");
            this.prescriptionPdfFilePath = Path.Combine(filePath, "DataFiles" + Path.DirectorySeparatorChar + "Prescriptions" 
                + Path.DirectorySeparatorChar + "prescriptionTEST12345.pdf");
            this.reportPdfFilePath = Path.Combine(filePath, "DataFiles" + Path.DirectorySeparatorChar + "Reports" 
                + Path.DirectorySeparatorChar + "reportTEST12345.pdf");
        }

        [Fact]
        public void Pdf_files_compression()
        {
            List<string> prescriptionPdfPaths = PreparePrescriptionPdfFilesForTesting();
            List<string> reportPdfPaths = PrepareReportPdfFilesForTesting();

            compressionOfOldFiles.CreateZipFile(prescriptionsZipFilePath, prescriptionPdfPaths);
            compressionOfOldFiles.CreateZipFile(reportsZipFilePaht, reportPdfPaths);

            ZipFilesAreCreated().ShouldBeTrue();
            DeleteTestingFiles();
        }

        public bool ZipFilesAreCreated()
        {
            return File.Exists(prescriptionsZipFilePath) && File.Exists(reportsZipFilePaht);
        }

        private void DeleteTestingFiles()
        {
            List<string> files = new();
            files.Add(prescriptionPdfFilePath);
            files.Add(prescriptionsZipFilePath);
            files.Add(reportPdfFilePath);
            files.Add(reportsZipFilePaht);

            foreach (string file in files)
            {
                File.Delete(file);
            }
        }

        private List<string> PreparePrescriptionPdfFilesForTesting()
        {
            GenerateTestPdf(prescriptionPdfFilePath);
            List<string> pdfPaths = new List<string>();
            pdfPaths.Add(prescriptionPdfFilePath);

            return pdfPaths;
        }

        private List<string> PrepareReportPdfFilesForTesting()
        {
            GenerateTestPdf(reportPdfFilePath);
            List<string> pdfPaths = new List<string>();
            pdfPaths.Add(reportPdfFilePath);

            return pdfPaths;
        }


        private string GenerateTestPdf(string pdfPath)
        {
            PdfDocument doc = new PdfDocument();
            PdfPageBase page = doc.Pages.Add();
            page.Canvas.DrawString("Test", new PdfFont(PdfFontFamily.Helvetica, 11f), new PdfSolidBrush(Color.Black), 10, 10);
            StreamWriter File = new StreamWriter(pdfPath, true);
            doc.SaveToStream(File.BaseStream);
            File.Close();
            doc.Close();

            return pdfPath;
        }
    }
}
