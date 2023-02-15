using System;
using System.ComponentModel.DataAnnotations;
namespace sniiv.Models
{
	public class pnv_objetivos
	{
		[Key] public int id { get; set; }
		[StringLength(25)] public string organismo { get; set; }
		public int anio { get; set; }
		public int trimestre { get; set; }
		public int tipo_objetivo { get; set; }
		public int total { get; set; }
		public int concluida { get; set; }
		public int en_proceso { get; set; }
		public int sin_realizar { get; set; }
		public int por_iniciar { get; set; }
	}
}

