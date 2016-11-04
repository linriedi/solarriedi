using Linus.SolarRiedi.ConnectionWrapper.Contracts;
using System;
using System.Data.SqlClient;

namespace Linus.SolarRiedi.DbConnectionService
{
    public class ConnectionService : IDbConnection
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
    }
}
