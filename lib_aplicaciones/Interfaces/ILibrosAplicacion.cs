using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lib_dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface ILibrosAplicacion
    {
        void Configurar(string StringConexion);
        List<Libros> PorUsuario(Libros? entidad);
        List<Libros> Listar(); Libros? Guardar(Libros? entidad);
        Libros? Modificar(Libros? entidad);
        Libros? Borrar(Libros? entidad);
    }
}
