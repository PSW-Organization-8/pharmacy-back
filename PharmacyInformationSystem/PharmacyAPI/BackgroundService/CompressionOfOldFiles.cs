using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace PharmacyAPI.BackgroundService
{
    public class CompressionOfOldFiles : Microsoft.Extensions.Hosting.BackgroundService
    {
        private System.Timers.Timer compressionTimer = new System.Timers.Timer();
        private readonly double DAYS_FOR_OLD_FILE = 180;

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            compressionTimer.Elapsed += new ElapsedEventHandler(CompressOldFiles);
            //compressionTimer.Interval = 10000;    // 10 sekundi
            compressionTimer.Interval = 259200000;  // 3 dana
            compressionTimer.Enabled = true;
            return Task.CompletedTask;
        }

        public void CompressOldFiles(object source, ElapsedEventArgs e)
        {
            string filePath = Directory.GetCurrentDirectory();
            DirectoryInfo parentPath = Directory.GetParent(filePath);
            filePath = parentPath.ToString();

            CompressPrescriptions(filePath);
            CompressReports(filePath);
        }

        private void CompressPrescriptions(string filePath)
        {
            string filePathPrescriptions = Path.Combine(filePath, "DataFiles" + Path.DirectorySeparatorChar + "Prescriptions" + Path.DirectorySeparatorChar);
            List<string> allPrescriptions = GetPdfFilePathsFromFolder(filePathPrescriptions);
            string zipFileNamePrescriptions = filePathPrescriptions + "prescriptions_" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".zip";
            CreateZipFile(zipFileNamePrescriptions, allPrescriptions);
            DeleteZipeddFiles(allPrescriptions);
        }

        private void CompressReports(string filePath)
        {
            string filePathReports = Path.Combine(filePath, "DataFiles" + Path.DirectorySeparatorChar + "Reports" + Path.DirectorySeparatorChar);
            List<string> allReports = GetPdfFilePathsFromFolder(filePathReports);
            string zipFileNameReports = filePathReports + "reports_" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".zip";
            CreateZipFile(zipFileNameReports, allReports);
            DeleteZipeddFiles(allReports);
        }

        private List<string> GetPdfFilePathsFromFolder(string folderPath)
        {
            List<string> allFilePaths = new List<string>();
            foreach (string pdfFilePath in Directory.EnumerateFiles(folderPath, "*.pdf", SearchOption.TopDirectoryOnly))
            {
                allFilePaths.Add(pdfFilePath);
            }

            return allFilePaths;
        }

        private List<string> FilterForOlderFilesPaths(List<string> allFiles)
        {
            DateTime now = DateTime.Now;
            List<string> oldFiles = new List<string>();
            foreach (string file in allFiles)
            {
                DateTime creationTime = File.GetCreationTime(file);
                TimeSpan timeSpan = now - creationTime;

                if (timeSpan.TotalDays > DAYS_FOR_OLD_FILE)
                {
                    oldFiles.Add(file);
                }
            }

            return oldFiles;
        }

        private void DeleteZipeddFiles(IList<string> files)
        {
            foreach (string file in files)
            {
                File.Delete(file);
            }
        }

        /// <param name="fileName">The full path and name to store the ZIP file at.</param>
        /// <param name="files">The list of files to be added.</param>
        public void CreateZipFile(string fileName, IList<string> files)
        {
            if (files.Count == 0) return;

            var zip = ZipFile.Open(fileName, ZipArchiveMode.Create);

            foreach (var file in files)
            {
                zip.CreateEntryFromFile(file, Path.GetFileName(file), CompressionLevel.Optimal);
            }
            zip.Dispose();
        }
    }
}
