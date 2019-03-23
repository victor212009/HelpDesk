using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace HelpDesk.UI.Models
{
    public class ModeloCasos
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public String DescripcionProblema { get; set; }

        [Required]
        public int Nivel { get; set; }
        public int Estado { get; set; }

        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaResolucion { get; set; }

        public String ObservacionesResolucion { get; set; }

        [Required]
        [MaxLength(50)]
        public String NombreContacto { get; set; }

        [Required]
        [MaxLength(50)]
        public String TelefonoContacto { get; set; }

        public String DireccionContacto { get; set; }

        public int ProvinciaContacto { get; set; }

        public DateTime? FechaInicioProceso { get; set; }

        public String MotivoRechazo { get; set; }
        public String DescripcionResolucion { get; set; }

        public String Identificacion { get; set; }

        public int IdEmpleado { get; set; }
        
        [NotMapped]
        public int DiasSinAtenderElCaso {
            get {
                return DateTime.Now.Subtract(FechaCreacion).Days;
            }
        }

        public List<int> ListaDeProvincias { get; set; }
        public IEnumerable<SelectListItem> Provincias
        {
            get { return new SelectList(ListaDeProvincias); }
        }

        public List<int> ListaDeNivelesDeCriticidad { get; set; }
        public IEnumerable<SelectListItem> NivelesDeCriticidad
        {
            get { return new SelectList(ListaDeNivelesDeCriticidad); }
        }

        public List<Model.Empleados> ListaDeEmpleados { get; set; }
        public IEnumerable<SelectListItem> Empleados
        {
            get { return new SelectList(ListaDeEmpleados, "Id", "Identificacion"); }
        }
    }
}