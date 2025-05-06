using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace lib_repositorios.Implementaciones
{
    public partial class Conexion : DbContext, IConexion
    {
        public string? StringConexion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConexion!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        public DbSet<Editoriales>? Editoriales { get; set; }
        public DbSet<Generos>? Generos { get; set; }
        public DbSet<Autores>? Autores { get; set; }
        public DbSet<Roles>? Roles { get; set; }
        public DbSet<Usuarios>? Usuarios { get; set; }
        public DbSet<Libros>? Libros { get; set; }
        public DbSet<Prestamos>? Prestamos { get; set; }
        public DbSet<Prestamos_Libros>? Prestamos_Libros { get; set; }
        public DbSet<Libros_Autores>? Libros_Autores { get; set; }
        public DbSet<Libros_Generos>? Libros_Generos { get; set; }
        public DbSet<Auditorias>? Auditorias { get; set; }


       
    }
}
