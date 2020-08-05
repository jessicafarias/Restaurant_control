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
    public partial class InventarioForm : Form
    {
        public InventarioForm()
        {
            InitializeComponent();
            this.MaximizeBox = false;

            using (DbConnection conn = new DbConnection(true))
            {
                foreach (Inventario inventariado in conn.Inventariado())
                {
                    if (inventariado.Cantidad != 0)
                    {

                        ListViewItem item = new ListViewItem(Convert.ToString(inventariado.Codigo));
                        item.SubItems.Add(Convert.ToString(inventariado.Descripcion));
                        item.SubItems.Add(Convert.ToString(inventariado.Cantidad));
                        listView1.Items.Add(item);
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Contraseña contra = new Contraseña();
            contra.ShowDialog();
            if ((contra.Aux == true) && (contra.seguridad == true))
            {
                ModificarAgregar Modif_agregar = new ModificarAgregar();
                Modif_agregar.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Entradita entra = new Entradita();
            entra.ShowDialog();
            this.Close();
        }
    }
}
