using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lib_dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface IAutoresAplicacion
    {
        void Configurar(string StringConexion);
        List<Autores> PorUsuario(Autores? entidad);
        List<Autores> Listar(); Autores? Guardar(Autores? entidad);
        Autores? Modificar(Autores? entidad);
        Autores? Borrar(Autores? entidad);
    }
}
