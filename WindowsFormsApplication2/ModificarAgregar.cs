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
    public partial class ModificarAgregar : Form
    {

        public ModificarAgregar()
        {
            InitializeComponent();

            DbConnection conn = new DbConnection(true);

            txtCodigoBarras.Text = "";
            txtNombre.Text = "";

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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DbConnection conn = new DbConnection(true);
            if ((txtPrecioAlaVenta.Text == "") || (txtNombre.Text == ""))
            {
                btnGuardar.Enabled = false;
                toolStripProgressBar1.Value = 0;
            }
            else
            {
                toolStripProgressBar1.Value = 0;
                Producto productoigual = new Producto();
                productoigual = null;
                foreach (Producto p in conn.ObtenerTodosLosProductos())
                {
                    if ((p.Codigo == txtCodigoBarras.Text) || (p.Descripcion == txtNombre.Text))
                    {
                        productoigual = p;
                        break;
                    }

                }
                if (productoigual == null)
                {
                    int IDNew = conn.NumeroMaximoDeProductos();
                    conn.AgregarProducto2(IDNew, Convert.ToString(txtNombre.Text), 
                        Convert.ToString(txtCodigoBarras.Text), txtPrecioAlaVenta.Text);
                    conn.Close();
                    txtCodigoBarras.Select();
                    statuslabel.Text = "Agregando a la base de datos ...";
                    timer1.Enabled = true;
                }
                else
                {
                    if ((productoigual.Codigo == txtCodigoBarras.Text) && (productoigual.Descripcion == txtNombre.Text))
                    {
                        DialogResult resu = MessageBox.Show("Este producto se le modificara el precio a " + (txtPrecioAlaVenta.Text) + "", "ADVERTENCIA", MessageBoxButtons.YesNo,MessageBoxIcon.Information);

                        if (resu == DialogResult.Yes)
                        {
                            conn.ModificarProducto3(productoigual.Id, txtPrecioAlaVenta.Text);
                            statuslabel.Text = "Agregando a la base de datos ...";
                            timer1.Enabled = true;
                        }
                        
                        
                    }
                    else if ((productoigual.Codigo == txtCodigoBarras.Text) && (productoigual.Descripcion != txtNombre.Text))
                    {

                        DialogResult resu = MessageBox.Show("ESTA CAMBIANDO EL NOMBRE DE " + Convert.ToString(productoigual.Descripcion) + " POR " + Convert.ToString(txtNombre.Text) +
                            "\n\n desea continuar?", "ADVERTENCIA", MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                        if (resu == DialogResult.Yes)
                        {
                            conn.ModificarProductoIdIdStringDes(productoigual.Id, Convert.ToString(txtNombre.Text));
                            statuslabel.Text = "Agregando a la base de datos ...";
                            timer1.Enabled = true;
                        }
                       
                    }


                    else if ((productoigual.Codigo != txtCodigoBarras.Text) && (productoigual.Descripcion == txtNombre.Text))
                    {
                      
                            DialogResult resu = MessageBox.Show("Este producto existe con un diferente código de barras, "
                                +"\n es posible que este código de barras halla cambiado, desea guardar los cambios?", "ADVERTENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                            if (resu == DialogResult.Yes)
                            {
                                conn.ModificarProductoStringCodID(Convert.ToString(txtCodigoBarras.Text), productoigual.Id);
                                statuslabel.Text = "Agregando a la base de datos ...";
                                timer1.Enabled = true;
                            }
                           
                    }
                    
                }


            }
        }

       

        private void txtCodigoBarras_Enter(object sender, EventArgs e)
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

        private void txtCodigoBarras_KeyPress(object sender, KeyPressEventArgs e)
        {
           
                
                if ((e.KeyChar == Convert.ToChar(Keys.Enter)) || (e.KeyChar == Convert.ToChar(Keys.Tab)))
                {
                    DbConnection conn = new DbConnection(true);
                    Producto producto = conn.ObtenerProductoPorCodigo_barras(Convert.ToString(txtCodigoBarras.Text));
                    string Nombre = producto.Descripcion;
                    if (producto.Id != 0)
                    {
                        //cmbNombre.Text = Nombre;
                        txtPrecioAlaVenta.Text = Convert.ToString(producto.Precio);
                        txtNombre.Text = producto.Descripcion;
                    }
                    else
                    {
                        txtNombre.Select();
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

                    }
                    conn.Close();
                }
                else if ((char.IsPunctuation(e.KeyChar) == true))
                {
                    e.Handled = true;
                }
                       

            
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
          
                DbConnection conn = new DbConnection(true);

                if ((e.KeyChar == Convert.ToChar(Keys.Enter)) || (e.KeyChar == Convert.ToChar(Keys.Tab)))
                {
                    Producto producto = new Producto();
                    producto = conn.ObtenerProductoNombre(txtNombre.Text);
                    if (producto == null)
                    {
                        MessageBox.Show("Favor agrege un producto existente para modificar");
                    }
                    else
                    {

                        txtPrecioAlaVenta.Select();
                        txtPrecioAlaVenta.Text = Convert.ToString(producto.Precio);
                    }
                }
                conn.Close();
            
        }

        private void ModificarAgregar_Load(object sender, EventArgs e)
        {

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


                    txtNombre.Text = producto.Descripcion;
                    txtCodigoBarras.Text = Convert.ToString(producto.Codigo);
                    txtPrecioAlaVenta.Text = Convert.ToString(producto.Precio);

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

     

        private void txtPrecioAlaVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == Convert.ToChar(Keys.Enter)) || (e.KeyChar == Convert.ToChar(Keys.Tab)))
            {
                btnGuardar_Click(sender, e);
            }
            else
            {
                if ((char.IsDigit(e.KeyChar) == true) || (e.KeyChar == '\b') || (char.IsPunctuation(e.KeyChar) == true))
                {
                    if (txtPrecioAlaVenta.Text.Contains(".") && (char.IsPunctuation(e.KeyChar)))
                    {
                        e.Handled = true;
                    }
                    else
                        e.Handled = false;
                }
                else
                    e.Handled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripProgressBar1.Value = toolStripProgressBar1.Value + 25;
            if (toolStripProgressBar1.Value >= toolStripProgressBar1.Maximum)
            {
                timer1.Enabled = false;
                statuslabel.Text = "Ultimo en modificacion: "+ txtNombre.Text + " $"+txtPrecioAlaVenta.Text+"";
                txtNombre.Text = "";
                txtPrecioAlaVenta.Text = "";
                txtCodigoBarras.Text = "";
            }
        }
    }
}
