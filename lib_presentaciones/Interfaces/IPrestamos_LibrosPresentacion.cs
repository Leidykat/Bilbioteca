using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IPrestamos_LibrosPresentacion
    {
        Task<List<Prestamos_Libros>> Listar();
        Task<Prestamos_Libros?> Guardar(Prestamos_Libros? entidad);
        Task<Prestamos_Libros?> Modificar(Prestamos_Libros? entidad);
        Task<Prestamos_Libros?> Borrar(Prestamos_Libros? entidad);
    }
}