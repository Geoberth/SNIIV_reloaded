using System;
using System.ComponentModel.DataAnnotations;

namespace sniiv.Models
{
    public class pnv_informes
    {
		[Key] public int id { get; set; }
		public int anio { get; set; }
		public int trimestre { get; set; }
		public string url { get; set; }
	}
}

