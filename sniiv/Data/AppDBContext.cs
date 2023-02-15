using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sniiv.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace sniiv.Data
{
    public class AppDBContext : IdentityDbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }


        //public DbSet<usuario> usuario { get; set; }
        public DbSet<c_entidad_federativa> c_entidad_federativa { get; set; }
        public DbSet<c_modalidad_sniiv> c_modalidad_sniiv { get; set; }
        public DbSet<c_modulo> c_modulo { get; set; }
        public DbSet<c_municipio> c_municipio { get; set; }
        public DbSet<c_organismo> c_organismo { get; set; }
        public DbSet<c_genero> c_genero { get; set; }
        public DbSet<c_rango_edad_imss> c_rango_edad_imss { get; set; }
        public DbSet<c_rango_salarial_imss> c_rango_salarial_imss { get; set; }
        public DbSet<c_sector_economico_1> c_sector_economico_1 { get; set; }
        public DbSet<cubo_imss> cubo_imss { get; set; }
        public DbSet<c_salario_infonavit> c_salario_infonavit { get; set; }
        public DbSet<c_tipo_credito> c_tipo_credito { get; set; }
        public DbSet<cubo_financiamientos> cubo_financiamientos { get; set; }
        public DbSet<cubo_imss_rpt> cubo_imss_rpt { get; set; }
        public DbSet<datos_abiertos> datos_abiertos{get;set; }
        public DbSet<demanda_potencial_7_9> demanda_potencial_7_9 { get; set; }
        public DbSet<demanda_potencial_infonavit> demanda_potencial_infonavit { get; set; }
        public DbSet<reporte_mensual> reporte_mensual { get; set; }
        public DbSet<rol_modulo> rol_modulo { get; set; }

        public DbSet<pnv_objetivos> pnv_objetivos { get; set; }

        public DbSet<pnv_acciones> pnv_acciones { get; set; }
        public DbSet<pnv_informes> pnv_informes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<cubo_financiamientos>().HasKey(entity => new { entity.id, entity.anio, entity.mes, entity.clave_organismo });
            modelBuilder.Entity<c_municipio>().HasKey(entity => new { entity.clave_entidad_federativa, entity.clave_mun });
            modelBuilder.Entity<rol_modulo>().HasNoKey();

        }
    }
}
