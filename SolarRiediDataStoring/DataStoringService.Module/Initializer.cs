using ExcelAdapter;
using Linus.SolarRiedi.DataStoringService;
using Linus.SolarRiedi.DataStoringService.Contracts;
using Linus.SolarRiedi.DbConnectionService;
using Linus.SolarRiedi.Settings;
using Linus.SolarRiedi.SolarRiediDBUpdater;

namespace DataStoringService.Module
{
    public class Initializer
    {
        public IReadService GetService()
        {
            return new ReadService(new ReadDBService(new ConnectionService(), new SettingsProvider()), new ExcelWriter());
        }
    }
}
