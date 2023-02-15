using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace sniiv.Models
{
    public class reporte_mensual
    {
        [Key]public int id { get; set; }
        public int anio { get; set; }
        public int mes { get; set; }
        public string url { get; set; }
    }
}
