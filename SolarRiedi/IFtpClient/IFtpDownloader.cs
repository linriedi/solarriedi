using System;
using System.Net;

namespace FtpDownloader.Contract
{
    public interface IFtpDownloader
    {
        void DownLoad(Uri uri, NetworkCredential credentials, string targedPath, string filePrefix);
    }
}
