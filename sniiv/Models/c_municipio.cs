using System;
using System.ComponentModel.DataAnnotations;

namespace sniiv.Models
{
	public class c_municipio
	{
		[Key] [StringLength(10)] public string clave_entidad_federativa { get; set; }
		[Key] [StringLength(10)] public string clave_mun { get; set; }
		public string descripcion { get; set; }
		[StringLength(50)] public string ambito { get; set; }
		[StringLength(50)] public string poblacion_indigena { get; set; }
		public Boolean municipio_fronterizo { get; set; }
	}
}
