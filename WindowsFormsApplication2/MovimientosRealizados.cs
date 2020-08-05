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
    public partial class MovimientosRealizados : Form
    {
        public MovimientosRealizados()
        {
            InitializeComponent();
            //using (DbConnection conn = new DbConnection(true))
            //{
            //    foreach (Estatus est in conn.Estatus())
            //    {
            //        ListViewItem item = new ListViewItem(Convert.ToString(est.Modificaciones));
            //        item.SubItems.Add(Convert.ToString(est.Monto));
            //        item.SubItems.Add(Convert.ToString(est.fechaModificacion.ToShortDateString()));
            //        listView1.Items.Add(item);

            //    }
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListViewItem items = new ListViewItem();
            foreach (ListViewItem list in listViewDatos.Items)
            {
                list.Remove();
            }
            using (DbConnection conn = new DbConnection(true))
            {

                foreach (Estatus est in conn.Estatus(Convert.ToDateTime(dateTimePicker1.Text), Convert.ToDateTime(dateTimePicker2.Text)))
                {
                    ListViewItem item = new ListViewItem(Convert.ToString(est.Modificaciones));
                    item.SubItems.Add(Convert.ToString(est.Monto));
                    item.SubItems.Add(Convert.ToString(est.fechaModificacion.ToShortDateString()));
                    listViewDatos.Items.Add(item);

                }
            }
        }
    }
}
