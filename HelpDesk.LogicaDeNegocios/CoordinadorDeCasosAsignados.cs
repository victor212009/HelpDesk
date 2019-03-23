using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.Model;

namespace HelpDesk.LogicaDeNegocios
{
    public class CoordinadorDeCasosAsignados
    {
        public Boolean Asignar(Model.CasoEmpleadoAsignado elCaso)
        {
            if (ObtenerCasosAsignadosAunEmpleado(elCaso.IdEmpleados).Count < 2)
            {
                AccesoAdatos.GestorDeCasosAsignados gestor = new AccesoAdatos.GestorDeCasosAsignados();
                gestor.Asignar(elCaso);
                return true;
            }
            else
                return false;

        }

        public List<Model.Casos> ObtenerCasosAsignadosAunEmpleado(int idEmpleado)
        {
            AccesoAdatos.GestorDeCasosAsignados gestor = new AccesoAdatos.GestorDeCasosAsignados();
            LogicaDeNegocios.CoordinadorDeCasos coordinadorDeCasos = new CoordinadorDeCasos();

            List<Model.Casos> listaDeCasosAsignados = new List<Model.Casos>();

            List<CasoEmpleadoAsignado> casosAsignados = gestor.ObtenerCasosPorEmpleado(idEmpleado);

            foreach (CasoEmpleadoAsignado casoAsignado in casosAsignados)
            {
                Casos caso = coordinadorDeCasos.ObtenerCasoPorId(casoAsignado.IdCasos);

                if (caso.Estado == (int)Estado.EnProceso)
                {
                    listaDeCasosAsignados.Add(caso);
                }
            }

            return listaDeCasosAsignados;
        }

        public List<Model.CasoEmpleadoAsignado> ObtenerCasoAsignadoPorIdCaso(int idCaso)
        {
            AccesoAdatos.GestorDeCasosAsignados gestor = new AccesoAdatos.GestorDeCasosAsignados();
            LogicaDeNegocios.CoordinadorDeCasos coordinadorDeCasos = new CoordinadorDeCasos();

            List<Model.CasoEmpleadoAsignado> listaDeCasosAsignados = new List<Model.CasoEmpleadoAsignado>();

            List<CasoEmpleadoAsignado> casosAsignados = gestor.ObtenerCasoAsignadoPorIdCaso(idCaso);

            foreach (CasoEmpleadoAsignado casoAsignado in casosAsignados)
            {
                Casos caso = coordinadorDeCasos.ObtenerCasoPorId(casoAsignado.IdCasos);

                if (caso.Estado == (int)Estado.EnProceso)
                {
                    listaDeCasosAsignados.Add(casoAsignado);
                }
            }

            return listaDeCasosAsignados;
        }

        public List<Model.Casos> ObtenerHistorialDeCasosDeUnEmpleado(int idEmpleado)
        {
            AccesoAdatos.GestorDeCasosAsignados gestor = new AccesoAdatos.GestorDeCasosAsignados();
            LogicaDeNegocios.CoordinadorDeCasos coordinadorDeCasos = new CoordinadorDeCasos();

            List<Model.Casos> historialDeCasosAsignados = new List<Model.Casos>();
            List<CasoEmpleadoAsignado> historial = gestor.ObtenerCasosPorEmpleado(idEmpleado);

            foreach (CasoEmpleadoAsignado casoEnHistorial in historial)
            {
                Casos caso = coordinadorDeCasos.ObtenerCasoPorId(casoEnHistorial.IdCasos);
                
                    historialDeCasosAsignados.Add(caso);
            }

            return historialDeCasosAsignados;
        }
    }
}
