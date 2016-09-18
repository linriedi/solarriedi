using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Linus.SolarRiedi.Settings.Contracts
{
    public interface ISettingsProvider
    {
        string GetStorageConnectionString();
        Uri GetFtpUri();
        NetworkCredential GetFtpCredentials();
        string GetDbConnectionString();
    }
}
