using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HelpDesk.UI.Models
{
    public class ModeloEmpleados
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Nombre { get; set; }

        [MaxLength(50)]
        public string Identificacion { get; set; }

        [MaxLength(100)]
        public string Apellidos { get; set; }
    }
}