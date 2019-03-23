using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.LogicaDeNegocios
{
    public class CoordinadorDeEmpleados
    {
        public void Agregar(Model.Empleados elNuevoEmpleado)
        {
            AccesoAdatos.GestorDeEmpleados gestor = new AccesoAdatos.GestorDeEmpleados();
            
            gestor.Agregar(elNuevoEmpleado);
        }

        public void Editar(Model.Empleados elEmpleado)
        {
            AccesoAdatos.GestorDeEmpleados gestor = new AccesoAdatos.GestorDeEmpleados();

                gestor.Actualizar(elEmpleado);
            
        }

        public Model.Empleados ObtenerEmpleadoPorId(int id)
        {
            AccesoAdatos.GestorDeEmpleados gestor = new AccesoAdatos.GestorDeEmpleados();

            return gestor.ObtenerEmpleadoPorId(id);
        }

        public List<Model.Empleados> ObtenerTodosLosEmpleados()
        {
            AccesoAdatos.GestorDeEmpleados gestor = new AccesoAdatos.GestorDeEmpleados();

            return gestor.ObtenerTodosLosEmpleados();
        }
    }
}
