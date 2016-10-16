using Linus.SolarRiedi.AzureStorageService;
using Linus.SolarRiedi.DataStoringService;
using Linus.SolarRiedi.DbConnectionService;
using Linus.SolarRiedi.Settings;
using Linus.SolarRiedi.SolarRiediDBUpdater;
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

            var azureStorage = new StorageService(new SettingsProvider());
            var service = new Service(
                new FtpDownloader.FtpDownlaoder(
                    azureStorage,
                    new SettingsProvider()),
                new DatabankService(
                    new SettingsProvider(),
                    azureStorage,
                    new ConnectionService(),
                    DatabankServiceModule.DataTableCreator));

            service.StoreDataOfLastFourDays();

            Console.Write("End of web job to store measurement data for solarriedi");
        }
    }
}
