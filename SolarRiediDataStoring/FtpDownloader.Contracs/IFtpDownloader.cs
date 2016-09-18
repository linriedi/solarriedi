using System;
using System.Net;

namespace Linus.SolarRiedi.FtpDownloader.Contracs
{
    public interface IFtpDownloader
    {
        void DownLoad(string targedPath, string filePrefix);
    }
}
