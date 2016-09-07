using ArxOne.Ftp;
using FtpDownloader.Contract;
using System;
using System.Linq;
using System.Net;

namespace FtpDownloader
{
    public class FtpDownloader : IFtpDownloader
    {
        public void DownLoad(Uri uri, NetworkCredential credentials, string targedPath, string filePrefix)
        {
            using (var ftpClient = new FtpClient(uri, credentials))
            {
                var fileList = ftpClient
                    .ListEntries("")
                    .Where(file => file.Name.Contains(filePrefix));

                foreach(var file in fileList)
                {
                    var stream = ftpClient.Retr(file.Name);

                    using (var fileStream = System.IO.File.Create(targedPath + "\\" + file.Name))
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
}
