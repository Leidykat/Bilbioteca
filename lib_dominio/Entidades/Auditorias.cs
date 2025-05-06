using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Auditorias
    {

        public int id { get; set; }
        public DateTime fecha { get; set; }
        public string? tabla { get; set; }
        public string? referencia { get; set; }//SERIA EL ID 
        public string? accion { get; set; }

        public string? usuarios { get; set; } //ESTO SI DEBE IR 

       

    }
}
