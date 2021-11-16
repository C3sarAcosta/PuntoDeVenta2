using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta.Models
{
    class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost; Database=Clase; Username=postgres; password=nada123;")
                .EnableSensitiveDataLogging(true);

            /*SQL
             * optionsBuilder.UseSqlServer("Data Source=; Initial Catalog=Nombre de la base de datos; Itegrated Security=True")
             * 
             * optionsBuilder.UseSqlServer("Data Source=; Initial Catalog=Nombre de la base de datos; Persist Security Info=True;User ID=sa;Password=TuContraseña")
            */
        }

        //Propiedad la cual le idicia a EFC que vamos a tener una tabla Emplleados 
        public DbSet<Empleados> Empleados { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Productos> Productos { get; set; }

    }
}


