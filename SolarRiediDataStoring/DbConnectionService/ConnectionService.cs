using Linus.SolarRiedi.ConnectionWrapper.Contracts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linus.SolarRiedi.DbConnectionService
{
    public class ConnectionService : IDbConnection
    {
        public void DeleteItemsInTable(string connectionString)
        {
            Console.WriteLine("Start DeleteItemsInTables");
            var tables = new List<string>
            {
                "mument",
                "consum",
                "producziunIn",
                "producziunDus",
                "producziunTreis",
                "producziunQuater",
                "producziunTschun",
                "producziunSis",
            };

            foreach(var table in tables)
            {
                Console.WriteLine("Start DeleteItemsIn table {0}", table);
                var deleteString = string.Format("Delete from {0}", table);
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand(deleteString, con))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                    }
                }
                Console.WriteLine("End DeleteItemsIn table {0}", table);
            }

            Console.WriteLine("End DeleteItemsInTables");
        }

        public void Insert(string insertString, string connectionString)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(insertString, con))
                {
                    command.CommandTimeout = 120;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                    }
                }
            }
        }

        public void Select(string sqlCommand, string connectionString)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(sqlCommand, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0} {1} {2}",
                        reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2));
                    }
                }
            }
        }
    }
}
