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