using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lib_dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface IGenerosAplicacion
    {
        void Configurar(string StringConexion);
        List<Generos> PorUsuario(Generos? entidad);
        List<Generos> Listar(); Generos? Guardar(Generos? entidad);
        Generos? Modificar(Generos? entidad);
        Generos? Borrar(Generos? entidad);
    }
}
