using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class EvaluacionVO
{
    public int id_criterio_evaluacion { get; set; }
    public int id_evaluador { get; set; }
    public int id_proyecto { get; set; }
    public int valor { get; set; }
    public string descripcion { get; set; }
}