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
    public partial class FormVer : Form
    {
        public FormVer()
        {
            InitializeComponent();
            DbConnection conn = new DbConnection(true);
            lblDineroTotal.Text = Convert.ToString(conn.VerTotal());
            conn.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkVerMovimientos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
                MovimientosRealizados movmentes = new MovimientosRealizados();
                movmentes.ShowDialog();
            
        }
    }
}
