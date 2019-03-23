using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelpDesk.UI.Controllers
{
    public class EmpleadosController : Controller
    {
        // GET: Empleados
        public ActionResult Index()
        {
            LogicaDeNegocios.CoordinadorDeEmpleados coordinadorDeEmpleados = new LogicaDeNegocios.CoordinadorDeEmpleados();

            List<Model.Empleados> listaDeEmpleados = coordinadorDeEmpleados.ObtenerTodosLosEmpleados();

            return View(listaDeEmpleados);
        }

        public ActionResult CasosAsignados(int id)
        {
            LogicaDeNegocios.CoordinadorDeCasosAsignados coordinadorDeCasosAsignados = new LogicaDeNegocios.CoordinadorDeCasosAsignados();
            LogicaDeNegocios.CoordinadorDeCasos coordinadorDeCasos = new LogicaDeNegocios.CoordinadorDeCasos();

            List<Model.Casos> listaDeCasosAsignadosAunEmpleado = coordinadorDeCasosAsignados.ObtenerCasosAsignadosAunEmpleado(id);

            return View(listaDeCasosAsignadosAunEmpleado);
        }

        public ActionResult HistorialDeCasosAsignados(int id)
        {
            LogicaDeNegocios.CoordinadorDeCasosAsignados coordinadorDeCasosAsignados = new LogicaDeNegocios.CoordinadorDeCasosAsignados();
            LogicaDeNegocios.CoordinadorDeCasos coordinadorDeCasos = new LogicaDeNegocios.CoordinadorDeCasos();

            List<Model.Casos> HistorialDeCasosAsignadosAunEmpleado = coordinadorDeCasosAsignados.ObtenerHistorialDeCasosDeUnEmpleado(id);

            return View(HistorialDeCasosAsignadosAunEmpleado);
        }

        // GET: Empleados/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Empleados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empleados/Create
        [HttpPost]
        public ActionResult Create(Model.Empleados empleado)
        {
            try
            {
                // TODO: Add insert logic here
                LogicaDeNegocios.CoordinadorDeEmpleados coordinadorDeEmpleados = new LogicaDeNegocios.CoordinadorDeEmpleados();

                coordinadorDeEmpleados.Agregar(empleado);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Empleados/Edit/5
        public ActionResult Editar(int id)
        {

            LogicaDeNegocios.CoordinadorDeEmpleados coordinadorDeEmpleados = new LogicaDeNegocios.CoordinadorDeEmpleados();

            Model.Empleados empleado = coordinadorDeEmpleados.ObtenerEmpleadoPorId(id);

            if (empleado == null)
                return HttpNotFound();

            else
                return View(empleado);
        }

        // POST: Empleados/Edit/5
        [HttpPost]
        public ActionResult Editar(int id, Model.Empleados empleado)
        {
            try
            {
                // TODO: Add update logic here
                LogicaDeNegocios.CoordinadorDeEmpleados coordinador = new LogicaDeNegocios.CoordinadorDeEmpleados();
                Model.Empleados elEmpleado = coordinador.ObtenerEmpleadoPorId(id);

                elEmpleado.Identificacion = empleado.Identificacion;
                elEmpleado.Nombre = empleado.Nombre;
                elEmpleado.Apellidos = empleado.Apellidos;

                coordinador.Editar(elEmpleado);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Empleados/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Empleados/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
