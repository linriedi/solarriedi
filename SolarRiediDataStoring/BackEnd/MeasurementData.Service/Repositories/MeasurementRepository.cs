using Linus.SolarRiedi.BackEnd.Service.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Linus.SolarRiedi.BackEnd.Service.Repositories
{
    public class MeasurementRepository : IMeasurementRepository
    {
        public IEnumerable<IEnumerable<string>> GetMeasurements(ReportDate date)
        {
            var from = string.Format("{0}{1}{2}0000", date.YearAsString, date.MonthAsString, date.DayAsString);
            var to = string.Format("{0}{1}{2}0000", date.YearAsString, date.MonthAsString, date.DayPlusOneAsString);

            var sqlCommand = string.Format("Select datum, pac_1, pac_2, pac_3, pac_4, pac_5, pac_6, pac_7 from minutas where datum >= {0} and datum < {1}", from, to);

            return this.Select(sqlCommand, ConnectionString.Value);
        }

        public IEnumerable<IEnumerable<string>> GetMonthMeasurements(ReportDate date)
        {
            var from = string.Format("{0}{1}00", date.YearAsString, date.MonthAsString);
            var to = string.Format("{0}{1}00", date.YearAsString, date.MonthPlusOneAsString);

            var sqlCommand = string.Format("Select datum, Psum_0, Psum_1, Psum_2, Psum_3, Psum_4, Psum_5, Psum_6 from gis where datum >= {0} and datum < {1}", from, to);

            return this.Select(sqlCommand, ConnectionString.Value);
        }

        public IEnumerable<IEnumerable<string>> GetYearMeasurements()
        {
            var sqlCommand = string.Format("Select * from meins");
            return this.Select(sqlCommand, ConnectionString.Value);
        }

        private IEnumerable<IEnumerable<string>> Select(string sqlCommand, string connectionString)
        {
            var list = new List<List<string>>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(sqlCommand, con))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var entry = new List<string>();
                        var values = new object[reader.FieldCount];
                        reader.GetValues(values);
                        foreach (var value in values)
                        {
                            entry.Add(value.ToString());
                        }
                        list.Add(entry);
                    }
                }
            }
            return list;
        }
    }
}