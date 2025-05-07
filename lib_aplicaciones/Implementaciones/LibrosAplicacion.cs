using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class LibrosAplicacion : ILibrosAplicacion
    {
        private IConexion? IConexion = null;
        public LibrosAplicacion(IConexion iConexion)

        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Libros? Borrar(Libros? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.id == 0)
                throw new Exception("lbNoSeGuardo");

            this.IConexion!.Libros!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Libros? Guardar(Libros? entidad)
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

            this.IConexion!.Libros!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Libros> Listar()
        {
            return this.IConexion!.Libros!.Take(20).ToList();
        }

        public List<Libros> PorUsuario(Libros? entidad)
        {
            return this.IConexion!.Libros!.Where(x => x.titulo!.Contains(entidad!.titulo!)).ToList();
        }

        public Libros? Modificar(Libros? entidad)
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

            var entry = this.IConexion!.Entry<Libros>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }

}
