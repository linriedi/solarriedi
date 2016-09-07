using Startup;
using System;
using System.Net;

namespace FtpTests
{
    class Program
    {
        static void Main(string[] args)
        {
            var boostrapper = new Bootstrapper();
            boostrapper.Configure();

            var settingsProvider = boostrapper.SettingsProvider;
            
            Console.WriteLine("Enter Password: ");
            var password = Console.ReadLine();

            var credentials = new NetworkCredential(settingsProvider.GetUserName(), password);

            var ftpClient = boostrapper.FtpDownloader;
            ftpClient.DownLoad(new Uri(settingsProvider.GetFtpUri()), credentials, settingsProvider.GetArchivePath());
        }
    }
}
