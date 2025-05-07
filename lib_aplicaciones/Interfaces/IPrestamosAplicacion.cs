using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_aplicaciones.Interfaces
{
    public interface IPrestamosAplicacion
    {
        void Configurar(string StringConexion);
        List<Prestamos> PorCodigo(Prestamos? entidad);
        List<Prestamos> Listar();
        Prestamos? Guardar(Prestamos? entidad);
        Prestamos? Modificar(Prestamos? entidad);
        Prestamos? Borrar(Prestamos? entidad);
    }
}
