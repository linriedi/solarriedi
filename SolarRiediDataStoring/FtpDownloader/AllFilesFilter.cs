using System.Collections.Generic;
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

        public IEnumerable<string> Filter(IEnumerable<string> inputList)
        {
            return inputList
                .Where(file => file.Contains(this.filePrefix));
        }
    }
}
