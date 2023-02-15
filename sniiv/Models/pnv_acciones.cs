using System;
using System.ComponentModel.DataAnnotations;
namespace sniiv.Models
{
	public class pnv_acciones
	{
		[Key] public int id { get; set; }
		public int anio { get; set; }
		public int trimestre { get; set; }
		public int objetivo { get; set; }
		public int total_compartidas { get; set; }
		public int estatus { get; set; }
	}
}

