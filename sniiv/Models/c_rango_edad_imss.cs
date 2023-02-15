using System;
using System.ComponentModel.DataAnnotations;
namespace sniiv.Models
{
	public class c_rango_edad_imss
	{
		[Key] [StringLength(10)] public string clave {get; set;}
		public int edad_inicio {get; set;}
		public int edad_fin {get; set;}
		[StringLength(50)] public string descripcion {get; set;}
		public int id_rango_edad_conavi {get; set;}
		[StringLength(50)] public string abreviacion {get; set;}
	}
}
