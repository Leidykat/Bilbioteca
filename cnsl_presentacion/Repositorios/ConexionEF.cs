using lib_repositorios.Implementaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace cnsl_presentacion.Repositorios
{
    public class ConexionEF
    {
        private string string_conexion = "server=LAPTOP-I60OMVV2;database=db_Biblioteca;Integrated Security=True;TrustServerCertificate=true;";
        // server=localhost;database=db_clase12032025;uid=sa;pwd=Clas3sPrO2024_!;TrustServerCertificate=true;
        // server=localhost;database=db_clase12032025;Integrated Security=True;TrustServerCertificate=true;

        public void ConexionBasica()
        {
            var conexion = new Conexion();
            conexion.StringConnection = this.string_conexion;

            var lista = conexion.Libros.ToList();

            foreach (var elemento in lista)
            {
                Console.WriteLine(elemento.id.ToString() + ", " + elemento.titulo);
            }
        }
    }
}
