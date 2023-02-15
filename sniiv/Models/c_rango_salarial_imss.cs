using System;
using System.ComponentModel.DataAnnotations;
namespace sniiv.Models
{
	public class c_rango_salarial_imss
	{
		[Key] [StringLength(10)] public string clave {get; set;}
		[StringLength(50)] public string descripcion {get; set;}
		public int id_rango_salarial_conavi {get; set;}
	}
}
