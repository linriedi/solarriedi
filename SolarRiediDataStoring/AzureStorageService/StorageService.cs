using System;
using System.IO;
using Linus.SolarRiedi.AzureStorageWrapper.Contracts;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Linus.SolarRiedi.AzureStorageService
{
    public class StorageService : IAzureStorage
    {
        private CloudBlobContainer container;

        public void Init(string containerName)
        {
            var storageAccount = CloudStorageAccount.Parse("*******");
            var blobClient = storageAccount.CreateCloudBlobClient();
            this.container = blobClient.GetContainerReference(containerName);
            this.container.CreateIfNotExists();
        }

        public void UploadFromStream(Stream stream, string fileName)
        {
            var blockBlob = this.container.GetBlockBlobReference(fileName);
            blockBlob.UploadFromStream(stream);
        }
    }
}
