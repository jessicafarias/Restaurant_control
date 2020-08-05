using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyConnection;

namespace Tienda2
{
    public partial class NuevoIngreso : Form
    {
        public NuevoIngreso()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DbConnection conn = new DbConnection(true);
            conn.AgregarSocioUnico(1,Convert.ToString(txtNombre.Text), Convert.ToString(txtContraseña.Text));
            conn.Close();
            Application.Restart();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == Convert.ToChar(Keys.Enter)) || (e.KeyChar == Convert.ToChar(Keys.Tab)))
            {
                if (txtNombre.Text == "")
                {
                    MessageBox.Show("Agrega un usuario");
                }
                else
                {
                    txtContraseña.Select();
                    e.Handled = true;
                }
            }
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == Convert.ToChar(Keys.Enter)) || (e.KeyChar == Convert.ToChar(Keys.Tab)))
            {
                if (txtContraseña.Text == "")
                {
                    MessageBox.Show("Agrega una contraseña!");
                }
                else
                {
                    btnOK_Click(sender, e);
                }
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                btnOK.Enabled = false;
            }
        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "")
            {
                btnOK.Enabled = false;
            }
        }
    }
}
