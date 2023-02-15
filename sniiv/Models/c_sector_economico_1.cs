using System;
using System.ComponentModel.DataAnnotations;
namespace sniiv.Models
{
	public class c_sector_economico_1
	{
		[Key] public int id {get; set;}
		public string descripcion {get; set;}
		public string etiqueta {get; set;}
	}
}
