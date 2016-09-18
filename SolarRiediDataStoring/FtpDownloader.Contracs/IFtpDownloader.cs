using System;
using System.Net;

namespace Linus.SolarRiedi.FtpDownloader.Contracs
{
    public interface IFtpDownloader
    {
        void DownLoad(Uri uri, NetworkCredential credentials, string targedPath, string filePrefix);
    }
}
