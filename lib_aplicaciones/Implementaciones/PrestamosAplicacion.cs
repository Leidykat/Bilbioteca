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
            GuardarAuditoria("Borrar Prestamos");
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Prestamos? Guardar(Prestamos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.id != 0)
                throw new Exception("lbYaSeGuardo");

            this.IConexion!.Prestamos!.Add(entidad);
            GuardarAuditoria("Guardar Prestamos");
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Prestamos> Listar()
        {
            GuardarAuditoria("Listar Prestamos");
            return this.IConexion!.Prestamos!.Take(20).Include(x => x._usuarios).ToList();
        }

        public List<Prestamos> PorCodigo(Prestamos? entidad)
        {
            return this.IConexion!.Prestamos!.Where(x => x.codigo!.Contains(entidad!.codigo!)).Include(x => x._usuarios).ToList();
        }

        public Prestamos? Modificar(Prestamos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.id == 0)
                throw new Exception("lbNoSeGuardo");

            var entry = this.IConexion!.Entry<Prestamos>(entidad);
            entry.State = EntityState.Modified;
            GuardarAuditoria("Modificar Prestamos");
            this.IConexion.SaveChanges();
            return entidad;
        }
        public void GuardarAuditoria(string? accion)
        {
            var conexion = this.IConexion!.Auditorias;
            var entidad = new Auditorias()
            {
                accion = accion,
                tabla = "Prestamos",
                fecha = DateTime.Now
            };
            this.IConexion.Auditorias!.Add(entidad);
            this.IConexion.SaveChanges();
        }
    }
}
