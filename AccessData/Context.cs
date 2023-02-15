using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

class Context : IDisposable
{
    public MySqlConnection Connection;

    public Context(string connectionString)
    {
        Connection = new MySqlConnection(connectionString);
        this.Connection.Open();
    }

    public void Dispose()
    {
        Connection.Close();
    }
}
