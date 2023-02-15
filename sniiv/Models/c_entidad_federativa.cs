using System;
using System.ComponentModel.DataAnnotations;

namespace sniiv.Models
{
	public class c_entidad_federativa
	{
		[Key] [StringLength(10)] public string clave { get; set; }
		[StringLength(50)] public string descripcion { get; set; }
		[StringLength(10)] public string abreviacion { get; set; }
		public int id_region { get; set; }
	}
}
