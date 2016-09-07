using FtpDownloader.Contract;
using Settings;
using Settings.Contracts;

namespace Startup
{
    public class Bootstrapper
    {
        public IFtpDownloader FtpDownloader { get; private set; }
        public ISettingsProvider SettingsProvider { get; private set; }

        public void Configure()
        {
            this.SettingsProvider = new SettingsProvider();
            this.FtpDownloader = new FtpDownloader.FtpDownloader();
        }
    }
}
