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
    public partial class Inicial : Form
    {
        public Inicial()
        {
            InitializeComponent();
            DbConnection conn = new DbConnection();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Agregar add = new Agregar();
            //add.ShowDialog();
            Ventas ventas = new Ventas();
            ventas.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Entradita prub = new Entradita();
            prub.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            InventarioForm inventario = new InventarioForm();
            inventario.ShowDialog();
        }

        private void retirosDeCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contraseña contra = new Contraseña();
            contra.ShowDialog();
            if ((contra.Aux == true) && (contra.seguridad == true))
            {
                ModificacionCajaChica modi = new ModificacionCajaChica();
                modi.ShowDialog();
            }

            
           
        }

        private void estatusDeCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormVer ver = new FormVer();
            ver.ShowDialog();
        }

        private void Inicial_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Contraseña contra = new Contraseña();
            contra.ShowDialog();
            if ((contra.Aux == true) && (contra.seguridad == true))
            {
                ModificarAgregar add = new ModificarAgregar();
                add.ShowDialog();
            }
        }
    }
}
