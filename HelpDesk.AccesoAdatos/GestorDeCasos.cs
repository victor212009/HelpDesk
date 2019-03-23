using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace HelpDesk.AccesoAdatos
{
    public class GestorDeCasos
    {

        public void Agregar(Model.Casos elNuevoCaso)
        {
            ContextoDeHelpDesk db = new ContextoDeHelpDesk();
            db.Casos.Add(elNuevoCaso);
            db.Entry(elNuevoCaso).State = System.Data.Entity.EntityState.Added;
            
            db.SaveChanges();
        }

        public void Actualizar(Model.Casos caso)
        {
            Model.Casos valorBD = ObtenerCasoPorId(caso.Id);
            var db = new ContextoDeHelpDesk();

            valorBD.DescripcionProblema = caso.DescripcionProblema;
            valorBD.DescripcionResolucion = caso.DescripcionResolucion;
            valorBD.DireccionContacto = caso.DireccionContacto;
            valorBD.Estado = caso.Estado;
            valorBD.FechaCreacion = caso.FechaCreacion;
            valorBD.FechaInicioProceso = caso.FechaInicioProceso;
            valorBD.FechaResolucion = caso.FechaResolucion;
            valorBD.Id = caso.Id;
            valorBD.MotivoRechazo = caso.MotivoRechazo;
            valorBD.Nivel = caso.Nivel;
            valorBD.NombreContacto = caso.NombreContacto;
            valorBD.ObservacionesResolucion = caso.ObservacionesResolucion;
            valorBD.ProvinciaContacto = caso.ProvinciaContacto;
            valorBD.TelefonoContacto = caso.TelefonoContacto;

            db.Entry(caso).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

        }

        public List<Model.Casos> ObtenerCasosPorNivel(int nivel)
        {
            var db = new ContextoDeHelpDesk();

            var resultado = from c in db.Casos
                            where c.Nivel.Equals(nivel)
                            select c;

            return resultado.ToList();
        }

        public List<Model.Casos> ObtenerCasosPorEstado(int estado)
        {
            var db = new ContextoDeHelpDesk();

            var resultado = from c in db.Casos
                            where c.Estado.Equals(estado)
                            select c;

            return resultado.ToList();
        }

        public List<Model.Casos> ObtenerTodosLosCasos()
        {
            var db = new ContextoDeHelpDesk();
            var resultado = db.Casos.ToList();

            return resultado;
        }

        public Model.Casos ObtenerCasoPorId(int Id)
        {
            var db = new ContextoDeHelpDesk();
            var resultado = db.Casos.Find(Id);

            return resultado;
        }

    }
}
