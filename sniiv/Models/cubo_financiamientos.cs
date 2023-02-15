using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sniiv.Models
{
	public class cubo_financiamientos
	{
		[Column(TypeName = "bigint")]
		public int id { get; set; }
		public int anio { get; set; }
		public int mes { get; set; }
		[StringLength(10)] public string clave_estado { get; set; }
		[StringLength(10)] public string clave_municipio { get; set; }
		[Key] [StringLength(10)] public string clave_organismo { get; set; }
		public int id_grupo_organismo { get; set; }
		public int id_modalidad { get; set; }
		public int id_tipo_credito { get; set; }
		public int id_destino_credito { get; set; }
		public int id_genero { get; set; }
		public int id_rango_edad { get; set; }
		public int id_rango_salarial { get; set; }
		public int id_valor_vivienda { get; set; }
		public int id_vivienda_sustentable { get; set; }
		public Decimal monto { get; set; }
		public int acciones { get; set; }
	}
}
