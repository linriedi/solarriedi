using System;
using Linus.SolarRiedi.SolarRiediDBUpdater.Contracs;
using Linus.SolarRiedi.DataStoringService.Contracts;
using Linus.SolarRiedi.FtpDownloader.Contracs;

namespace Linus.SolarRiedi.DataStoringService
{
    public class Service : IService
    {
        private readonly IDatabankService databankService;
        private readonly IFtpDownloader ftpDownlaoder;

        public Service(IFtpDownloader ftpDownlaoder, IDatabankService databankService)
        {
            this.ftpDownlaoder = ftpDownlaoder;
            this.databankService = databankService;
        }
             
        public void StoreData()
        {
            Console.WriteLine("Start store data in service");

            this.ftpDownlaoder.DownLoad("mesiraziun", "min");
            this.databankService.UpdateDatabank();

            Console.WriteLine("End store data in service");
        }

        public void StoreDataOfLastFourDays(string tableName, string filePrefix)
        {
            Console.WriteLine("Start store data for the last four days in service");

            this.ftpDownlaoder.DownLoadOfLastFourDays("mesiraziun", filePrefix);

            this.ftpDownlaoder.DownLoad("mesiraziun", "days");
            this.ftpDownlaoder.DownLoad("mesiraziun", "month");
            this.ftpDownlaoder.DownLoad("mesiraziun", "year");

            this.databankService.UpdateDatabankOfLastFourDays(tableName, filePrefix);

            Console.WriteLine("End store data for the last four days in service");
        }
    }
}
