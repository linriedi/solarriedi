using System;
using System.Collections.Generic;
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

        public IEnumerable<string> Filter(IEnumerable<string> inputList)
        {
            return inputList
                .Where(file => file.Contains(this.filePrefix))
                .Where(file => Time.CreateDateTimeFromFileName(file) >= this.fromDate);
        }
    }
}
