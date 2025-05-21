using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_aplicaciones.Implementaciones
{
    public class PrestamosAplicacion : IPrestamosAplicacion
    {
        private IConexion? IConexion = null;
        public PrestamosAplicacion(IConexion iConexion) 

        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Prestamos? Borrar(Prestamos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.id == 0)
                throw new Exception("lbNoSeGuardo");

            this.IConexion!.Prestamos!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Prestamos? Guardar(Prestamos? entidad)
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

            this.IConexion!.Prestamos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Prestamos> Listar()
        {
            return this.IConexion!.Prestamos!.Take(20).ToList();
        }

        public List<Prestamos> PorCodigo(Prestamos? entidad)
        {
            Console.WriteLine("AP´li");
            return this.IConexion!.Prestamos!.Where(x => x.codigo!.Contains(entidad!.codigo!)).ToList();
        }

        public Prestamos? Modificar(Prestamos? entidad)
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

            var entry = this.IConexion!.Entry<Prestamos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
