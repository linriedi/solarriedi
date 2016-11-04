using Linus.SolarRiedi.BackEnd.DataAccess.Contracts;
using Linus.SolarRiedi.DBConnection.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Linus.SolarRiedi.BackEnd.Contracts;

namespace Linus.SolarRiedi.BackEnd.DataAccess
{
    public class DataAccess : IDataAccess
    {
        private readonly IRunSqlCommand runSqlCommand;

        public DataAccess(IRunSqlCommand runSqlCommand)
        {
            this.runSqlCommand = runSqlCommand;
        }

        public IEnumerable<MonthDto> GetAllMonthMeasurements()
        {
            var sqlCommand = "Select * from meins";
            var entires = this.runSqlCommand.Select(sqlCommand, "***");

            var dtos = new List<MonthDto>();
            foreach (var entry in entires)
            {
                var datumEntry = entry.First();
                var prd = entry.ToList()[1];

                var value = int.Parse(datumEntry);
                var month = value % 100;
                var year = (value - month) / 100;

                dtos.Add(new MonthDto { Month = month, Year = year, Producziun = int.Parse(prd)});
            }
            return dtos;
        }
    }
}
