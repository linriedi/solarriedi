using System.Collections.Generic;
using System.Data.SqlClient;

namespace Linus.SolarRiedi.DbConnectionService
{
    public class ConnectionService : ConnectionWrapper.Contracts.IDbConnection
    {
        public void RunSqlCommand(string sqlCommand, string connectionString)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(sqlCommand, con))
                {
                    command.CommandTimeout = 120;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                    }
                }
            }
        }

        public IEnumerable<IEnumerable<string>> Select(string sqlCommand, string connectionString)
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
