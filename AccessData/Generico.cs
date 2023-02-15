using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Npgsql;
using AccessData;
/// <summary>
/// Summary description for Generico
/// </summary>
public class Generico
{
    private static Generico _instancia = null;
    
    public static Generico instancia()
    {
        return _instancia == null ? new Generico() : _instancia;
    }

    public Generico()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable seleccionar(string query, string bdConexion)
    {
        //var cs = "Host=172.16.119.14;Port=5435;Username=sniiv_usr;Password=yA#tZFf9;Database=sniiv";
        //var cs = "Host=172.16.41.69;Port=5432;Username=developer;Password=dev;Database=sniiv_local";
        
        using var con = new NpgsqlConnection(SqlHelper.connectionString);
        con.Open();
        using var cmd = new NpgsqlCommand(query, con);
        NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    /*public DataTable seleccionar(string query, string bdConexion)
    {
        SqlDataSource conexion = new SqlDataSource();
        conexion.ConnectionString = ConfigurationManager.ConnectionStrings[bdConexion].ToString();
        conexion.ProviderName = ConfigurationManager.ConnectionStrings[bdConexion].ProviderName;
        conexion.SelectCommand = query;
        DataView dv = (DataView)conexion.Select(DataSourceSelectArguments.Empty);
        return dv.Table;
    }*/

    // Pendiente : retornar valores para DML

    /*public void insertar(string query, string bdConexion)
    {
        SqlDataSource conexion = new SqlDataSource();
        conexion.ConnectionString = ConfigurationManager.ConnectionStrings[bdConexion].ToString();
        conexion.ProviderName = ConfigurationManager.ConnectionStrings[bdConexion].ProviderName;
        conexion.InsertCommand = query;
        conexion.Insert();
    }

    public void actializar(string query, string bdConexion)
    {
        SqlDataSource conexion = new SqlDataSource();
        conexion.ConnectionString = ConfigurationManager.ConnectionStrings[bdConexion].ToString();
        conexion.ProviderName = ConfigurationManager.ConnectionStrings[bdConexion].ProviderName;
        conexion.UpdateCommand = query;
        conexion.Update();
    }

    public void eliminar(string query, string bdConexion)
    {
        SqlDataSource conexion = new SqlDataSource();
        conexion.ConnectionString = ConfigurationManager.ConnectionStrings[bdConexion].ToString();
        conexion.ProviderName = ConfigurationManager.ConnectionStrings[bdConexion].ProviderName;
        conexion.DeleteCommand = query;
        conexion.Delete();
    }

    public Boolean ejecutar(string query, string bdConexion)
    {
        Boolean respuesta = true;
        using (MySqlConnection conexion = new MySqlConnection(WebConfigurationManager.ConnectionStrings[bdConexion].ConnectionString))
        {
            MySqlCommand command = new MySqlCommand(query, conexion);
            conexion.Open();
            try { command.ExecuteNonQuery(); }
            catch { respuesta = false; }
        }
        return respuesta;
    }*/

    public void insertar(string query, string bdConexion) { }

    public void actializar(string query, string bdConexion) { }

    public void eliminar(string query, string bdConexion) { }
}