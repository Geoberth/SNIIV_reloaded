using System;
using System.ComponentModel.DataAnnotations;
namespace sniiv.Models
{
	public class c_organismo
	{
		[Key] [StringLength(10)] public string clave { get; set; }
		public int id_grupo_organismo { get; set; }
		[StringLength(50)] public string siglas { get; set; }
		public string descripcion { get; set; }
	}
}
