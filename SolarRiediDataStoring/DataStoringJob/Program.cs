using Linus.SolarRiedi.AzureStorageService;
using Linus.SolarRiedi.DataStoringService;
using Linus.SolarRiedi.Settings;
using Microsoft.Azure.WebJobs;
using System;

namespace Linus.SolarRiedi.DataStoringJob
{
    // To learn more about Microsoft Azure WebJobs SDK, please see http://go.microsoft.com/fwlink/?LinkID=320976
    class Program
    {
        // Please set the following connection strings in app.config for this WebJob to run:
        // AzureWebJobsDashboard and AzureWebJobsStorage
        static void Main()
        {
            Console.Write("Start web job to store measurement data for solarriedi");
            var host = new JobHost();

            var service = new Service(new FtpDownloader.FtpDownlaoder(new StorageService(new SettingsProvider()), new SettingsProvider()));

            service.StoreData();

            Console.Write("End of web job to store measurement data for solarriedi");
        }
    }
}
