using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.Model;

namespace HelpDesk.AccesoAdatos
{
    public class GestorDeCasosAsignados
    {
        public void Asignar(Model.CasoEmpleadoAsignado elCaso)
        {
            var db = new ContextoDeHelpDesk();
            db.CasoEmpleadoAsignado.Add(elCaso);
            db.Entry(elCaso).State = System.Data.Entity.EntityState.Added;

            db.SaveChanges();
        }

        public List<Model.CasoEmpleadoAsignado> ObtenerCasosPorEmpleado(int idEmpleado)
        {
            var db = new ContextoDeHelpDesk();

            var resultado = from c in db.CasoEmpleadoAsignado
                            where c.IdEmpleados.Equals(idEmpleado)
                            select c;

            return resultado.ToList();
        }

        public List<Model.CasoEmpleadoAsignado> ObtenerCasoAsignadoPorIdCaso(int idCaso)
        {
            var db = new ContextoDeHelpDesk();

            var resultado = from c in db.CasoEmpleadoAsignado
                            where c.IdCasos.Equals(idCaso)
                            select c;

            return resultado.ToList();
        }

        public List<Model.CasoEmpleadoAsignado> ObtenerTodosLosCasos()
        {
            var db = new ContextoDeHelpDesk();
            var resultado = db.CasoEmpleadoAsignado.ToList();

            return resultado;
        }
    }
}
