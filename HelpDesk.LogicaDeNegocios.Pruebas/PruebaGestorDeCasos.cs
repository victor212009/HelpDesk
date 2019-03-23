using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using HelpDesk.Model;

namespace HelpDesk.LogicaDeNegocios.Pruebas
{
    [TestClass]
    public class PruebaGestorDeCasos
    {
        [TestMethod]
        public void DebePermitirAgregarUnNuevoCaso()
        {
            LogicaDeNegocios.CoordinadorDeCasos coordinador = new LogicaDeNegocios.CoordinadorDeCasos();
            Model.Casos caso = new Model.Casos();
            
            caso.DescripcionProblema = "Descripcion del caso";
            caso.Nivel = (int)NivelDeCriticidad.Bajo;
            
            DateTime Hoy = DateTime.Now;
            caso.FechaCreacion = Hoy;

            caso.NombreContacto = "carlos";
            caso.TelefonoContacto = "88888888";
            caso.ProvinciaContacto = (int)Provincia.Guanacaste;
            caso.DireccionContacto = "Cañas";

            coordinador.Agregar(caso);
        }

        [TestMethod]
        public void DebePermitirEditarUnCaso()
        {
            LogicaDeNegocios.CoordinadorDeCasos coordinador = new LogicaDeNegocios.CoordinadorDeCasos();
            Model.Casos caso = coordinador.ObtenerCasoPorId(1);

            caso.DescripcionProblema = "Problema de violencia";
            caso.TelefonoContacto = "77777777";

            coordinador.Editar(caso);
        }

        [TestMethod]
        public void DebePermitirEliminarUnCaso()
        {
            LogicaDeNegocios.CoordinadorDeCasos coordinador = new LogicaDeNegocios.CoordinadorDeCasos();

            coordinador.Eliminar(1);
        }

        [TestMethod]
        public void DebePermitiPonerEnProcesoUnCaso()
        {
            LogicaDeNegocios.CoordinadorDeCasos coordinadorDeCasos = new LogicaDeNegocios.CoordinadorDeCasos();
            LogicaDeNegocios.CoordinadorDeEmpleados coordinadorDeEmpleados = new CoordinadorDeEmpleados();
            
            Model.Empleados empleado = coordinadorDeEmpleados.ObtenerEmpleadoPorId(1);

            coordinadorDeCasos.PonerEnProceso(1, empleado);
            
        }

        [TestMethod]
        public void DebePermitirRechazarUnCaso()
        {
            LogicaDeNegocios.CoordinadorDeCasos coordinador = new LogicaDeNegocios.CoordinadorDeCasos();
            Model.Casos caso = coordinador.ObtenerCasoPorId(3);

            caso.MotivoRechazo = "4";

            coordinador.Rechazar(caso);
        }

        [TestMethod]
        public void DebePermitirTerminarUnCaso()
        {
            LogicaDeNegocios.CoordinadorDeCasos coordinador = new LogicaDeNegocios.CoordinadorDeCasos();
            Model.Casos caso = coordinador.ObtenerCasoPorId(5);

            caso.DescripcionResolucion = "5";
            caso.ObservacionesResolucion = "5";
            caso.FechaResolucion = DateTime.Now;

            coordinador.Terminar(caso);
        }

        [TestMethod]
        public void DebePermitirMostrarListaDeCasos()
        {
            LogicaDeNegocios.CoordinadorDeCasos coordinador = new LogicaDeNegocios.CoordinadorDeCasos();

            List<Model.Casos> listaDeCasosRegistrados = coordinador.ObtenerCasosEnEstadoRegistrado();
            List<Model.Casos> listaDeCasosEnProceso = coordinador.ObtenerCasosEnEstadoEnProceso();
            List<Model.Casos> listaDeCasosTerminados = coordinador.ObtenerCasosEnEstadoTerminado();
            List<Model.Casos> listaDeCasosRechazados = coordinador.ObtenerCasosEnEstadoRechazado();
            List<Model.Casos> listaDeCasosEliminados = coordinador.ObtenerCasosEnEstadoEliminado();
            List<Model.Casos> listaDeCasosDeNivelBajo = coordinador.ObtenerCasosConNivelBajo();
            List<Model.Casos> listaDeCasosDeNivelMedio = coordinador.ObtenerCasosConNivelMedio();
            List<Model.Casos> listaDeCasosDeNivelAlto = coordinador.ObtenerCasosConNivelAlto();

            string casoEnEstadoRegistrado="";
            foreach (Casos caso in listaDeCasosRegistrados)
            {
                casoEnEstadoRegistrado += String.Format("Descripcion: {1}{0}"+
                    "Nivel de criticidad: {2}{0}" +
                    "Nombre de contacto: {3}{0}" +
                    "Direccion de contacto: {4}{0}" +
                    "Fecha de creacion: {5}{0}{0}",
                    Environment.NewLine,
                    caso.DescripcionProblema, caso.Nivel, caso.NombreContacto, caso.DireccionContacto, caso.FechaCreacion);
            }

            string casoEnEstadoEnProceso = "";
            foreach (Casos caso in listaDeCasosEnProceso)
            {
                casoEnEstadoEnProceso += String.Format("Descripcion: {1}{0}" +
                    "Nivel de criticidad: {2}{0}" +
                    "Nombre de contacto: {3}{0}" +
                    "Direccion de contacto: {4}{0}" +
                    "Fecha de creacion: {5}{0}{0}",
                    Environment.NewLine,
                    caso.DescripcionProblema, caso.Nivel, caso.NombreContacto, caso.DireccionContacto, caso.FechaCreacion);
            }

            string casoEnEstadoTerminado = "";
            foreach (Casos caso in listaDeCasosTerminados)
            {
                casoEnEstadoTerminado += String.Format("Descripcion: {1}{0}" +
                    "Nivel de criticidad: {2}{0}" +
                    "Nombre de contacto: {3}{0}" +
                    "Direccion de contacto: {4}{0}" +
                    "Fecha de creacion: {5}{0}{0}",
                    Environment.NewLine,
                    caso.DescripcionProblema, caso.Nivel, caso.NombreContacto, caso.DireccionContacto, caso.FechaCreacion);
            }

            string casoEnEstadoRechazado = "";
            foreach (Casos caso in listaDeCasosRechazados)
            {
                casoEnEstadoRechazado += String.Format("Descripcion: {1}{0}" +
                    "Nivel de criticidad: {2}{0}" +
                    "Nombre de contacto: {3}{0}" +
                    "Direccion de contacto: {4}{0}" +
                    "Fecha de creacion: {5}{0}{0}",
                    Environment.NewLine,
                    caso.DescripcionProblema, caso.Nivel, caso.NombreContacto, caso.DireccionContacto, caso.FechaCreacion);
            }

            string casoEnEstadoEliminado = "";
            foreach (Casos caso in listaDeCasosEliminados)
            {
                casoEnEstadoEliminado += String.Format("Descripcion: {1}{0}" +
                    "Nivel de criticidad: {2}{0}" +
                    "Nombre de contacto: {3}{0}" +
                    "Direccion de contacto: {4}{0}" +
                    "Fecha de creacion: {5}{0}{0}",
                    Environment.NewLine,
                    caso.DescripcionProblema, caso.Nivel, caso.NombreContacto, caso.DireccionContacto, caso.FechaCreacion);
            }

            string casoConNivelBajo = "";
            foreach (Casos caso in listaDeCasosDeNivelBajo)
            {
                casoConNivelBajo += String.Format("Descripcion: {1}{0}" +
                    "Nivel de criticidad: {2}{0}" +
                    "Nombre de contacto: {3}{0}" +
                    "Direccion de contacto: {4}{0}" +
                    "Fecha de creacion: {5}{0}{0}",
                    Environment.NewLine,
                    caso.DescripcionProblema, caso.Nivel, caso.NombreContacto, caso.DireccionContacto, caso.FechaCreacion);
            }

            string casoConNivelMedio = "";
            foreach (Casos caso in listaDeCasosDeNivelMedio)
            {
                casoConNivelMedio += String.Format("Descripcion: {1}{0}" +
                    "Nivel de criticidad: {2}{0}" +
                    "Nombre de contacto: {3}{0}" +
                    "Direccion de contacto: {4}{0}" +
                    "Fecha de creacion: {5}{0}{0}",
                    Environment.NewLine,
                    caso.DescripcionProblema, caso.Nivel, caso.NombreContacto, caso.DireccionContacto, caso.FechaCreacion);
            }

            string casoConNivelAlto = "";
            foreach (Casos caso in listaDeCasosDeNivelAlto)
            {
                casoConNivelAlto += String.Format("Descripcion: {1}{0}" +
                    "Nivel de criticidad: {2}{0}" +
                    "Nombre de contacto: {3}{0}" +
                    "Direccion de contacto: {4}{0}" +
                    "Fecha de creacion: {5}{0}{0}",
                    Environment.NewLine,
                    caso.DescripcionProblema, caso.Nivel, caso.NombreContacto, caso.DireccionContacto, caso.FechaCreacion);
            }

            string respuesta = String.Format(
                "CASOS EN ESTADO REGISTRADO: {1}{0}{2}{0}"+
                "CASOS EN ESTADO EN PROCESO: {3}{0}{4}{0}" +
                "CASOS EN ESTADO TERMINADO: {5}{0}{6}{0}" +
                "CASOS EN ESTADO RECHAZADO: {7}{0}{8}{0}" +
                "CASOS EN ESTADO ELIMINADO: {9}{0}{10}{0}" +
                "CASOS CON NIVEL BAJO: {11}{0}{12}{0}" +
                "CASOS CON NIVEL MEDIO: {13}{0}{14}{0}" +
                "CASOS CON NIVEL ALTO: {15}{0}{0}"+
                "Total de casos: {16}",
                Environment.NewLine,
                listaDeCasosRegistrados.Count, casoEnEstadoRegistrado, listaDeCasosEnProceso.Count, casoEnEstadoEnProceso, 
                listaDeCasosTerminados.Count, casoEnEstadoTerminado, listaDeCasosRechazados.Count, casoEnEstadoRechazado, 
                listaDeCasosEliminados.Count, casoEnEstadoEliminado, listaDeCasosDeNivelBajo.Count, casoConNivelBajo,
                listaDeCasosDeNivelMedio.Count, casoConNivelMedio, listaDeCasosDeNivelAlto.Count, casoConNivelAlto,
                
                (listaDeCasosRegistrados.Count + listaDeCasosEnProceso.Count + listaDeCasosTerminados.Count +
                listaDeCasosRechazados.Count + listaDeCasosEliminados.Count + listaDeCasosDeNivelBajo.Count +
                listaDeCasosDeNivelMedio.Count + listaDeCasosDeNivelAlto.Count));

            Console.WriteLine(respuesta);
        }

        [TestMethod]
        public void DebeInformarSiUnCasoExcedioTiempoParaPasarAenProceso()
        {
            LogicaDeNegocios.CoordinadorDeCasos coordinadorDeCasos = new LogicaDeNegocios.CoordinadorDeCasos();
            LogicaDeNegocios.CoordinadorDeEmpleados coordinadorDeEmpleados = new CoordinadorDeEmpleados();
            
            Model.Empleados empleado = coordinadorDeEmpleados.ObtenerEmpleadoPorId(1);

            Boolean haExcedidoTiempoMaximo = coordinadorDeCasos.PonerEnProceso(2, empleado);

            if (haExcedidoTiempoMaximo)
                Console.WriteLine("Ha excedido el tiempo máximo para pasar a estado en proceso");
        }

        [TestMethod]
        public void DebeMostrarCasosQueExcedenTiempoParaPasarAenProceso()
        {
            LogicaDeNegocios.CoordinadorDeCasos coordinador = new LogicaDeNegocios.CoordinadorDeCasos();

            List<Model.Casos> laListaDeCasosQueExcedenTiempoParaPasarAenProceso = coordinador.ObtenerCasosQueExcedenTiempoParaPasarAenProceso();

            string casos = "";
            foreach (Casos caso in laListaDeCasosQueExcedenTiempoParaPasarAenProceso)
            {
                casos += String.Format("Descripcion: {1}{0}" +
                    "Nivel de criticidad: {2}{0}" +
                    "Nombre de contacto: {3}{0}" +
                    "Direccion de contacto: {4}{0}" +
                    "Fecha de creacion: {5}{0}{0}",
                    Environment.NewLine,
                    caso.DescripcionProblema, caso.Nivel, caso.NombreContacto, caso.DireccionContacto, caso.FechaCreacion);
            }

            Console.WriteLine(String.Format(
                "CASOS QUE EXCEDEN TIEMPO PARA PASAR A ESTADO EN PROCESO: {1}{0}{0}{2}",
                Environment.NewLine, laListaDeCasosQueExcedenTiempoParaPasarAenProceso.Count, casos
                ));
        }
    }
}
