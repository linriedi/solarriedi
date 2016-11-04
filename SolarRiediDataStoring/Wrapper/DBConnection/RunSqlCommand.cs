using System;
using System.Data.SqlClient;
using Linus.SolarRiedi.DBConnection.Contracts;
using System.Collections.Generic;

namespace Linus.SolarRiedi.DBConnection
{
    public class RunSqlCommand : IRunSqlCommand
    {
        public IEnumerable<IEnumerable<string>> Select(string sqlCommand, string connectionString)
        {
            var list = new List<List<string>>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(sqlCommand, con))
                {
                    var test = command. ExecuteScalar();

                    command.CommandTimeout = 120;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var datum = reader["datum"].ToString();
                            var pro = reader["Psum_1"].ToString();
                            var entry = new List<string> {
                                datum,
                                pro
                            };
                            list.Add(entry);
                        }
                    }
                }
            }
            return list;
        }
    }
}
