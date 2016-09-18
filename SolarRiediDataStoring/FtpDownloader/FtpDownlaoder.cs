using ArxOne.Ftp;
using Linus.SolarRiedi.FtpDownloader.Contracs;
using Microsoft.WindowsAzure.Storage;
using System;
using System.Linq;
using System.Net;

namespace Linus.SolarRiedi.FtpDownloader
{
    public class FtpDownlaoder : IFtpDownloader
    {
        public void DownLoad(Uri uri, NetworkCredential credentials, string containerName, string filePrefix)
        {
            Console.WriteLine("Start download of files");

            var storageAccount = CloudStorageAccount.Parse("***********************");
            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference(containerName);
            container.CreateIfNotExists();

            using (var ftpClient = new FtpClient(uri, credentials))
            {
                var fileList = ftpClient
                    .ListEntries("")
                    .Where(file => file.Name.Contains(filePrefix));

                foreach (var file in fileList)
                {
                    var stream = ftpClient.Retr(file.Name);
                    var blockBlob = container.GetBlockBlobReference(file.Name);

                    Console.WriteLine("download and save file {0}", file.Name);
                    blockBlob.UploadFromStream(stream);
                    Console.WriteLine("SUCCESSFULLY downloaded and save file {0}", file.Name);
                }
            }

            Console.WriteLine("End download of files.");
        }
    }
}
