using System;
using System.Net;
using Linus.SolarRiedi.FtpWrapper.Contracts;

namespace Linus.SolarRiedi.FtpWrapperService
{
    public class FtpWrapperFactory : IFtpWrapperFactory
    {
        public IFtpWrapper Create(Uri uri, NetworkCredential credentials)
        {
            return new FtpWrapper(uri, credentials);
        }
    }
}
