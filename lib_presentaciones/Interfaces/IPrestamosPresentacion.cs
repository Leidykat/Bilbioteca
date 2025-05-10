using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IPrestamosPresentacion
    {
        Task<List<Prestamos>> Listar();
        Task<List<Prestamos>> PorCodigo(Prestamos? entidad);
        Task<Prestamos?> Guardar(Prestamos? entidad);
        Task<Prestamos?> Modificar(Prestamos? entidad);
        Task<Prestamos?> Borrar(Prestamos? entidad);
    }
}