using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using ArxOne.Ftp;
using System.Net;
using Microsoft.WindowsAzure.Storage;
using System.IO;

namespace TestWebJob
{
    // To learn more about Microsoft Azure WebJobs SDK, please see http://go.microsoft.com/fwlink/?LinkID=320976
    class Program
    {
        // Please set the following connection strings in app.config for this WebJob to run:
        // AzureWebJobsDashboard and AzureWebJobsStorage
        static void Main()
        {
            var host = new JobHost();
            // The following code ensures that the WebJob will be running continuously
            //host.RunAndBlock();
            Console.WriteLine("Hello World form Linus");

            using (var ftpClient = new FtpClient(new Uri("ftp://solarriedi.ch/"), new NetworkCredential("ftpsolarrie0b35", "Gy4A6EjYLy")))
            {
                Console.WriteLine(1);
                var fileList = ftpClient.ListEntries("");
                Console.WriteLine(2);
                //foreach(var file in fileList)
                //{
                //    Console.WriteLine(file.Name);
                //}
                Console.WriteLine(3);

                var storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=solarstorage;AccountKey=K96PW9lHU6VBtetM/ctubrSbd4g5EZvzDSV+0RMeHN/KiZl24f9UBd3z16jZtJWWHSPHSx+5rs3MN9IJQSV8bg==");

                Console.WriteLine(4);

                // Create the blob client.
                var blobClient = storageAccount.CreateCloudBlobClient();

                Console.WriteLine(5);

                // Retrieve a reference to a container.
                var container = blobClient.GetContainerReference("testcontainer");

                Console.WriteLine(6);

                // Create the container if it doesn't already exist.
                container.CreateIfNotExists();

                Console.WriteLine(7);

                /////
                //.ListEntries("")
                //.Where(file => file.Name.Contains(filePrefix));

                //foreach (var file in fileList)
                //{

                var file = fileList.First(e => e.Name.Contains("min"));
                var stream = ftpClient.Retr(file.Name);

                var blockBlob = container.GetBlockBlobReference("Hallo.csv");

                blockBlob.UploadFromStream(stream);

                var blockBlob2 = container.GetBlockBlobReference("Hallo.csv");

                var text = "";
                using (var memoryStream = new MemoryStream())
                {
                    blockBlob2.DownloadToStream(memoryStream);
                    text = System.Text.Encoding.UTF8.GetString(memoryStream.ToArray());
                }

                using (StreamWriter outputFile = new StreamWriter("C:\\Users\\linri\\Desktop\\myblob.csv"))
                {
                    outputFile.Write(text);
                }
            }
        }
    }
}
