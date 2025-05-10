using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface ILibrosPresentacion
    {
        Task<List<Libros>> Listar();
        Task<List<Libros>> PorUsuario(Libros? entidad);
        Task<Libros?> Guardar(Libros? entidad);
        Task<Libros?> Modificar(Libros? entidad);
        Task<Libros?> Borrar(Libros? entidad);
    }
}