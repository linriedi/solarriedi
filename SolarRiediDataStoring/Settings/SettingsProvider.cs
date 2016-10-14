using System;
using System.Net;
using Linus.SolarRiedi.Settings.Contracts;

namespace Linus.SolarRiedi.Settings
{
    public class SettingsProvider : ISettingsProvider
    {
        public string GetDbConnectionString()
        {
            return "Server=tcp:solarriedi.database.windows.net,1433;Initial Catalog=SolarRiediDB;Persist Security Info=False;User ID=solarriedi;Password=MesjamnaNew2016;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        }

        public NetworkCredential GetFtpCredentials()
        {
            return new NetworkCredential("ftpsolarrie0b35", "Gy4A6EjYLy");
        }

        public Uri GetFtpUri()
        {
            return new Uri("ftp://solarriedi.ch/");
        }

        public string GetStorageConnectionString()
        {
            return "DefaultEndpointsProtocol=https;AccountName=solarstorage;AccountKey=WI6Pkweae7xoqxI8KpUE37x+9yyHe+vAr+u3oIfcitpbjaG1QyCFfwV7/+uk4/PbdTcAlWUdF8NZMjAn8y4ZMA==";
        }
    }
}
