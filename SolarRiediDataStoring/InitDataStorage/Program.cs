using Linus.SolarRiedi.AzureStorageService;
using Linus.SolarRiedi.DbConnectionService;
using Linus.SolarRiedi.Settings;
using Linus.SolarRiedi.SolarRiediDBUpdater;
using System;

namespace InitDataStorage
{
    class Program
    {
        static void Main(string[] args)
        {
            var azureStorage = new StorageService(new SettingsProvider());

            //var ftpDownloader = new Linus.SolarRiedi.FtpDownloader.FtpDownlaoder(
            //        azureStorage,
            //        new SettingsProvider());

            //Console.WriteLine("Start download min files");
            //ftpDownloader.DownLoad("mesiraziun", "min");
            //Console.WriteLine("Finished dosnload min files");

            var databank = new DatabankService(
                    new SettingsProvider(),
                    azureStorage,
                    new ConnectionService(),
                    DatabankServiceModule.DataTableCreator);

            Console.WriteLine("Start full update");
            databank.FullUpdate();
            Console.WriteLine("Finish full update");
        }
    }
}
