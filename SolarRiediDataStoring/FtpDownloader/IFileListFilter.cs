using System.Collections.Generic;

namespace Linus.SolarRiedi.FtpDownloader
{
    interface IFileListFilter
    {
        IEnumerable<string> Filter(IEnumerable<string> inputList);
    }
}
