using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace sniiv.Models
{
    public class c_modulo
    {
        [Key] public int id { get; set; }
        [StringLength(80)] public string descripcion { get; set; }
        [StringLength(50)] public string url { get; set; }
        [StringLength(50)] public string ico { get; set; }
       
    }
}
