using System;
using System.Net;

namespace FtpClient.Client
{
    public interface IFtpClient
    {
        void DownLoad(Uri uri, NetworkCredential credentials, string v);
    }
}
