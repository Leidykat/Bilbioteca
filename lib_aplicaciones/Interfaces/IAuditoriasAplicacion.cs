using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_aplicaciones.Interfaces
{
    public interface IAuditoriasAplicacion
    {
        void Configurar(string StringConexion); 
        List<Auditorias> PorTabla(Auditorias? entidad); 
        List<Auditorias> Listar(); 

    }
}
