using PuntoDeVenta.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoDeVenta
{
    public partial class FrmEmpleados : Form
    {
        public FrmEmpleados()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            using (var context = new ApplicationDbContext())
            {
                //Paso 1: Crear el objeto
                var empleado1 = new Empleados();
                empleado1.Nombre = "César Acosta";
                empleado1.ApellidoPaterno = "Acosta";
                empleado1.ApellidoMaterno = "Armendariz";
                empleado1.Sexo = "Masculino";
                empleado1.FechaNacimiento = new DateTime(1993, 03, 20);
                empleado1.RFC = "KSNDCKSBC67SAJCU7";

                //Paso 2: Notificamos a EFC que  queremos agregar un empleado
                context.Empleados.Add(empleado1);

                //Paso 3: Guardamos los cambios
                context.SaveChanges();
            }
        }
    }
}
