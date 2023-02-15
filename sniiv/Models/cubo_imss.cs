using System;
using System.ComponentModel.DataAnnotations;
namespace sniiv.Models
{
	public class cubo_imss
	{
		public int id {get; set;}
		public int anio {get; set;}
		public int mes {get; set;}
		[StringLength(10)] public string clave_entidad_federativa {get; set;}
		[StringLength(10)] public string clave_municipio {get; set;}
		public int id_sector_economico_1 {get; set;}
		public int id_genero {get; set;}
		[StringLength(10)] public string clave_rango_edad {get; set;}
		[StringLength(10)] public string clave_rango_salarial {get; set;}
		public int trabajadores {get; set;}
	}
}
