using System;
using System.ComponentModel.DataAnnotations;
namespace sniiv.Models
{
	public class c_tipo_credito
	{
		[Key] public int id { get; set; }
		public int id_modalidad { get; set; }
		[StringLength(50)] public string descripcion { get; set; }
		[StringLength(50)] public string descripcion_inicial { get; set; }
	}
}

