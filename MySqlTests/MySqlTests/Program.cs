using MySql.Data.MySqlClient;
using System;

namespace MySqlTests
{
    class Program
    {
        static void Main(string[] args)
        {
            string connStr = "server=server47.hostfactory.ch;user=solarRiedi;database=solarRiediDB;port=3306;password=*****;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                //string sql = "SELECT Name, HeadOfState FROM Country WHERE Continent='Oceania'";
                //MySqlCommand cmd = new MySqlCommand(sql, conn);
                //MySqlDataReader rdr = cmd.ExecuteReader();

                //while (rdr.Read())
                //{
                //    Console.WriteLine(rdr[0] + " -- " + rdr[1]);
                //}

                string sql = "CREATE TABLE solarRiediDB.Messungen (Zeit varchar(50) DEFAULT NULL, Leistung varchar(50))";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");
        }
    }
}
