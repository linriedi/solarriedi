using ArxOne.Ftp;
using Microsoft.OneDrive.Sdk;
using Microsoft.OneDrive.Sdk.Authentication;
using Settings;
using System;
using System.Net;

namespace FtpTests
{
    class Program
    {
        static void Main(string[] args)
        {
            ISettingsProvider settingsProvider = new SettingsProvider();

            Console.WriteLine("Enter Password: ");
            var password = Console.ReadLine();

            var credentials = new NetworkCredential(settingsProvider.GetUserName(), password);

            Ftp(new Uri(settingsProvider.GetFtpUri()), credentials, settingsProvider.GetArchivePath());

            //NewMethod();

            //Console.ReadLine();
        }

        private static async System.Threading.Tasks.Task NewMethod()
        {
            //var options = new Options
            //{
            //    ClientId = "bca4675d-9325-425e-8ffe-95ce0bb7e3dd",
            //    ClientSecret = "jnA0TQhaBbzEEKmox56j5zJ",
            //    CallbackUrl = "https://login.live.com/oauth20_desktop.srf",

            //    AutoRefreshTokens = true,
            //    PrettyJson = false,
            //    ReadRequestsPerSecond = 2,
            //    WriteRequestsPerSecond = 2
            //};

            

            var msaAuthProvider = new MsaAuthenticationProvider("bca4675d - 9325 - 425e-8ffe - 95ce0bb7e3dd", "https://login.live.com/oauth20_desktop.srf", new []{ "onedrive.readonly", "wl.signin" });

            await msaAuthProvider.AuthenticateUserAsync();
            var oneDriveClient = new OneDriveClient("https://api.onedrive.com/v1.0", msaAuthProvider);
        }

        private static void Ftp(Uri uri, NetworkCredential credentials, string targedPath)
        {
            using (var ftpClient = new FtpClient(uri, credentials))
            {
                var stream = ftpClient.Retr("/httpdocs/min160901.csv");

                using (var fileStream = System.IO.File.Create(targedPath + "//test.csv"))
                {
                    byte[] buffer = new byte[8 * 1024];
                    int len;
                    while ((len = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fileStream.Write(buffer, 0, len);
                    }
                }

                Console.WriteLine("");
            }
        }
    }
}
