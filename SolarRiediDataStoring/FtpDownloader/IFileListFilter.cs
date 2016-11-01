using ArxOne.Ftp;
using System.Collections.Generic;

namespace Linus.SolarRiedi.FtpDownloader
{
    interface IFileListFilter
    {
        IEnumerable<FtpEntry> Filter(IEnumerable<FtpEntry> inputList);
    }
}
