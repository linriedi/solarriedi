using Linus.SolarRiedi.AzureStorageService;
using Linus.SolarRiedi.FtpDownloader;
using Linus.SolarRiedi.Settings;
using System;

namespace InitDataStorage
{
    class Program
    {
        static void Main(string[] args)
        {
            var settingsProvider = new SettingsProvider();
            var azureStorage = new StorageService(settingsProvider);

            var ftpDownloader = new FtpDownlaoder(
                    azureStorage,
                    settingsProvider);

            Console.WriteLine("Start download min files");
            ftpDownloader.DownLoad("mesiraziun", "min");
            Console.WriteLine("Finished dosnload min files");

            Console.WriteLine("Start download days files");
            ftpDownloader.DownLoad("mesiraziun", "days");
            Console.WriteLine("Finished dosnload days files");

            Console.WriteLine("Start download month files");
            ftpDownloader.DownLoad("mesiraziun", "month");
            Console.WriteLine("Finished dosnload month files");

            Console.WriteLine("Start download year files");
            ftpDownloader.DownLoad("mesiraziun", "year");
            Console.WriteLine("Finished dosnload year files");
        }
    }
}
