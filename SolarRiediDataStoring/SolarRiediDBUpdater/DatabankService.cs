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
            var fileNames = this.azureStorage.GetAllFiles("mesiraziun", filePrefix);
            DoUpdate(fileNames, tableName);
        }

        public void UpdateDatabankOfLastFourDays(string tableName, string filePrefix)
        {
            var fileNames = this
                .azureStorage
                .GetAllFiles("mesiraziun", filePrefix)
                .LastFour();

            var date = Time.CreateDateTimeFromFileName(fileNames.First());
            var sqlCommand = new SqlCreator().CreteDeleteFrom(tableName, date);

            this.dbConnection.RunSqlCommand(sqlCommand, this.settingsProvider.GetDbConnectionString());
            this.DoUpdate(fileNames, tableName);
        }

        public void UpdateDays(string tableName, string filePrefix)
        {
            var fileName = this
                .azureStorage
                .GetAllFiles("mesiraziun", filePrefix)
                .Single();

            var deleteSqlCommand = new SqlCreator().CreateDelete(tableName);
            this.dbConnection.RunSqlCommand(deleteSqlCommand, this.settingsProvider.GetDbConnectionString());

            var text = this.azureStorage.GetCsvAsString(fileName);
            var entries = this.dataTableCreator.CreateDaysEntry(text);

            foreach(var day in entries)
            {
                Console.WriteLine("Start insert day info {0}", day.Datum);
                var sqlCommand = new SqlCreator().Create(tableName, day);
                this.dbConnection.RunSqlCommand(sqlCommand, this.settingsProvider.GetDbConnectionString());
                Console.WriteLine("Finish insert day info {0}", day.Datum);
            }
        }

        public void UpdateMonth(string tableName, string filePrefix)
        {
            var fileName = this
                .azureStorage
                .GetAllFiles("mesiraziun", filePrefix)
                .Single();

            var deleteSqlCommand = new SqlCreator().CreateDelete(tableName);
            this.dbConnection.RunSqlCommand(deleteSqlCommand, this.settingsProvider.GetDbConnectionString());

            var text = this.azureStorage.GetCsvAsString(fileName);
            var entries = this.dataTableCreator.CreateMonthsEntry(text);

            foreach (var month in entries)
            {
                Console.WriteLine("Start insert month info {0}", month.Datum);
                var sqlCommand = new SqlCreator().Create(tableName, month);
                this.dbConnection.RunSqlCommand(sqlCommand, this.settingsProvider.GetDbConnectionString());
                Console.WriteLine("Finish insert day info month {0}", month.Datum);
            }
        }

        public void UpdateYear(string tableName, string filePrefix)
        {
            var fileName = this
                .azureStorage
                .GetAllFiles("mesiraziun", filePrefix)
                .Single();

            var deleteSqlCommand = new SqlCreator().CreateDelete(tableName);
            this.dbConnection.RunSqlCommand(deleteSqlCommand, this.settingsProvider.GetDbConnectionString());

            var text = this.azureStorage.GetCsvAsString(fileName);
            var entries = this.dataTableCreator.CreateYearsEntry(text);

            foreach (var year in entries)
            {
                Console.WriteLine("Start insert month info {0}", year.Datum);
                var sqlCommand = new SqlCreator().Create(tableName, year);
                this.dbConnection.RunSqlCommand(sqlCommand, this.settingsProvider.GetDbConnectionString());
                Console.WriteLine("Finish insert day info month {0}", year.Datum);
            }
        }

        private void DoUpdate(IEnumerable<string> fileNames, string tableName)
        {
            foreach (var fileName in fileNames)
            {
                var text = this.azureStorage.GetCsvAsString(fileName);

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
                this.dbConnection.RunSqlCommand(sqlCommand, this.settingsProvider.GetDbConnectionString());
            }
        }
    }
}