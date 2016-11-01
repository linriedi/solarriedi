using System;
using System.IO;
using Linus.SolarRiedi.AzureStorageWrapper.Contracts;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Linus.SolarRiedi.Settings.Contracts;
using System.Linq;
using System.Collections.Generic;

namespace Linus.SolarRiedi.AzureStorageService
{
    public class StorageService : IAzureStorage
    {
        private CloudBlobContainer container;
        private readonly ISettingsProvider settingsProvider;

        public StorageService (ISettingsProvider settingsProvider)
        {
            this.settingsProvider = settingsProvider;
        }

        public void Init(string containerName)
        {
            //var storageAccount = CloudStorageAccount.Parse("");
            var storageAccount = CloudStorageAccount.Parse(this.settingsProvider.GetStorageConnectionString());
            var blobClient = storageAccount.CreateCloudBlobClient();
            this.container = blobClient.GetContainerReference(containerName);
            this.container.CreateIfNotExists();
        }

        public void UploadFromStream(Stream stream, string fileName)
        {
            var blockBlob = this.container.GetBlockBlobReference(fileName);
            blockBlob.UploadFromStream(stream);
        }

        public void GetStream(string fileName, Stream stream)
        {
            var blob = this.container.GetBlockBlobReference(fileName);
            blob.DownloadToStream(stream);
        }

        public IEnumerable<string> GetAllFiles(string filePrefix)
        {
            return this.container
                .ListBlobs()
                .Select(b => Path.GetFileName(b.Uri.LocalPath))
                .Where(bs => bs.Contains(filePrefix));
        }
    }
}
