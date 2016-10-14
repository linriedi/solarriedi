using System;
using System.Net;
using Linus.SolarRiedi.Settings.Contracts;

namespace Linus.SolarRiedi.Settings
{
    public class SettingsProvider : ISettingsProvider
    {
        public string GetDbConnectionString()
        {
            return null;
        }

        public NetworkCredential GetFtpCredentials()
        {
            return null;
        }

        public Uri GetFtpUri()
        {
            return null;
        }

        public string GetStorageConnectionString()
        {
            return null;
        }
    }
}
