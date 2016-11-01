using Common;
using Linus.SolarRiedi.AzureStorageWrapper.Contracts;
using Linus.SolarRiedi.ConnectionWrapper.Contracts;
using Linus.SolarRiedi.Settings.Contracts;
using Linus.SolarRiedi.SolarRiediDBUpdater.Contracs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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

        public void FullUpdateOnTable(string tableName, string filePrefix)
        {
            this.azureStorage.Init("mesiraziun");
            var fileNames = this.azureStorage.GetAllFiles(filePrefix);

            DoUpdate(fileNames, tableName);
        }

        public void UpdateDatabankOfLastFourDays(string tableName, string filePrefix)
        {
            this.azureStorage.Init("mesiraziun");
            var fileNames = this
                .azureStorage
                .GetAllFiles(filePrefix)
                .LastFour();

            var date = Time.CreateDateTimeFromFileName(fileNames.First());
            var sqlCommand = this.dataTableCreator.CreteDeleteFrom(tableName, date);

            this.dbConnection.Insert(sqlCommand, this.settingsProvider.GetDbConnectionString());
            this.DoUpdate(fileNames, tableName);
        }

        private void DoUpdate(IEnumerable<string> fileNames, string tableName)
        {
            foreach (var fileName in fileNames)
            {
                var text = GetExelFileAsString(fileName);

                Console.WriteLine("Start create entries for {0}", fileName);
                var entries = this.dataTableCreator.CreateMinutesEntry(text);
                Console.WriteLine("Finish create entries for {0}", fileName);

                Console.WriteLine("Start insert entries {0}", fileName);

                var before = DateTime.Now;
                this.Insert(tableName, entries);

                Console.WriteLine("took time {0}: ", DateTime.Now - before);

                Console.WriteLine("Finish create entries {0}", fileName);
            }
        }
               
        private void Insert(string tableName, IEnumerable<FiveMinutes> fiveMinutes)
        {
            foreach(var minute in fiveMinutes)
            {
                var sqlCommand = new SqlCreator().Create(tableName, minute);
                this.dbConnection.Insert(sqlCommand, this.settingsProvider.GetDbConnectionString());
            }
        }

        private string GetExelFileAsString(string fileName)
        {
            var text = string.Empty;
            using (var memoryStream = new MemoryStream())
            {
                this.azureStorage.GetStream(fileName, memoryStream);
                text = Encoding.UTF8.GetString(memoryStream.ToArray());
            }

            return text;
        }
    }
}