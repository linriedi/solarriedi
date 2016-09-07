using Settings;
using Settings.Contracts;

namespace Startup
{
    public class Bootstrapper
    {
        public ISettingsProvider SettingsProvider { get; private set; }

        public void Configure()
        {
            this.SettingsProvider = new SettingsProvider();
        }
    }
}
