using Linus.SolarRiedi.Common;
using Linus.SolarRiedi.AzureStorageWrapper.Contracts;
using Linus.SolarRiedi.FtpDownloader.Contracs;
using Linus.SolarRiedi.FtpWrapper.Contracts;
using Linus.SolarRiedi.Settings.Contracts;
using System;
using System.Linq;

namespace Linus.SolarRiedi.FtpDownloader
{
    public class FtpDownlaoder : IFtpDownloader
    {
        private readonly IAzureStorage azureStorage;
        private readonly IFtpWrapperFactory ftpWrapperFactory;
        private readonly ISettingsProvider settingsProvider;

        public FtpDownlaoder(
            IAzureStorage azureStorage,
            IFtpWrapperFactory ftpWrapperFactory,
            ISettingsProvider settingsProvider)
        {
            this.settingsProvider = settingsProvider;
            this.ftpWrapperFactory = ftpWrapperFactory;
            this.azureStorage = azureStorage;
        }

        public void DownLoad(string containerName, string filePrefix)
        {
            this.Download(containerName, new AllFilesFilter(filePrefix));
        }
                
        public void DownLoadOfLastFourDays(string containerName, string filePrefix)
        {
            var files = this.azureStorage.GetAllFiles(containerName, filePrefix);

            var last = files.Last(file => file.Contains(filePrefix));
            var lastFileDateTime = Time.CreateDateTimeFromFileName(last);
            lastFileDateTime -= TimeSpan.FromDays(3);

            this.Download(containerName, new FromDateFilter(filePrefix, lastFileDateTime));
        }

        private void Download(string containerName, IFileListFilter filter)
        {
            var uri = this.settingsProvider.GetFtpUri();
            var credentials = this.settingsProvider.GetFtpCredentials();

            Console.WriteLine("Start download of files");
            
            using (var ftpClient = this.ftpWrapperFactory.Create(uri, credentials))
            {
                var allFiles = ftpClient.GetFilesNames();
                var fileNames = filter.Filter(allFiles);

                foreach (var fileName in fileNames)
                {
                    Console.WriteLine("download and save file {0}", fileName);

                    var stream = ftpClient.GetStream(fileName);
                    this.azureStorage.UploadFromStream(stream, containerName, fileName);

                    Console.WriteLine("SUCCESSFULLY downloaded and save file {0}", fileName);
                }
            }

            Console.WriteLine("End download of files.");
        }
    }
}
