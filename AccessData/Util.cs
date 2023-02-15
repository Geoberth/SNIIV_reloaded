using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;
//using Microsoft.AspNetCore.Hosting;


/// <summary>
/// Descripción breve de Util
/// </summary>
public class Util
{
    private static Util _instancia = null;

    public static Util instancia()
    {
        return _instancia == null ? new Util() : _instancia;
    }

    public Util()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public string getLeyendaFecha(DateTime fecha) {
        return "Al " + fecha.Day + " de " + getMes(fecha.Month) + " de " + fecha.Year;
    }

    public string getMes(int mes) {
        string nombreMes = string.Empty;
        switch (mes) {
            case 1:
                nombreMes = "enero";
                break;
            case 2:
                nombreMes = "febrero";
                break;
            case 3:
                nombreMes = "marzo";
                break;
            case 4:
                nombreMes = "abril";
                break;
            case 5:
                nombreMes = "mayo";
                break;
            case 6:
                nombreMes = "junio";
                break;
            case 7:
                nombreMes = "julio";
                break;
            case 8:
                nombreMes = "agosto";
                break;
            case 9:
                nombreMes = "septiembre";
                break;
            case 10:
                nombreMes = "octubre";
                break;
            case 11:
                nombreMes = "noviembre";
                break;
            case 12:
                nombreMes = "diciembre";
                break;
        }
        return nombreMes;
    }

    public string getTrimestre(int trimestre)
    {
        string nombreTrimestre = string.Empty;
        switch (trimestre)
        {
            case 1:
                nombreTrimestre = "enero - marzo";
                break;
            case 2:
                nombreTrimestre = "abril - junio";
                break;
            case 3:
                nombreTrimestre = "julio - septiembre";
                break;
            case 4:
                nombreTrimestre = "octubre - diciembre";
                break;
            case 5:
                nombreTrimestre = "Último Trimestre";
                break;
        }
        return nombreTrimestre;
    }

    public void setLogError(Exception ex)
    {
        StringBuilder message = new StringBuilder();
        message.Append(string.Format("Date: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")));
        message.Append(Environment.NewLine);
        message.Append(string.Format("Message: {0}", ex.Message));
        message.Append(Environment.NewLine);
        message.Append(string.Format("StackTrace: {0}", ex.StackTrace));
        message.Append(Environment.NewLine);
        message.Append(string.Format("Source: {0}", ex.Source));
        message.Append(Environment.NewLine);
        message.Append(string.Format("TargetSite: {0}", ex.TargetSite.ToString()));
        message.Append(Environment.NewLine);
        message.Append("-----------------------------------------------------------");
        message.Append(Environment.NewLine);
        Log.Error(ex,message.ToString());
        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "ErrorLog.txt");
        using (StreamWriter writer = new StreamWriter(path, true))
        {
            writer.WriteLine(message.ToString());
            writer.Close();
        }
    }

    /*public void setLogError(Exception ex)
    {
        StringBuilder message = new StringBuilder();
        message.Append(string.Format("Date: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")));
        message.Append(Environment.NewLine);
        message.Append(string.Format("Message: {0}", ex.Message));
        message.Append(Environment.NewLine);
        message.Append(string.Format("StackTrace: {0}", ex.StackTrace));
        message.Append(Environment.NewLine);
        message.Append(string.Format("Source: {0}", ex.Source));
        message.Append(Environment.NewLine);
        message.Append(string.Format("TargetSite: {0}", ex.TargetSite.ToString()));
        message.Append(Environment.NewLine);
        message.Append("-----------------------------------------------------------");
        message.Append(Environment.NewLine);
        string path = HttpContext.Current.Server.MapPath("~/ErrorLog.txt");
        using (StreamWriter writer = new StreamWriter(path, true))
        {
            writer.WriteLine(message.ToString());
            writer.Close();
        }
    }*/

    /*public void setLogText(string text)
    {
        StringBuilder message = new StringBuilder();
        message.Append(string.Format("Date: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")));
        message.Append(Environment.NewLine);
        message.Append(string.Format("Message: {0}", text));
        message.Append(Environment.NewLine);
        message.Append("-----------------------------------------------------------");
        message.Append(Environment.NewLine);
        string path = HttpContext.Current.Server.MapPath("~/ErrorLog.txt");
        using (StreamWriter writer = new StreamWriter(path, true))
        {
            writer.WriteLine(message.ToString());
            writer.Close();
        }
    }*/

    public List<T> ConvertDataTable<T>(DataTable dt)
    {
        List<T> data = new List<T>();
        foreach (DataRow row in dt.Rows)
        {
            T item = GetItem<T>(row);
            data.Add(item);
        }
        return data;
    }
    private static T GetItem<T>(DataRow dr)
    {
        Type temp = typeof(T);
        T obj = Activator.CreateInstance<T>();
        foreach (DataColumn column in dr.Table.Columns)
        {
            foreach (PropertyInfo pro in temp.GetProperties())
            {
                if (pro.Name == column.ColumnName)
                    pro.SetValue(obj, dr[column.ColumnName], null);
                else
                    continue;
            }
        }
        return obj;
    }

    public int getRandomNumber(int max)
    {
        Random random = new Random();
        return random.Next(max);
    }
}