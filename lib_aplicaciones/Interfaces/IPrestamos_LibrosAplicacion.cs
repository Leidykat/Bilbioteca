using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_aplicaciones.Interfaces
{
    public interface IPrestamos_LibrosAplicacion
    {
        void Configurar(string StringConexion);
        List<Prestamos_Libros> Listar(); 
        Prestamos_Libros? Guardar(Prestamos_Libros? entidad);
        Prestamos_Libros? Modificar(Prestamos_Libros? entidad);
        Prestamos_Libros? Borrar(Prestamos_Libros? entidad);
    }
}
