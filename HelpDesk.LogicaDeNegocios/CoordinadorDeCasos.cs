using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using HelpDesk.Model;

namespace HelpDesk.LogicaDeNegocios
{
    public class CoordinadorDeCasos
    {
        public void Agregar(Model.Casos elNuevoCaso)
        {
            AccesoAdatos.GestorDeCasos gestor = new AccesoAdatos.GestorDeCasos();

            elNuevoCaso.Estado = (int)Estado.Registrado;
            gestor.Agregar(elNuevoCaso);
        }

        public void Editar(Model.Casos elCaso)
        {
            AccesoAdatos.GestorDeCasos gestor = new AccesoAdatos.GestorDeCasos();

            if (elCaso.Estado == (int)Estado.Registrado || elCaso.Estado == (int)Estado.EnProceso)
            {
                gestor.Actualizar(elCaso);
            }
        }

        public void Eliminar(int id)
        {
            AccesoAdatos.GestorDeCasos gestor = new AccesoAdatos.GestorDeCasos();
            Casos caso = ObtenerCasoPorId(id);

            if (caso.Estado == (int)Estado.Registrado)
            {
            caso.Estado = (int)Estado.Eliminado;
            gestor.Actualizar(caso);
            }
        }

        public void Reactivar(int id)
        {
            AccesoAdatos.GestorDeCasos gestor = new AccesoAdatos.GestorDeCasos();
            Casos caso = ObtenerCasoPorId(id);

            if (caso.Estado == (int)Estado.Eliminado)
            {
                caso.Estado = (int)Estado.Registrado;
                caso.FechaCreacion = DateTime.Now;
                gestor.Actualizar(caso);
            }

        }

        public Boolean PonerEnProceso(int idCaso, int idEmpleado)
        {
            AccesoAdatos.GestorDeCasos gestor = new AccesoAdatos.GestorDeCasos();
            CasoEmpleadoAsignado casoAsignado = new CasoEmpleadoAsignado();
            CoordinadorDeCasosAsignados coordinadorDeCasosAsignados = new CoordinadorDeCasosAsignados();
            CoordinadorDeEmpleados coordinadorDeEmpleados = new CoordinadorDeEmpleados();

            Boolean seHaPodidoPonerEnProcesoElCaso = false;
            Boolean seHaPodidoAsignarElCaso = false;
            Casos elCaso = ObtenerCasoPorId(idCaso);
            Empleados elEmpleado = coordinadorDeEmpleados.ObtenerEmpleadoPorId(idEmpleado);

            if (!ExcedeTiempoParaPonerEnProceso(elCaso))
            {
                if (elCaso.Estado == (int)Estado.Registrado) {

                    casoAsignado.IdCasos = elCaso.Id;
                    casoAsignado.IdEmpleados = elEmpleado.Id;
                    elCaso.Estado = (int)Estado.EnProceso;
                    elCaso.FechaInicioProceso = DateTime.Now;

                    seHaPodidoAsignarElCaso = coordinadorDeCasosAsignados.Asignar(casoAsignado);

                    if (seHaPodidoAsignarElCaso)
                    {
                        gestor.Actualizar(elCaso);
                        seHaPodidoPonerEnProcesoElCaso = true;
                    } 
                    
                }
            }
            return (seHaPodidoAsignarElCaso && seHaPodidoPonerEnProcesoElCaso);
        }

        public void PonerEnProceso(int v, Empleados empleado)
        {
            throw new NotImplementedException();
        }

        public void Rechazar(Model.Casos caso)
        {
            AccesoAdatos.GestorDeCasos gestor = new AccesoAdatos.GestorDeCasos();

            if (caso.Estado == (int)Estado.EnProceso)
            {
                caso.Estado = (int)Estado.Rechazado;
                gestor.Actualizar(caso);
            }
        }

        public void Terminar(Model.Casos elCaso)
        {
            AccesoAdatos.GestorDeCasos gestor = new AccesoAdatos.GestorDeCasos();

            if (elCaso.Estado == (int)Estado.EnProceso)
            {
                elCaso.FechaResolucion = DateTime.Now;
                elCaso.Estado = (int)Estado.Terminado;
                gestor.Actualizar(elCaso);
            }
        }

        public List<int> ObtenerNivelesDeCriticidad()
        {
            List<int> listaDeNiveles = new List<int>();

            listaDeNiveles.Add((int)NivelDeCriticidad.Bajo);
            listaDeNiveles.Add((int)NivelDeCriticidad.Medio);
            listaDeNiveles.Add((int)NivelDeCriticidad.Alto);

            return listaDeNiveles;
        }

        public List<int> ObtenerProvincias()
        {
            List<int> listaDeProvincias = new List<int>();

            listaDeProvincias.Add((int)Provincia.SanJose);
            listaDeProvincias.Add((int)Provincia.Alajuela);
            listaDeProvincias.Add((int)Provincia.Cartago);
            listaDeProvincias.Add((int)Provincia.Heredia);
            listaDeProvincias.Add((int)Provincia.Guanacaste);
            listaDeProvincias.Add((int)Provincia.Puntarenas);
            listaDeProvincias.Add((int)Provincia.Limon);

            return listaDeProvincias;
        }

        public Model.Casos ObtenerCasoPorId(int id)
        {
            AccesoAdatos.GestorDeCasos gestor = new AccesoAdatos.GestorDeCasos();

            return gestor.ObtenerCasoPorId(id);
        }

        public List<Model.Casos> ObtenerCasosEnEstadoRegistrado()
        {
            AccesoAdatos.GestorDeCasos gestor = new AccesoAdatos.GestorDeCasos();

            return gestor.ObtenerCasosPorEstado((int)Estado.Registrado);
        }

        public List<Model.Casos> ObtenerCasosEnEstadoEnProceso()
        {
            AccesoAdatos.GestorDeCasos gestor = new AccesoAdatos.GestorDeCasos();

            return gestor.ObtenerCasosPorEstado((int)Estado.EnProceso);
        }

        public List<Model.Casos> ObtenerCasosEnEstadoEliminado()
        {
            AccesoAdatos.GestorDeCasos gestor = new AccesoAdatos.GestorDeCasos();

            return gestor.ObtenerCasosPorEstado((int)Estado.Eliminado);
        }

        public List<Model.Casos> ObtenerCasosQueExcedenTiempoParaPasarAenProceso()
        {
            AccesoAdatos.GestorDeCasos gestor = new AccesoAdatos.GestorDeCasos();

            List<Model.Casos> casosQueExcedenTiempoParaPasarAenProceso = new List<Model.Casos>();
            List<Model.Casos> laListaDeCasos = gestor.ObtenerTodosLosCasos();

            foreach (Casos caso in laListaDeCasos)
            {
            if (ExcedeTiempoParaPonerEnProceso(caso))
            {
                    if (caso.Estado == (int)Estado.Registrado)
                    casosQueExcedenTiempoParaPasarAenProceso.Add(caso);
            }
            }

            return casosQueExcedenTiempoParaPasarAenProceso;
        }

        public Boolean ExcedeTiempoParaPonerEnProceso(Model.Casos elCaso)
        {
            DateTime horaActual = DateTime.Now;

            if (((horaActual - elCaso.FechaCreacion).Hours > 1 && elCaso.Nivel == 1)
              || ((horaActual - elCaso.FechaCreacion).Hours > 4 && elCaso.Nivel == 2)
              || ((horaActual - elCaso.FechaCreacion).Hours > 1 && elCaso.Nivel == 3))
                return true;
            else
                return false;
        }
    }
}
