using ArxOne.Ftp;
using FtpDownloader.Contract;
using System;
using System.Net;

namespace FtpDownloader
{
    public class FtpDownloader : IFtpDownloader
    {
        public void DownLoad(Uri uri, NetworkCredential credentials, string targedPath)
        {
            using (var ftpClient = new FtpClient(uri, credentials))
            {
                var stream = ftpClient.Retr("/httpdocs/min160901.csv");

                using (var fileStream = System.IO.File.Create(targedPath + "//test.csv"))
                {
                    byte[] buffer = new byte[8 * 1024];
                    int len;
                    while ((len = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fileStream.Write(buffer, 0, len);
                    }
                }
            }
        }
    }
}
