using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface ILibros_GenerosPresentacion
    {
        Task<List<Libros_Generos>> Listar();
        Task<Libros_Generos?> Guardar(Libros_Generos? entidad);
        Task<Libros_Generos?> Modificar(Libros_Generos? entidad);
        Task<Libros_Generos?> Borrar(Libros_Generos? entidad);
    }
}