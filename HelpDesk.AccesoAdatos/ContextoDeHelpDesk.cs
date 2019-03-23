using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace HelpDesk.AccesoAdatos
{
    class ContextoDeHelpDesk:DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Model.Casos>().ToTable("Casos");
           
            modelBuilder.Entity<Model.CasoEmpleadoAsignado>().ToTable("CasoEmpleadoAsignado");
            
            modelBuilder.Entity<Model.Empleados>().ToTable("Empleados");
            
        }

        public DbSet<Model.Casos> Casos { get; set; }
        public DbSet<Model.CasoEmpleadoAsignado> CasoEmpleadoAsignado { get; set; }
        public DbSet<Model.Empleados> Empleados { get; set; }
    }
}
