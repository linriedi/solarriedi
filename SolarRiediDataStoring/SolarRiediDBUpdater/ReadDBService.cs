using Common;
using Linus.SolarRiedi.ConnectionWrapper.Contracts;
using Linus.SolarRiedi.Settings.Contracts;
using Linus.SolarRiedi.SolarRiediDBUpdater.Contracs;
using System.Collections.Generic;

namespace Linus.SolarRiedi.SolarRiediDBUpdater
{
    public class ReadDBService : IReadDBService
    {
        private readonly IDbConnection dbConnection;
        private readonly ISettingsProvider settingsProvider;

        public ReadDBService(IDbConnection dbConnection, ISettingsProvider settingsProvider)
        {
            this.settingsProvider = settingsProvider;
            this.dbConnection = dbConnection;
        }

        public IEnumerable<IEnumerable<string>> GetMeasurements(ReportDate date)
        {
            var formattetMonth = this.Format(date.Month);
            var formattetFromDay = this.Format(date.Day);
            var formattetToDay = this.Format(date.Day + 1);

            var from = string.Format("{0}{1}{2}0000", date.Year, formattetMonth, formattetFromDay);
            var to = string.Format("{0}{1}{2}0000", date.Year, formattetMonth, formattetToDay);

            var sqlCommand = string.Format("Select datum, pac_1, pac_2, pac_3, pac_4, pac_5, pac_6, pac_7 from minutas where datum >= {0} and datum < {1}", from, to);

            var table = this.dbConnection.Select(sqlCommand, this.settingsProvider.GetDbConnectionString());
            return table;
        }

        private string Format(int value)
        {
            if (value < 10)
            {
                return string.Format("0{0}", value);
            }

            return value.ToString();
        }
    }
}
