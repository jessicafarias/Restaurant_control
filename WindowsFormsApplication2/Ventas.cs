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
    public partial class Ventas : Form
    {
        public Ventas()
        {
            InitializeComponent();
            DbConnection conn = new DbConnection(true);
           
            List<string> lista = new List<string>();
            foreach (Producto prod in conn.ObtenerTodosLosProductos())
            {
                if (conn.Existencia(prod.Id) == true)
                {
                    lista.Add(Convert.ToString(prod.Descripcion));
                }
            }
            txtNombre.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection data = new AutoCompleteStringCollection();
            data.AddRange(lista.ToArray());
            txtNombre.AutoCompleteCustomSource = data;
            txtNombre.AutoCompleteSource = AutoCompleteSource.CustomSource;
            conn.Close();
        }

        private void txtCodigoBarras_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((e.KeyChar == Convert.ToChar(Keys.Enter)) || (e.KeyChar == Convert.ToChar(Keys.Tab)))
            {
                DbConnection conn = new DbConnection(true);
                Producto producto = conn.ObtenerProductoPorCodigo_barras(txtCodigoBarras.Text);
                if (producto.Id==0)
                {
                    producto.Descripcion = ""; 
                }

                if (producto.Descripcion == "")
                {
                    MessageBox.Show("No se encontraron resultados");
                }
                else
                {
                    if (conn.Existencia(producto.Id) == true)
                    {
                        ListViewItem item = new ListViewItem(txtCodigoBarras.Text);
                        if ((e.KeyChar == Convert.ToChar(Keys.Enter)) || (e.KeyChar == Convert.ToChar(Keys.Tab)))
                        {
                            item.SubItems.Add(producto.Descripcion);
                            item.SubItems.Add(Convert.ToString(producto.Precio));
                            listViewListaVenta.Items.Add(item);
                        }

                        conn.Close();
                        //Agrega el producto a la lista si se encuentra
                    }
                    else
                    {
                        MessageBox.Show("Este producto no esta registrado en el inventario");
                    }
                }
                txtCodigoBarras.Text = "";
                txtCodigoBarras.Select();

                decimal suma = 0;
                foreach (ListViewItem items in listViewListaVenta.Items)
                {
                    suma += decimal.Parse(items.SubItems[2].Text);
                }
                labelTotal.Text = Convert.ToString(suma);

                e.Handled = true;
            }
            else if ((char.IsPunctuation(e.KeyChar) == true))
            {
                e.Handled = true;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((e.KeyChar == Convert.ToChar(Keys.Enter)) || (e.KeyChar == Convert.ToChar(Keys.Tab)))
            {
                DbConnection conn = new DbConnection(true);
                Producto producto = conn.ObtenerProductoNombre(txtNombre.Text);
                if (producto.Id == 0)
                {
                    producto.Descripcion = "";
                }

                if (producto.Descripcion == "")
                {
                    MessageBox.Show("No se encontraron resultados");
                }
                else
                {
                    ListViewItem item = new ListViewItem(txtCodigoBarras.Text);
                    if ((e.KeyChar == Convert.ToChar(Keys.Enter)) || (e.KeyChar == Convert.ToChar(Keys.Tab)))
                    {
                        item.SubItems.Add(producto.Descripcion);
                        item.SubItems.Add(Convert.ToString(producto.Precio));
                        listViewListaVenta.Items.Add(item);
                    }

             
                    //Agrega el producto a la lista si se encuentra
                    txtNombre.Text = "";
                    txtNombre.Select();
                    decimal suma = 0;
                    foreach (ListViewItem items in listViewListaVenta.Items)
                    {
                        suma += decimal.Parse(items.SubItems[2].Text);
                    }
                    labelTotal.Text = Convert.ToString(suma);

                    List<string> lista = new List<string>();
                    foreach (Producto prod in conn.ObtenerTodosLosProductos())
                    {
                        if (conn.Existencia(prod.Id) == true)
                        {
                            lista.Add(Convert.ToString(prod.Descripcion));
                        }
                    }
                    txtNombre.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    AutoCompleteStringCollection data = new AutoCompleteStringCollection();
                    data.AddRange(lista.ToArray());
                    txtNombre.AutoCompleteCustomSource = data;
                    txtNombre.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    conn.Close();
                }
                
            }
           
            
            //Agrega el prodcuto a la lista si se encuentra
           
        }

        private void btnQuitarProducto_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem();
            foreach (ListViewItem list in listViewListaVenta.SelectedItems)
            {
                list.Remove();
            }
            decimal suma = 0;
            foreach (ListViewItem items in listViewListaVenta.Items)
            {
                suma += decimal.Parse(items.SubItems[2].Text);
            }
            labelTotal.Text = Convert.ToString(suma);
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            if (listViewListaVenta.Items.Count == 0)
            {
                MessageBox.Show("No hay productos a la venta", "sin datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {             
                    DbConnection conn = new DbConnection(true);
                    conn.Venta(labelTotal.Text.Replace(",","."));
                                   
              
                    if (txtPagoCantidad.Text == "")
                    {
                        txtPagoCantidad.Text = labelTotal.Text;
                    }
                    conn.Numero(txtPagoCantidad.Text.Replace(",", "."));
                    decimal num = conn.getNumero();
                conn.Numero(labelTotal.Text.Replace(",","."));
                decimal num2= conn.getNumero();
                decimal Resta = num - num2;
                    lableCambio.Text = (Convert.ToString(Resta));

                    foreach (ListViewItem items in listViewListaVenta.Items)
                    {
                        conn.ModificarInventario(conn.ObtenerProductoPorCodigo_barras(items.SubItems[0].Text).Id);
                        items.Remove();
                    }
                    txtPagoCantidad.Text = "";
                 conn.Close();
            }
            Notificacion();
        }


        private void Notificacion()
        {
            DbConnection conn = new DbConnection(true);
            foreach (Inventario inventari in conn.Inventariado())
            {
                if(inventari.Cantidad>0)
                {
                    if (inventari.Cantidad < 5)
                    {
                        notifyIcon1.Icon = SystemIcons.Application;
                        notifyIcon1.Visible = true;
                        notifyIcon1.BalloonTipText = "Se calcula que tiene menos de 5\nUnidades de " + inventari.Descripcion + "";
                        notifyIcon1.BalloonTipTitle = "WorkAdminStore3\nProducto casi agotado";
                        notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                        notifyIcon1.ShowBalloonTip(10000);
                        break;
                    }
                }
            }
            conn.Close();
            
        }

        private void txtNombre_Click(object sender, EventArgs e)
        {
            DbConnection conn = new DbConnection(true);
            List<string> lista = new List<string>();
            foreach (Producto prod in conn.ObtenerTodosLosProductos())
            {
                if (conn.Existencia(prod.Id) == true)
                {
                    lista.Add(Convert.ToString(prod.Descripcion));
                }
            }
            txtNombre.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection data = new AutoCompleteStringCollection();
            data.AddRange(lista.ToArray());
            txtNombre.AutoCompleteCustomSource = data;
            txtNombre.AutoCompleteSource = AutoCompleteSource.CustomSource;
            conn.Close();
            txtNombre.Text = "";
            txtCodigoBarras.Text = "";
        }

       

        private void txtNombre_DoubleClick(object sender, EventArgs e)
        {
        }

        private void txtCodigoBarras_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtCodigoBarras.Text = "";
            decimal suma = 0;
            foreach (ListViewItem items in listViewListaVenta.Items)
            {
                suma += decimal.Parse(items.SubItems[2].Text);
            }
            labelTotal.Text = Convert.ToString(suma);
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DbConnection conn = new DbConnection(true);

                Producto producto = conn.ObtenerProductoNombre(Convert.ToString(txtNombre.Text));
                if (producto.Descripcion == "")
                {
                    producto.Descripcion = null;

                }
                if (producto.Descripcion != null)
                {
                    ListViewItem item = new ListViewItem(producto.Codigo);
                    item.SubItems.Add(producto.Descripcion);
                    item.SubItems.Add(Convert.ToString(producto.Precio));
                    listViewListaVenta.Items.Add(item);

                   
                    txtNombre.Text = "";
                    txtCodigoBarras.Text = "";

                    decimal suma = 0;
                    foreach (ListViewItem items in listViewListaVenta.Items)
                    {
                        suma += decimal.Parse(items.SubItems[2].Text);
                    }
                    labelTotal.Text = Convert.ToString(suma);
                }
                List<string> lista = new List<string>();
                foreach (Producto prod in conn.ObtenerTodosLosProductos())
                {
                    if (conn.Existencia(prod.Id) == true)
                    {
                        lista.Add(Convert.ToString(prod.Descripcion));
                    }
                }
                txtNombre.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                AutoCompleteStringCollection data = new AutoCompleteStringCollection();
                data.AddRange(lista.ToArray());
                txtNombre.AutoCompleteCustomSource = data;
                txtNombre.AutoCompleteSource = AutoCompleteSource.CustomSource;

                conn.Close();
            }

        }

        private void txtCodigoBarras_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtPagoCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsDigit(e.KeyChar) == true) || (e.KeyChar == '\b') || (char.IsPunctuation(e.KeyChar) == true))
            {
                if (txtPagoCantidad.Text.Contains(".") && (char.IsPunctuation(e.KeyChar)))
                {
                    e.Handled = true;
                }
                else
                    e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            //mostrar
            this.Visible = !this.Visible;
            notifyIcon1.Visible = !this.Visible;
           
        }

     
    }
}
