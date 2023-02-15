using System;
using System.ComponentModel.DataAnnotations;

namespace sniiv.Models
{
	public class demanda_potencial_7_9
	{
		public string ent { get; set; }
		public string mun { get; set; }
		public int? hasta_2_7_uma { get; set; }
		public int? de_2_71_a_4_1_uma { get; set; }
		public int? de_4_11_a_5_8_uma { get; set; }
		public int? de_5_81_a_9_0_uma { get; set; }
		public int? mayor_a_9_uma { get; set; }
		public int total_general { get; set; }
		public int anio { get; set; }
		public int mes { get; set; }
		[StringLength(10)] public string cve_ent { get; set; }
		[StringLength(10)] public string cve_mun { get; set; }
		[Key] public int id { get; set; }
	}
}
