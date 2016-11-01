using System;
using System.Collections.Generic;
using ArxOne.Ftp;
using System.Linq;
using Common;

namespace Linus.SolarRiedi.FtpDownloader
{
    class FromDateFilter : IFileListFilter
    {
        private readonly DateTimeOffset fromDate;
        private readonly string filePrefix;

        public FromDateFilter(string filePrefix, DateTimeOffset fromDate)
        {
            this.filePrefix = filePrefix;
            this.fromDate = fromDate;
        }

        public IEnumerable<FtpEntry> Filter(IEnumerable<FtpEntry> inputList)
        {
            return inputList
                .Where(file => file.Name.Contains(this.filePrefix))
                .Where(file => Time.CreateDateTimeFromFileName(file.Name) >= this.fromDate);
        }
    }
}
