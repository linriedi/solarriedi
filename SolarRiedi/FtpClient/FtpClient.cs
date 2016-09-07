using ArxOne.Ftp;
using System;
using System.Net;
using FtpClient.Client;

namespace FtpClient
{
    public class FtpClient : IFtpClient
    {
        public void DownLoad(Uri uri, NetworkCredential credentials, string targedPath)
        {
            using (var ftpClient = new ArxOne.Ftp.FtpClient(uri, credentials))
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

                Console.WriteLine("");
            }
        }
    }
}
