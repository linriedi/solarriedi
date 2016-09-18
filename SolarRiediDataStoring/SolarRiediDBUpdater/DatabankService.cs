using Linus.SolarRiedi.AzureStorageWrapper.Contracts;
using Linus.SolarRiedi.ConnectionWrapper.Contracts;
using Linus.SolarRiedi.Settings.Contracts;
using Linus.SolarRiedi.SolarRiediDBUpdater.Contracs;
using System;
using System.IO;

namespace Linus.SolarRiedi.SolarRiediDBUpdater
{
    public class DatabankService : IDatabankService
    {
        private readonly IAzureStorage azureStorage;
        private readonly IDataTableCreator dataTableCreator;
        private readonly IDbConnection dbConnection;
        private readonly ISettingsProvider settingsProvider;

        public DatabankService(
            ISettingsProvider settingsProvider, 
            IAzureStorage azureStorage,
            IDbConnection dbConnection,
            IDataTableCreator dataTableCreator)
        {
            this.settingsProvider = settingsProvider;
            this.azureStorage = azureStorage;
            this.dbConnection = dbConnection;
            this.dataTableCreator = dataTableCreator;
        }

        public void UpdateDatabank()
        {
            Console.WriteLine("Start Update Databank");
                       
            this.azureStorage.Init("mesiraziun");

            this.dbConnection.DeleteItemsInTable(this.settingsProvider.GetDbConnectionString());
            var fileNames = this.azureStorage.GetAllFiles();
            foreach (var fileName in fileNames)
            {
                Console.WriteLine("Start insert measurments for file {0}", fileName);

                var text = string.Empty;
                using (var memoryStream = new MemoryStream())
                {
                    this.azureStorage.GetStream(fileName, memoryStream);
                    text = System.Text.Encoding.UTF8.GetString(memoryStream.ToArray());
                }

                var insertString = this.dataTableCreator.Crete(text);
                this.dbConnection.Insert(insertString, this.settingsProvider.GetDbConnectionString());

                Console.WriteLine("SUCCESSFULLY inserted measurments for file {0}", fileName);
            }

            Console.WriteLine("End Update Databank");
        }
    }
}
