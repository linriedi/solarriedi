using ArxOne.Ftp;
using Linus.SolarRiedi.AzureStorageWrapper.Contracts;
using Linus.SolarRiedi.FtpDownloader.Contracs;
using System;
using System.Linq;
using System.Net;

namespace Linus.SolarRiedi.FtpDownloader
{
    public class FtpDownlaoder : IFtpDownloader
    {
        private IAzureStorage azureStorage;
        
        public FtpDownlaoder(IAzureStorage azureStorage)
        {
            this.azureStorage = azureStorage;
        }

        public void DownLoad(Uri uri, NetworkCredential credentials, string containerName, string filePrefix)
        {
            Console.WriteLine("Start download of files");

            this.azureStorage.Init(containerName);

            using (var ftpClient = new FtpClient(uri, credentials))
            {
                var fileList = ftpClient
                    .ListEntries("")
                    .Where(file => file.Name.Contains(filePrefix));

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
