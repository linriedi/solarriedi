using System;
using System.Collections.Generic;
using System.IO;
using Linus.SolarRiedi.FtpWrapper.Contracts;
using ArxOne.Ftp;
using System.Net;
using System.Linq;

namespace Linus.SolarRiedi.FtpWrapperService
{
    public class FtpWrapper : IFtpWrapper
    {
        private readonly FtpClient ftpClient;

        public FtpWrapper(Uri uri, NetworkCredential credentials)
        {
            this.ftpClient = new FtpClient(uri, credentials);
        }

        public IEnumerable<string> GetFilesNames()
        {
            return this.ftpClient
                .ListEntries("")
                .Select(e => e.Name);
        }

        public Stream GetStream(string fileName)
        {
            return ftpClient.Retr(fileName);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.ftpClient.Dispose();
            }
        }
    }
}
