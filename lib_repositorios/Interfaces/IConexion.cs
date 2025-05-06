using lib_dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace lib_repositorios.Interfaces
{
    public interface IConexion
    {
        string? StringConexion { get; set; }

        DbSet<Editoriales>? Editoriales { get; set; }
        DbSet<Generos>? Generos { get; set; }
        DbSet<Autores>? Autores { get; set; }
        DbSet<Roles>? Roles { get; set; }
        DbSet<Usuarios>? Usuarios { get; set; }
        DbSet<Libros>? Libros { get; set; }
        DbSet<Prestamos>? Prestamos { get; set; }
        DbSet<Prestamos_Libros>? Prestamos_Libros { get; set; }
        DbSet<Libros_Autores>? Libros_Autores { get; set; }
        DbSet<Libros_Generos>? Libros_Generos { get; set; }
        DbSet<Auditorias>? Auditorias { get; set; }

        EntityEntry<T> Entry<T>(T entity) where T : class;

      
        int SaveChanges();
    }
}