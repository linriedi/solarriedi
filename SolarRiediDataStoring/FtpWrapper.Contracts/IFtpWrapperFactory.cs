using System;
using System.Net;

namespace Linus.SolarRiedi.FtpWrapper.Contracts
{
    public interface IFtpWrapperFactory
    {
        IFtpWrapper Create(Uri uri, NetworkCredential credentials);
    }
}
