using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
namespace sniiv.Models
{
    public class datos_abiertos_bak
    {
        [Key] public int id { get; set; }
        public int anio { get; set; }
        public int mes { get; set; }
        public string url { get; set; }
        public string tipo { get; set; }
        public int formato { get; set; }
    }
}