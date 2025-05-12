using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface ILibros_AutoresPresentacion
    {
        Task<List<Libros_Autores>> Listar();
        Task<Libros_Autores?> Guardar(Libros_Autores? entidad);
        Task<Libros_Autores?> Modificar(Libros_Autores? entidad);
        Task<Libros_Autores?> Borrar(Libros_Autores? entidad);
    }
}