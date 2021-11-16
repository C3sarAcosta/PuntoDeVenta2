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
    public partial class FrmClientes : Form
    {
        public int id = 0;
        public FrmClientes()
        {
            InitializeComponent();
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            TodosClientes();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarCliente();
            TodosClientes();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ModificarCliente();
            TodosClientes();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            AgregarClientes();
            TodosClientes(); ;
        }

        private void TodosClientes()
        {
            using (var context = new ApplicationDbContext())
            {
                var clientes = context.Clientes.ToList();
                dgvClientes.DataSource = clientes;
            }
        }

        private void BuscarCliente()
        {
            using (var context = new ApplicationDbContext())
            {
                var clientes = context.Clientes.Where(x => x.Nombre.Contains(txtBuscador.Text)).ToList();
                dgvClientes.DataSource = clientes;
            }
        }

        private void AgregarClientes()
        {
            using (var context = new ApplicationDbContext())
            {
                //Paso 1: Crear el objeto
                var cliente = new Clientes();
                cliente.Nombre = txtNombre.Text;
                cliente.ApellidoPaterno = txtApellidoPaterno.Text;
                cliente.ApellidoMaterno = txtApellidoMaterno.Text;
                cliente.Sexo = rbtnFemenino.Checked ? "Femenino" : "Masculino";
                cliente.FechaNacimiento = dtpFechaNacimiento.Value.Date;
                cliente.RFC = txtRFC.Text;

                //Paso 2: Notificamos a EFC que  queremos agregar un empleado
                context.Clientes.Add(cliente);

                //Paso 3: Guardamos los cambios
                context.SaveChanges();
            }
        }

        private void ModificarCliente()
        {
            using (var context = new ApplicationDbContext())
            {
                //Paso 1: Crear el objeto
                if (id != 0)
                {
                    var cliente = context.Clientes.First(x => x.Id == id);
                    cliente.Nombre = txtNombre.Text;
                    cliente.ApellidoPaterno = txtApellidoPaterno.Text;
                    cliente.ApellidoMaterno = txtApellidoMaterno.Text;
                    cliente.Sexo = rbtnFemenino.Checked ? "Femenino" : "Masculion";
                    cliente.FechaNacimiento = dtpFechaNacimiento.Value.Date;
                    cliente.RFC = txtRFC.Text;
                    context.SaveChanges();
                }
            }
        }

        private void EliminarCliente()
        {
            using (var context = new ApplicationDbContext())
            {
                //Paso 1: Crear el objeto
                if (id != 0)
                {
                    var cliente = context.Clientes.First(x => x.Id == id);
                    if (cliente != null)
                    {
                        context.Remove(cliente);
                        context.SaveChanges();
                    }
                }
            }
        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            BuscarCliente();
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(dgvClientes.CurrentRow.Cells[0].Value);
            txtNombre.Text = dgvClientes.CurrentRow.Cells[1].Value.ToString();
            txtApellidoPaterno.Text = dgvClientes.CurrentRow.Cells[2].Value.ToString();
            txtApellidoMaterno.Text = dgvClientes.CurrentRow.Cells[3].Value.ToString();
            if (dgvClientes.CurrentRow.Cells[4].Value.ToString() == "Femenino")
            {
                rbtnFemenino.Checked = true;
            }
            else
            {
                rbtnMasculino.Checked = true;
            }
            dtpFechaNacimiento.Value = Convert.ToDateTime(dgvClientes.CurrentRow.Cells[5].Value.ToString());
            txtRFC.Text = dgvClientes.CurrentRow.Cells[6].Value.ToString();
        }
    }
}
