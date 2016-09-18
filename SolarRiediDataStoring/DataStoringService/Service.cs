using Linus.SolarRiedi.DataStoringService.Contracts;
using System;
using Linus.SolarRiedi.FtpDownloader.Contracs;
using System.Net;

namespace Linus.SolarRiedi.DataStoringService
{
    public class Service : IService
    {
        private IFtpDownloader ftpDownlaoder;

        public Service(IFtpDownloader ftpDownlaoder)
        {
            this.ftpDownlaoder = ftpDownlaoder;
        }
             

        public void StoreData()
        {
            Console.WriteLine("Start store data in service");

            this.ftpDownlaoder.DownLoad();

            Console.WriteLine("End store data in service");
        }
    }
}
