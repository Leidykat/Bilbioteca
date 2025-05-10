using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IEditorialesPresentacion
    {
        Task<List<Editoriales>> Listar();
        Task<List<Editoriales>> PorCodigo(Editoriales? entidad);
        Task<Editoriales?> Guardar(Editoriales? entidad);
        Task<Editoriales?> Modificar(Editoriales? entidad);
        Task<Editoriales?> Borrar(Editoriales? entidad);
    }
}