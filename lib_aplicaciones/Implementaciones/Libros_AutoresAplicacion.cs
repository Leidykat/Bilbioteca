using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class Libros_AutoresAplicacion : ILibros_AutoresAplicacion
    {
        private IConexion? IConexion = null;
        public Libros_AutoresAplicacion(IConexion iConexion)

        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Libros_Autores? Borrar(Libros_Autores? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.id == 0)
                throw new Exception("lbNoSeGuardo");

            this.IConexion!.Libros_Autores!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Libros_Autores? Guardar(Libros_Autores? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.id != 0)
                throw new Exception("lbYaSeGuardo");

            /*entidad!.NotaFinal = 
                (entidad.Nota1 + 
                entidad.Nota2 + 
                entidad.Nota3 + 
                entidad.Nota4 + 
                entidad.Nota5) / 5;*/

            this.IConexion!.Libros_Autores!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Libros_Autores> Listar()
        {
            return this.IConexion!.Libros_Autores!.Take(20).ToList();
        }
     

        public Libros_Autores? Modificar(Libros_Autores? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.id == 0)
                throw new Exception("lbNoSeGuardo");

            /*entidad!.NotaFinal =
                (entidad.Nota1 + 
                entidad.Nota2 + 
                entidad.Nota3 + 
                entidad.Nota4 + 
                entidad.Nota5) / 5;
            CALCULOS
            */

            var entry = this.IConexion!.Entry<Libros_Autores>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

    }
}
