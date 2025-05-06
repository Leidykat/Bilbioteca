using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_aplicaciones.Interfaces
{
    public interface ILibros_GenerosAplicacion
    {
        void Configurar(string StringConexion);
        List<Libros_Generos> Listar();
        Libros_Generos? Guardar(Libros_Generos? entidad);
        Libros_Generos? Modificar(Libros_Generos? entidad);
        Libros_Generos? Borrar(Libros_Generos? entidad);
    }
}
