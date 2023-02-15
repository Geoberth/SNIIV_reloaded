using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UsuarioVO
/// </summary>
public class DocumentoVO
{
    private int _id;
    private string _original;
    private string _propuesta;
   

    public int id {
        get { return _id; }
        set { _id = value; }
    }

    public string original {
        get { return _original; }
        set { _original = value; }
    }

    public string propuesta {
        get { return _propuesta; }
        set { _propuesta = value; }
    }

    public DocumentoVO()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DocumentoVO(int id, string original, string propuesta)
    {
        _id = id;
        _original = original;
        _propuesta = propuesta;
    }
}