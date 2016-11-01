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
            
        public void StoreDataOfLastFourDays(string tableName, string filePrefix)
        {
            Console.WriteLine("Start store data for the last four days in service");

            //this.ftpDownlaoder.DownLoadOfLastFourDays("mesiraziun", filePrefix);
            //this.databankService.UpdateDatabankOfLastFourDays(tableName, filePrefix);

            //this.ftpDownlaoder.DownLoad("mesiraziun", "days");
            //this.databankService.UpdateDays("gis", "days");

            this.ftpDownlaoder.DownLoad("mesiraziun", "month");
            this.databankService.UpdateMonth("meins", "month");

            this.ftpDownlaoder.DownLoad("mesiraziun", "year");

            Console.WriteLine("End store data for the last four days in service");
        }
    }
}
