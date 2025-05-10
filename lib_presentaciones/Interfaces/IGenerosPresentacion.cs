using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IGenerosPresentacion
    {
        Task<List<Generos>> Listar();
        Task<List<Generos>> PorUsuario(Generos? entidad);
        Task<Generos?> Guardar(Generos? entidad);
        Task<Generos?> Modificar(Generos? entidad);
        Task<Generos?> Borrar(Generos? entidad);
    }
}