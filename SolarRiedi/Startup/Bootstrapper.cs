using FtpClient.Client;
using Settings;
using Settings.Contracts;

namespace Startup
{
    public class Bootstrapper
    {
        public IFtpClient FtpClient { get; private set; }
        public ISettingsProvider SettingsProvider { get; private set; }

        public void Configure()
        {
            this.SettingsProvider = new SettingsProvider();
            this.FtpClient = new FtpClient.FtpClient();
        }
    }
}
