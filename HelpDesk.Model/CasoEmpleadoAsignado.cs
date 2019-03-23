using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Model
{
    public class CasoEmpleadoAsignado
    {
        public int Id { get; set; }
        
        public int IdCasos { get; set; }
        
        public int IdEmpleados { get; set; }   
    }
}
