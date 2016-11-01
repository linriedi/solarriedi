﻿using System.IO;
using Linus.SolarRiedi.AzureStorageWrapper.Contracts;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Linus.SolarRiedi.Settings.Contracts;
using System.Linq;
using System.Collections.Generic;
using System.Text;

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
              
        public void UploadFromStream(Stream stream, string containerName, string fileName)
        {
            this.Init(containerName);
            var blockBlob = this.container.GetBlockBlobReference(fileName);
            blockBlob.UploadFromStream(stream);
        }

        public IEnumerable<string> GetAllFiles(string containerName, string filePrefix)
        {
            this.Init(containerName);
            return this.container
                .ListBlobs()
                .Select(b => Path.GetFileName(b.Uri.LocalPath))
                .Where(bs => bs.Contains(filePrefix));
        }

        public string GetCsvAsString(string fileName)
        {
            var text = string.Empty;
            using (var memoryStream = new MemoryStream())
            {
                this.GetStream(fileName, memoryStream);
                text = Encoding.UTF8.GetString(memoryStream.ToArray());
            }

            return text;
        }

        private void Init(string containerName)
        {
            var storageAccount = CloudStorageAccount.Parse(this.settingsProvider.GetStorageConnectionString());
            var blobClient = storageAccount.CreateCloudBlobClient();
            this.container = blobClient.GetContainerReference(containerName);
            this.container.CreateIfNotExists();
        }

        private void GetStream(string fileName, Stream stream)
        {
            var blob = this.container.GetBlockBlobReference(fileName);
            blob.DownloadToStream(stream);
        }
    }
}
