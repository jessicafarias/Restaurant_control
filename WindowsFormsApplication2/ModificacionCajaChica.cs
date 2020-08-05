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
    public partial class ModificacionCajaChica : Form
    {
        public ModificacionCajaChica()
        {
            InitializeComponent();
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsDigit(e.KeyChar) == true) || (e.KeyChar == '\b') || (char.IsPunctuation(e.KeyChar) == true))
            {
                 if (txtCantidad.Text == "")
                { 
                    if (char.IsPunctuation(e.KeyChar)==true)
                    {
                        e.Handled = true;
                        txtCantidad.Text = "0.";
                        txtCantidad.Select(3, 0);
                    }
                 }
            
                    
                 else if (txtCantidad.Text.Contains(".") && (char.IsPunctuation(e.KeyChar)))
                {
                    e.Handled = true;
                }
                 else
               
                    e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DbConnection conn = new DbConnection(true);
            conn.MovimientosCaja(txtCantidad.Text, "INGRESO", DateTime.Today);
            conn.Close();
            MessageBox.Show("INGRESASTE $"+ txtCantidad.Text.Replace(",",".") + " PARA USO DE LA CAJA");                
            txtCantidad.Text = "";
            
        }

        private void btnRetirar_Click(object sender, EventArgs e)
        {
            
            DbConnection conn = new DbConnection(true);           
            conn.MovimientosCaja(txtCantidad.Text, "RETIRO", DateTime.Today);            
            MessageBox.Show("RETIRASTE $"+txtCantidad.Text+"EL DINERO YA NO SE ENCUENTRA REGISTRADO EN CAJA", "Retiro",MessageBoxButtons.OK,MessageBoxIcon.Information);
            txtCantidad.Text = "";
            conn.Close();
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            if ((txtCantidad.Text == "") || (Convert.ToDecimal(txtCantidad.Text) == 0))
            {
                btnAgregar.Enabled = false;
                btnRetirar.Enabled = false;
            }
            else
            {
                btnAgregar.Enabled = true;
                btnRetirar.Enabled = true;
            }
        }
    }
}
