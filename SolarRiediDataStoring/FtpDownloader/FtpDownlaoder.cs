using ArxOne.Ftp;
using Common;
using Linus.SolarRiedi.AzureStorageWrapper.Contracts;
using Linus.SolarRiedi.FtpDownloader.Contracs;
using Linus.SolarRiedi.Settings.Contracts;
using System;
using System.Linq;
using System.Net;
using System.Text;

namespace Linus.SolarRiedi.FtpDownloader
{
    public class FtpDownlaoder : IFtpDownloader
    {
        private readonly IAzureStorage azureStorage;
        private readonly ISettingsProvider settingsProvider;

        public FtpDownlaoder(IAzureStorage azureStorage, ISettingsProvider settingsProvider)
        {
            this.settingsProvider = settingsProvider;
            this.azureStorage = azureStorage;
        }

        public void DownLoad(string containerName, string filePrefix)
        {
            this.Download(containerName, filePrefix, DateTime.MinValue);
        }
                
        public void DownLoadOfLastFourDays(string containerName, string filePrefix)
        {
            this.azureStorage.Init(containerName);
            var files = this.azureStorage.GetAllFiles();

            var last = files.Last(file => file.Contains(filePrefix));
            var lastFileDateTime = Time.CreateDateTimeFromFileName(last);
            lastFileDateTime -= TimeSpan.FromDays(3);

            this.Download(containerName, filePrefix, lastFileDateTime);
        }

        private void Download(string containerName, string filePrefix, DateTimeOffset fromDate)
        {
            var uri = this.settingsProvider.GetFtpUri();
            var credentials = this.settingsProvider.GetFtpCredentials();

            Console.WriteLine("Start download of files");

            this.azureStorage.Init(containerName);

            using (var ftpClient = new FtpClient(uri, credentials))
            {
                var fileList = ftpClient
                    .ListEntries("")
                    .Where(file => file.Name.Contains(filePrefix))
                    .Where(file => Time.CreateDateTimeFromFileName(file.Name) >= fromDate);
                
                foreach (var file in fileList)
                {
                    Console.WriteLine("download and save file {0}", file.Name);

                    var stream = ftpClient.Retr(file.Name);
                    this.azureStorage.UploadFromStream(stream, file.Name);

                    Console.WriteLine("SUCCESSFULLY downloaded and save file {0}", file.Name);
                }
            }

            Console.WriteLine("End download of files.");
        }
    }
}
