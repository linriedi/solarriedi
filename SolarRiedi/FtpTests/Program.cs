using ArxOne.Ftp;
using System;
using System.IO;
using System.Net;

namespace FtpTests
{
    class Program
    {
        static void Main(string[] args)
        {
            var uri = new Uri("ftp://solarriedi.ch/");
            var credentials = new NetworkCredential("ftpsolarrie0b35", "Gy4A6EjYLy");

            using (var ftpClient = new FtpClient(uri, credentials))
            {
                var stream = ftpClient.Retr("/httpdocs/min160901.csv");

                using (var fileStream = File.Create("C://Users//linri//Desktop//test.csv"))
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
