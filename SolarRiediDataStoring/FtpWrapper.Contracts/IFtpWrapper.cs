using System;
using System.Collections.Generic;
using System.IO;

namespace Linus.SolarRiedi.FtpWrapper.Contracts
{
    public interface IFtpWrapper : IDisposable
    {
        IEnumerable<string> GetFilesNames();
        Stream GetStream(string fileName);
    }
}
