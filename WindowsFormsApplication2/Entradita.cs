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
    public partial class Entradita : Form
    {
        public Entradita()
        {
            InitializeComponent();
            toolStripProgressBar1.Minimum = 0;
            toolStripProgressBar1.Maximum = 100;
           
        }

        private void txtCodigoDeBarra_KeyPress(object sender, KeyPressEventArgs e)
        {
            DbConnection conn = new DbConnection(true);

            Producto producto = conn.ObtenerProductoPorCodigo_barras(Convert.ToString(txtCodigoDeBarra.Text));
            if ((e.KeyChar == Convert.ToChar(Keys.Enter)) || (e.KeyChar == Convert.ToChar(Keys.Tab)))
            {
                if ((char.IsDigit(e.KeyChar) == true) || (e.KeyChar == '\b'))
                    e.Handled = false;
                else
                {
                    e.Handled = true;
                }
                txtCantidad.Select();
                txtNombre.Text = producto.Descripcion;

                List<string> lista = new List<string>();
                foreach (Producto prod in conn.ObtenerTodosLosProductos())
                {
                    lista.Add(Convert.ToString(prod.Descripcion));
                }
                txtNombre.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                AutoCompleteStringCollection data = new AutoCompleteStringCollection();
                data.AddRange(lista.ToArray());
                txtNombre.AutoCompleteCustomSource = data;
                txtNombre.AutoCompleteSource = AutoCompleteSource.CustomSource;
                toolStripProgressBar1.Value = 0;

                e.Handled = true;
                conn.Close();

            }
            else if ((char.IsPunctuation(e.KeyChar) == true))
            {
                e.Handled = true;
            }
           
        }

        private void txtCodigoDeBarra_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtCodigoDeBarra.Text = "";
            txtCantidad.Text = "";
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                DbConnection conn = new DbConnection(true);

                Producto producto = conn.ObtenerProductoNombre(Convert.ToString(txtNombre.Text));
                if (producto.Descripcion == "")
                {
                    MessageBox.Show("Datos erroneos, verifica si el produto existe");

                }
                if (producto.Descripcion != "")
                {

                    txtNombre.Text = producto.Descripcion;
                    txtCodigoDeBarra.Text = Convert.ToString(producto.Codigo);

                }
                List<string> lista = new List<string>();
                foreach (Producto prod in conn.ObtenerTodosLosProductos())
                {
                    lista.Add(Convert.ToString(prod.Descripcion));
                }
                txtNombre.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                AutoCompleteStringCollection data = new AutoCompleteStringCollection();
                data.AddRange(lista.ToArray());
                txtNombre.AutoCompleteCustomSource = data;
                txtNombre.AutoCompleteSource = AutoCompleteSource.CustomSource;
                conn.Close();
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == Convert.ToChar(Keys.Enter)) || (e.KeyChar == Convert.ToChar(Keys.Tab)))
            {
                txtPagoProveedor.Select();
                e.Handled = true;
            }
            else if ((char.IsDigit(e.KeyChar) == true) || (e.KeyChar == '\b'))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtPagoProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == Convert.ToChar(Keys.Enter)) || (e.KeyChar == Convert.ToChar(Keys.Tab)))
            {
                btnAgregar_Click(sender, e);
            }
            else if ((char.IsDigit(e.KeyChar) == true) || (e.KeyChar == '\b') || (char.IsPunctuation(e.KeyChar) == true))
            {
                if (txtPagoProveedor.Text.Contains(".") && (char.IsPunctuation(e.KeyChar)))
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
            toolStripProgressBar1.Value = 0;
            if ((txtCantidad.Text == "") || (txtCodigoDeBarra.Text == "") || (txtNombre.Text == "") || (txtPagoProveedor.Text == ""))
            {
                MessageBox.Show("Faltan datos");
            }

            else
            {                
                toolStripProgressBar1.Value = 0;
                using (DbConnection conn = new DbConnection(true))
                {
                    Producto product = conn.ObtenerProductoNombre(txtNombre.Text);
                    Producto pro = conn.ObtenerProductoPorCodigo_barras(txtCodigoDeBarra.Text);
                    if (product.Descripcion != pro.Descripcion)
                    {
                        MessageBox.Show("Hay una incongruencia de datos, verifica que el codigo de barras \n y el nombre sean correctos");
                    }
                    else if (product.Codigo == pro.Codigo)
                    {
                            statuslabel.Text = "Agregando a la base de datos ...";
                            
                            conn.MovimientosCaja(txtPagoProveedor.Text.Replace(",","."), "RETIRO PROVEDOR", DateTime.Today);
                            conn.ModificarInventario(conn.ObtenerProductoPorCodigo_barras(txtCodigoDeBarra.Text).Id, Convert.ToInt32(txtCantidad.Text));
                            timer1.Enabled = true;
                            conn.Close();                     
                           
                    }
                }
            }

           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
                toolStripProgressBar1.Value = toolStripProgressBar1.Value+25;
            
            if (toolStripProgressBar1.Value >= toolStripProgressBar1.Maximum)
            {
                timer1.Enabled = false;                
                MessageBox.Show("RECUERDE PEDIR SU RECIBO PARA COMPROBAR GASTOS, COMPRA REALIZADA POR: $"+txtPagoProveedor.Text+"");               
                statuslabel.Text = "Se agregaron "+txtCantidad.Text+" unidades de: "+txtNombre.Text+"";
                txtPagoProveedor.Text = "";
                txtCodigoDeBarra.Text = "";
                txtNombre.Text = "";
                txtCantidad.Text = "";
                txtCodigoDeBarra.Select();
            }
        }

        private void txtNombre_Click(object sender, EventArgs e)
        {
            DbConnection conn = new DbConnection(true);
            List<string> lista = new List<string>();
            foreach (Producto prod in conn.ObtenerTodosLosProductos())
            {
                lista.Add(Convert.ToString(prod.Descripcion));
            }
            txtNombre.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection data = new AutoCompleteStringCollection();
            data.AddRange(lista.ToArray());
            txtNombre.AutoCompleteCustomSource = data;
            txtNombre.AutoCompleteSource = AutoCompleteSource.CustomSource;

            conn.Close();
        }
    }
}
