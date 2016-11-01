using System.Collections.Generic;
using ArxOne.Ftp;
using System.Linq;

namespace Linus.SolarRiedi.FtpDownloader
{
    class AllFilesFilter : IFileListFilter
    {
        private string filePrefix;

        public AllFilesFilter(string filePrefix)
        {
            this.filePrefix = filePrefix;
        }

        public IEnumerable<FtpEntry> Filter(IEnumerable<FtpEntry> inputList)
        {
            return inputList
                .Where(file => file.Name.Contains(this.filePrefix));
        }
    }
}
