using System;
using System.ComponentModel.DataAnnotations;
namespace sniiv.Models
{
	public class demanda_potencial_infonavit
	{
		[Key] public int id { get; set; }
		public int anio { get; set; }
		public int mes { get; set; }
		[StringLength(10)] public string clave_entidad_federativa { get; set; }
		[StringLength(10)] public string clave_municipio { get; set; }
		public int id_salario_infonavit { get; set; }
		public int? valor { get; set; }
	}
}

