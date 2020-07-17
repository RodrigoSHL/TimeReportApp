using Dominio;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistencia
{
    public class TimeReportContext : IdentityDbContext<Usuario>
    {
        public TimeReportContext(DbContextOptions options) : base(options){

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProyectoEtapa>().HasKey(ci => new {ci.ProyectoId, ci.EtapaId});
        }
        public DbSet<Proyecto> Proyecto{get;set;}
        public DbSet<TimeReport> TimeReport{get;set;}
        public DbSet<ProyectoEtapa> ProyectoEtapa{get;set;}
        public DbSet<Etapa> Etapa{get;set;}
        public DbSet<Cliente> Cliente{get;set;}
        public DbSet<Documento> Documento {get;set;}
        
    }
}