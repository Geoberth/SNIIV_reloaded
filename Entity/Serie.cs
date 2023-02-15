using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Descripción breve de SeriesVO
/// </summary>
[DataContract]
public class Serie
{
    [DataMember(EmitDefaultValue = false)]
    public int id { get; set; }
    [DataMember]
    public string name { get; set; }
    [DataMember]
    public List<Data> data { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string type { get; set; }
    [DataMember(EmitDefaultValue = false)]
    public string stack { get; set; }

    public Serie()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
        name = string.Empty;
        data = new List<Data>();
    }
    public Serie(string _name, List<Data> _data)
    {
        name = _name;
        data = _data;
    }

    public Serie(int _id, string _name, List<Data> _data)
    {
        id = _id;
        name = _name;
        data = _data;
    }

    public Serie(string _name, List<Data> _data, string _type, string _stack)
    {
        name = _name;
        data = _data;
        type = _type;
        stack = _stack;
    }
}