using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccessData
{
    public class SqlHelper
    {
        public static string ConexionDB;

        public static NpgsqlConnection GetConnection()
        {
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(ConexionDB);
                return connection;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static string connectionString;
    }
}
