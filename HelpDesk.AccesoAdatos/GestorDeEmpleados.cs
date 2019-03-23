using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace HelpDesk.AccesoAdatos
{
    public class GestorDeEmpleados
    {

        public void Agregar(Model.Empleados elNuevoEmpleado)
        {
            var db = new ContextoDeHelpDesk();
            db.Empleados.Add(elNuevoEmpleado);
            db.Entry(elNuevoEmpleado).State = System.Data.Entity.EntityState.Added;

            db.SaveChanges();
        }

        public void Actualizar(Model.Empleados empleado)
        {
            var db = new ContextoDeHelpDesk();

            db.Entry(empleado).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

        }

        public Model.Empleados ObtenerEmpleadoPorId(int Id)
        {
            var db = new ContextoDeHelpDesk();
            var resultado = db.Empleados.Find(Id);

            return resultado;
        }

        public List<Model.Empleados> ObtenerTodosLosEmpleados()
        {
            var db = new ContextoDeHelpDesk();
            var resultado = db.Empleados.ToList();

            return resultado;
        }
    }
}
