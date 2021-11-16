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
    public partial class FrmProductos : Form
    {
        public int id = 0;

        public FrmProductos()
        {
            InitializeComponent();
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            TodosProductos();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            AgregarProducto();
            TodosProductos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarProducto();
            TodosProductos();
        }


        private void TodosProductos()
        {
            using (var context = new ApplicationDbContext())
            {
                var productos = context.Productos.ToList();
                dgvProductos.DataSource = productos;
            }
        }

        private void AgregarProducto()
        {
            using (var context = new ApplicationDbContext())
            {
                var producto = new Productos();
                producto.Nombre = txtNombre.Text;
                producto.Marca = txtMarca.Text;
                producto.Cantidad = int.Parse(txtCantidad.Text);
                producto.PrecioCompra = double.Parse(txtPrecioCompra.Text);
                producto.PrecioVenta = double.Parse(txtPrecioVenta.Text);

                context.Productos.Add(producto);

                context.SaveChanges();
            }
        }

        private void EliminarProducto()
        {
            using (var context = new ApplicationDbContext())
            {
                if(id != 0)
                {
                    var producto = context.Productos.First(x => x.Id == id);
                    if(producto != null)
                    {
                        context.Remove(producto);
                        context.SaveChanges();
                    }
                }
            }
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value);
        }
    }
}
