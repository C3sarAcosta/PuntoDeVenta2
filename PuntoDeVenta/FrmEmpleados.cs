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
        public int id = 0;
        public FrmEmpleados()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            AgregarEmpleado();
            TodosEmpleados();
        }

        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            TodosEmpleados();
        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            BuscarEmpleado();
        }


        private void BuscarEmpleado()
        {
            using (var context = new ApplicationDbContext())
            {
                var empleados = context.Empleados.Where(x => x.Nombre.Contains(txtBuscador.Text)).ToList();
                dgvEmpleados.DataSource = empleados;
            }
        }

        private void AgregarEmpleado() 
        {
            using (var context = new ApplicationDbContext())
            {
                //Paso 1: Crear el objeto
                var empleado1 = new Empleados();
                empleado1.Nombre = txtNombre.Text;
                empleado1.ApellidoPaterno = txtApellidoPaterno.Text;
                empleado1.ApellidoMaterno = txtApellidoMaterno.Text;
                empleado1.Sexo = rbtnFemenino.Checked ? "Femenino" : "Masculino";
                empleado1.FechaNacimiento = dtpFechaNacimiento.Value.Date;
                empleado1.RFC = txtRFC.Text;

                //Paso 2: Notificamos a EFC que  queremos agregar un empleado
                context.Empleados.Add(empleado1);

                //Paso 3: Guardamos los cambios
                context.SaveChanges();
            }
        }

        private void TodosEmpleados()
        {
            using (var context = new ApplicationDbContext())
            {
                var empleados = context.Empleados.ToList();
                dgvEmpleados.DataSource = empleados;
            }
        }

        private void dgvEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(dgvEmpleados.CurrentRow.Cells[0].Value);
            txtNombre.Text = dgvEmpleados.CurrentRow.Cells[1].Value.ToString();
            txtApellidoPaterno.Text = dgvEmpleados.CurrentRow.Cells[2].Value.ToString();
            txtApellidoMaterno.Text = dgvEmpleados.CurrentRow.Cells[3].Value.ToString();
            if(dgvEmpleados.CurrentRow.Cells[4].Value.ToString() == "Femenino")
            {
                rbtnFemenino.Checked = true;
            }
            else
            {
                rbtnMasculino.Checked = true;
            }
            dtpFechaNacimiento.Value = Convert.ToDateTime(dgvEmpleados.CurrentRow.Cells[5].Value.ToString());
            txtRFC.Text = dgvEmpleados.CurrentRow.Cells[6].Value.ToString();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ModificarEmpleado();
            TodosEmpleados();
        }

        private void ModificarEmpleado()
        {
            using (var context = new ApplicationDbContext())
            {
                //Paso 1: Crear el objeto
                if (id != 0)
                {
                    var empleado = context.Empleados.First(x => x.Id == id);
                    empleado.Nombre = txtNombre.Text;
                    empleado.ApellidoPaterno = txtApellidoPaterno.Text;
                    empleado.ApellidoMaterno = txtApellidoMaterno.Text;
                    empleado.Sexo = rbtnFemenino.Checked ? "Femenino" : "Masculion";
                    empleado.FechaNacimiento = dtpFechaNacimiento.Value.Date;
                    empleado.RFC = txtRFC.Text;
                    context.SaveChanges();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarEmpleado();
            TodosEmpleados(); ;
        }

        private void EliminarEmpleado()
        {
            using (var context = new ApplicationDbContext())
            {
                //Paso 1: Crear el objeto
                if (id != 0)
                {
                    var empleado = context.Empleados.First(x => x.Id == id);
                    if(empleado != null)
                    {
                        context.Remove(empleado);
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
