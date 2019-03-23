using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Model
{
    public class Casos
    {
        public int Id { get; set; }
        
        public String DescripcionProblema { get; set; }
        
        public int Nivel { get; set; }
        public int Estado { get; set; }
        
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaResolucion { get; set; }

        public String ObservacionesResolucion { get; set; }
        
        public String NombreContacto { get; set; }
        
        public String TelefonoContacto { get; set; }

        public String DireccionContacto { get; set; }

        public int ProvinciaContacto { get; set; }

        public DateTime? FechaInicioProceso { get; set; }

        public String MotivoRechazo { get; set; }
        public String DescripcionResolucion { get; set; }
    }
}
