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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnConfiguraciones_Click(object sender, EventArgs e)
        {
            lblNombreUsuario.Text = "César Acosta";
            Form1 fm1 = new Form1();
            fm1.Show();
            this.Hide();
        }
    }
}
