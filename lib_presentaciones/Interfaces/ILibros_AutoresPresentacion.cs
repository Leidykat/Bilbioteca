using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IAutoresPresentacion
    {
        Task<List<Autores>> Listar();
        Task<Autores?> Guardar(Autores? entidad);
        Task<Autores?> Modificar(Autores? entidad);
        Task<Autores?> Borrar(Autores? entidad);
    }
}