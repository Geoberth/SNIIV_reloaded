using System;
using System.ComponentModel.DataAnnotations;
namespace sniiv.Models
{
	public class c_genero
	{
		[Key] public int id {get; set;}
		[StringLength(25)] public string descripcion {get; set;}
		[StringLength(10)] public string alias {get; set;}
	}
}
