using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lib_dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface ILibros_AutoresAplicacion
    {
        void Configurar(string StringConexion);
        List<Libros_Autores> Listar(); 
        Libros_Autores? Guardar(Libros_Autores? entidad);
        Libros_Autores? Modificar(Libros_Autores? entidad);
        Libros_Autores? Borrar(Libros_Autores? entidad);
    }
}
