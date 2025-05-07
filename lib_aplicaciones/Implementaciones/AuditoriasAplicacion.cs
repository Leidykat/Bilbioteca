using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class AuditoriasAplicacion : IAuditoriasAplicacion
    {
        private IConexion? IConexion = null;
        public AuditoriasAplicacion(IConexion iConexion)

        { 
            this.IConexion = iConexion; 
        }

        public void Configurar(string StringConexion) 
        { 
            this.IConexion!.StringConexion = StringConexion; 
        }

        public Auditorias? Borrar(Auditorias? entidad)
        {
            if (entidad == null) 
                throw new Exception("lbFaltaInformacion");

            if (entidad!.id == 0) 
                throw new Exception("lbNoSeGuardo");

            this.IConexion!.Auditorias!.Remove(entidad); 
            this.IConexion.SaveChanges(); 
            return entidad;
        }

        public Auditorias? Guardar(Auditorias? entidad)
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

            this.IConexion!.Auditorias!.Add(entidad); 
            this.IConexion.SaveChanges(); 
            return entidad;
        }

        public List<Auditorias> Listar() 
        { 
            return this.IConexion!.Auditorias!.Take(20).ToList(); 
        }

        public List<Auditorias> PorUsuario(Auditorias? entidad) 
        { 
            return this.IConexion!.Auditorias!.Where(x => x.Usuarios!.Contains(entidad!.Usuarios!)).ToList(); 
        }

        public Auditorias? Modificar(Auditorias? entidad)
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

            var entry = this.IConexion!.Entry<Auditorias>(entidad); 
            entry.State = EntityState.Modified; 
            this.IConexion.SaveChanges(); 
            return entidad;
        }
    }
}
