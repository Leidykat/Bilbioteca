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
            GuardarAuditoria("Borrar Libro");
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Libros? Guardar(Libros? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.id != 0)
                throw new Exception("lbYaSeGuardo");


            this.IConexion!.Libros!.Add(entidad);
            GuardarAuditoria("Guardar Libro");
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Libros> Listar()
        {
            GuardarAuditoria("Listar Libro");
            return this.IConexion!.Libros!.Take(20).Include(x => x._id_editoriales).ToList();
        }

        public List<Libros> PorUsuario(Libros? entidad)
        {
            return this.IConexion!.Libros!.Where(x => x.titulo!.Contains(entidad!.titulo!)).Include(x => x._id_editoriales).ToList();
        }

        public Libros? Modificar(Libros? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.id == 0)
                throw new Exception("lbNoSeGuardo");

            var entry = this.IConexion!.Entry<Libros>(entidad);
            entry.State = EntityState.Modified;
            GuardarAuditoria("Modificar Libro");
            this.IConexion.SaveChanges();
            return entidad;
        }

        public void GuardarAuditoria(string? accion)
        {
            var conexion = this.IConexion!.Auditorias;
            var entidad = new Auditorias()
            {
                accion = accion,
                tabla = "Libros",
                fecha = DateTime.Now
            };
            this.IConexion.Auditorias!.Add(entidad);
            this.IConexion.SaveChanges();
        }
    }

}
