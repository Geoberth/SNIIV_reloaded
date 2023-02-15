using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CatalogoVO
/// </summary>
public class CatalogoVO
{
    public string id { get; set; }
    public string descripcion  { get; set; }

    public CatalogoVO()
    {
        id = string.Empty;
        descripcion = string.Empty;
    }
}