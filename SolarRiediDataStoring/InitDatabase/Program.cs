using Linus.SolarRiedi.AzureStorageService;
using Linus.SolarRiedi.DbConnectionService;
using Linus.SolarRiedi.Settings;
using Linus.SolarRiedi.SolarRiediDBUpdater;

namespace InitDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            var settingsProvider = new SettingsProvider();

            var azureStorage = new StorageService(settingsProvider);
            var service = new DatabankService(
                    settingsProvider,
                    azureStorage,
                    new ConnectionService(),
                    DatabankServiceModule.DataTableCreator);

            service.FullUpdate();
        }
    }
}
