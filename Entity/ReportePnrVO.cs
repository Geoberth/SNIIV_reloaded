using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Descripción breve de ViviendaSustentableVO
/// </summary>
[DataContract]
public class  ReportePnrVO
{
    [DataMember]
    public List<listCMGVO> listCMG { get; set; }
    [DataMember]
    public List<listCMRVO> listCMR { get; set; }
    [DataMember]
    public List<listCMCAVO> listCMCA { get; set; }

    
public  ReportePnrVO()
    {
        listCMG = new List<listCMGVO>();
        listCMR = new List<listCMRVO>();
        listCMCA = new List<listCMCAVO>();
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
}