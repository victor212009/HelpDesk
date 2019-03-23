using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace HelpDesk.UI.Controllers
{
    public class CasosController : Controller
    {

        // GET: Casos/Edicion
        public ActionResult Index()
        {
            LogicaDeNegocios.CoordinadorDeCasos coordinadorDeCasos = new LogicaDeNegocios.CoordinadorDeCasos();
            List<Models.ModeloCasos> listaDeCasosRegistrados = new List<Models.ModeloCasos>();

            List<Model.Casos> listaDeCasosEnEstadoRegistrado = coordinadorDeCasos.ObtenerCasosEnEstadoRegistrado();

            foreach (Model.Casos caso in listaDeCasosEnEstadoRegistrado)
            {
                Models.ModeloCasos model = new Models.ModeloCasos();
                model.Id = caso.Id;
                model.Estado = caso.Estado;
                model.FechaCreacion = caso.FechaCreacion;
                model.NombreContacto = caso.NombreContacto;
                model.TelefonoContacto = caso.TelefonoContacto;
                model.Nivel = caso.Nivel;

                listaDeCasosRegistrados.Add(model);
            }

            return View(listaDeCasosRegistrados);
        }

        // GET: Casos/Eliminados
        public ActionResult Eliminados()
        {
            LogicaDeNegocios.CoordinadorDeCasos coordinadorDeCasos = new LogicaDeNegocios.CoordinadorDeCasos();

            List<Model.Casos> listaDeCasosEnEstadoEliminado = coordinadorDeCasos.ObtenerCasosEnEstadoEliminado();

            return View(listaDeCasosEnEstadoEliminado);
        }

        // GET: Casos/EnProceso
        public ActionResult EnProceso()
        {
            LogicaDeNegocios.CoordinadorDeCasos coordinadorDeCasos = new LogicaDeNegocios.CoordinadorDeCasos();
            LogicaDeNegocios.CoordinadorDeEmpleados coordinadorDeEmpleados = new LogicaDeNegocios.CoordinadorDeEmpleados();
            LogicaDeNegocios.CoordinadorDeCasosAsignados coordinadorDeCasosAsignados = new LogicaDeNegocios.CoordinadorDeCasosAsignados();
            Models.ModeloCasos model = new Models.ModeloCasos();

            List<Models.ModeloCasos> listaModel = new List<Models.ModeloCasos>();
            List<Model.CasoEmpleadoAsignado> lista = new List<Model.CasoEmpleadoAsignado>();
            List<Model.Casos> listaDeCasosEnEstadoEnProceso = coordinadorDeCasos.ObtenerCasosEnEstadoEnProceso();

            foreach (Model.Casos caso in listaDeCasosEnEstadoEnProceso)
            {
                List<Model.CasoEmpleadoAsignado> casosAsignados = coordinadorDeCasosAsignados.ObtenerCasoAsignadoPorIdCaso(caso.Id);

                if (casosAsignados.Last()!= null)
                {
                    Model.Empleados empleado = coordinadorDeEmpleados.ObtenerEmpleadoPorId(casosAsignados.Last().IdEmpleados);

                    model.Id = caso.Id;
                    model.Estado = caso.Estado;
                    model.FechaCreacion = caso.FechaCreacion;
                    model.NombreContacto = caso.NombreContacto;
                    model.TelefonoContacto = caso.TelefonoContacto;
                    model.Nivel = caso.Nivel;
                    model.Identificacion = empleado.Identificacion;
                }
                listaModel.Add(model);
            }

            return View(listaModel);
        }

        // GET: Casos/Expirados
        public ActionResult Expirados()
        {
            LogicaDeNegocios.CoordinadorDeCasos coordinadorDeCasos = new LogicaDeNegocios.CoordinadorDeCasos();

            List<Model.Casos> listaDeCasosQueSobrepasanTiempoDeAtencion = coordinadorDeCasos.ObtenerCasosQueExcedenTiempoParaPasarAenProceso();

            return View(listaDeCasosQueSobrepasanTiempoDeAtencion);
        }

        // GET: Casos/Create
        public ActionResult Crear()
        {
            Models.ModeloCasos model = new Models.ModeloCasos();

            LogicaDeNegocios.CoordinadorDeCasos coordinador = new LogicaDeNegocios.CoordinadorDeCasos();


            List<int> listaDeNiveles = new List<int>();
            listaDeNiveles = coordinador.ObtenerNivelesDeCriticidad();

            List<int> listaDeProvincias = new List<int>();
            listaDeProvincias = coordinador.ObtenerProvincias();
            
            model.ListaDeNivelesDeCriticidad = listaDeNiveles;
            model.ListaDeProvincias = listaDeProvincias;

            return View(model);
        }

        // POST: Casos/Create
        [HttpPost]
        public ActionResult Crear(Model.Casos caso)
        {
            try
            {
                // TODO: Add insert logic here

                LogicaDeNegocios.CoordinadorDeCasos coordinador = new LogicaDeNegocios.CoordinadorDeCasos();

                DateTime FechaCreacionDelCaso = DateTime.Now;
                caso.FechaCreacion = FechaCreacionDelCaso;

                coordinador.Agregar(caso);

                return RedirectToAction("Edicion");
            }
            catch
            {
                return View();
            }
        }

        // GET: Casos/Edit/5
        public ActionResult Editar(int id)
        {

            LogicaDeNegocios.CoordinadorDeCasos coordinador = new LogicaDeNegocios.CoordinadorDeCasos();

            Model.Casos caso = coordinador.ObtenerCasoPorId(id);
            Models.ModeloCasos model = new Models.ModeloCasos();

            model.DescripcionProblema = caso.DescripcionProblema;
            model.DireccionContacto = caso.DireccionContacto;
            model.Nivel = caso.Nivel;
            model.NombreContacto = caso.NombreContacto;
            model.ProvinciaContacto = caso.ProvinciaContacto;
            model.TelefonoContacto = caso.TelefonoContacto;

            List<int> listaDeNiveles = new List<int>();
            listaDeNiveles = coordinador.ObtenerNivelesDeCriticidad();

            List<int> listaDeProvincias = new List<int>();
            listaDeProvincias = coordinador.ObtenerProvincias();

            model.ListaDeNivelesDeCriticidad = listaDeNiveles;
            model.ListaDeProvincias = listaDeProvincias;

            if (caso==null)
                return HttpNotFound ();

            else
                return View(model);
        }

        // POST: Casos/Edit/5
        [HttpPost]
        public ActionResult Editar(int id, Model.Casos caso)
        {
            try
            {
                // TODO: Add update logic here
                LogicaDeNegocios.CoordinadorDeCasos coordinador = new LogicaDeNegocios.CoordinadorDeCasos();
                Model.Casos elCaso = coordinador.ObtenerCasoPorId(id);

                elCaso.DescripcionProblema = caso.DescripcionProblema;
                elCaso.DireccionContacto = caso.DireccionContacto;
                elCaso.Nivel = caso.Nivel;
                elCaso.NombreContacto = caso.NombreContacto;
                elCaso.ProvinciaContacto = caso.ProvinciaContacto;
                elCaso.TelefonoContacto = caso.TelefonoContacto;

                coordinador.Editar(elCaso);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Persona/Delete/5
        public ActionResult Eliminar(int id)
        {
            LogicaDeNegocios.CoordinadorDeCasos coordinador = new LogicaDeNegocios.CoordinadorDeCasos();
            Model.Casos caso;

            caso = coordinador.ObtenerCasoPorId(id);

            return View(caso);
        }

        // POST: Persona/Delete/5
        [HttpPost]
        public ActionResult Eliminar(int id, Model.Casos caso)
        {
            try
            {
                // TODO: Add delete logic here
                LogicaDeNegocios.CoordinadorDeCasos coordinador = new LogicaDeNegocios.CoordinadorDeCasos();

                coordinador.Eliminar(id);

                return RedirectToAction("Edicion");
            }
            catch
            {
                return View();
            }
        }

        // GET: Persona/Delete/5
        public ActionResult Reactivar(int id)
        {
            LogicaDeNegocios.CoordinadorDeCasos coordinador = new LogicaDeNegocios.CoordinadorDeCasos();
            Model.Casos caso;

            caso = coordinador.ObtenerCasoPorId(id);

            return View(caso);
        }

        // POST: Persona/Delete/5
        [HttpPost]
        public ActionResult Reactivar(int id, Model.Casos caso)
        {
            try
            {
                // TODO: Add delete logic here
                LogicaDeNegocios.CoordinadorDeCasos coordinador = new LogicaDeNegocios.CoordinadorDeCasos();

                coordinador.Reactivar(id);

                return RedirectToAction("Edicion");
            }
            catch
            {
                return View();
            }
        }

        // GET: Persona/Delete/5
        public ActionResult Rechazar(int id)
        {
            LogicaDeNegocios.CoordinadorDeCasos coordinador = new LogicaDeNegocios.CoordinadorDeCasos();
            Model.Casos caso;

            caso = coordinador.ObtenerCasoPorId(id);

            return View(caso);
        }

        // POST: Persona/Delete/5
        [HttpPost]
        public ActionResult Rechazar(int id, Model.Casos caso)
        {
            try
            {
                // TODO: Add delete logic here
                LogicaDeNegocios.CoordinadorDeCasos coordinador = new LogicaDeNegocios.CoordinadorDeCasos();
                Model.Casos elCaso = coordinador.ObtenerCasoPorId(id);

                elCaso.MotivoRechazo = caso.MotivoRechazo;

                coordinador.Rechazar(elCaso);

                return RedirectToAction("EnProceso");
            }
            catch
            {
                return View();
            }
        }

        // GET: Persona/Delete/5
        public ActionResult Terminar(int id)
        {
            LogicaDeNegocios.CoordinadorDeCasos coordinador = new LogicaDeNegocios.CoordinadorDeCasos();
            Model.Casos caso;

            caso = coordinador.ObtenerCasoPorId(id);

            return View(caso);
        }

        // POST: Persona/Delete/5
        [HttpPost]
        public ActionResult Terminar(int id, Model.Casos caso)
        {
            try
            {
                // TODO: Add delete logic here
                LogicaDeNegocios.CoordinadorDeCasos coordinador = new LogicaDeNegocios.CoordinadorDeCasos();
                Model.Casos elCaso = coordinador.ObtenerCasoPorId(id);

                elCaso.DescripcionResolucion = caso.DescripcionResolucion;

                coordinador.Terminar(caso);

                return RedirectToAction("EnProceso");
            }
            catch
            {
                return View();
            }
        }
        
        // GET: Persona/Delete/5
        public ActionResult PonerEnProceso(int id)
        {
            Models.ModeloCasos model = new Models.ModeloCasos();
            LogicaDeNegocios.CoordinadorDeEmpleados coordinadorDeEmpleados = new LogicaDeNegocios.CoordinadorDeEmpleados();
            LogicaDeNegocios.CoordinadorDeCasos coordinadorDeCasos = new LogicaDeNegocios.CoordinadorDeCasos();

            Model.Casos caso = coordinadorDeCasos.ObtenerCasoPorId(id);
            List<Model.Empleados> empleados = coordinadorDeEmpleados.ObtenerTodosLosEmpleados();

            model.Id = caso.Id;
            model.ListaDeEmpleados = empleados;
            return View(model);
        }

        [HttpPost]
        public ActionResult PonerEnProceso(int id, Models.ModeloCasos empleado)
        {
            try
            {
                // TODO: Add delete logic here
                LogicaDeNegocios.CoordinadorDeCasos coordinadorDeCasos = new LogicaDeNegocios.CoordinadorDeCasos();
                LogicaDeNegocios.CoordinadorDeEmpleados coordinadorDeEmpleados = new LogicaDeNegocios.CoordinadorDeEmpleados();

                Model.Empleados elEmpleado = coordinadorDeEmpleados.ObtenerEmpleadoPorId(empleado.IdEmpleado);

                Boolean sehaPodidoPonerEnProcesoElCaso = coordinadorDeCasos.PonerEnProceso(id, elEmpleado.Id);

                if (sehaPodidoPonerEnProcesoElCaso)
                    return RedirectToAction("Edicion");

                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

    }
}
