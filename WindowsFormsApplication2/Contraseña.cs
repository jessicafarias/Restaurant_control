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
    public partial class Contraseña : Form
    {
        public bool Aux = false;
        public bool seguridad = false;
        public Contraseña()
        {
            InitializeComponent();
            txtContraseña.PasswordChar = '*';
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            using (DbConnection conn = new DbConnection(true))
            {
                List<Socios> list = conn.ObtenerSocios();
                foreach (Socios socio in list)
                {
                    if ((txtUsuario.Text == socio.Nombre) && (txtContraseña.Text == socio.Contraseña))
                    {
                        Aux = true;
                        Close();
                        seguridad = socio.Administrador;
                        break;
                    }
                    else
                    {
                        Aux = false;
                        seguridad = socio.Administrador;
                    }

                }
                if (Aux == false)
                {
                    MessageBox.Show("CONTRASEÑA INVALIDA", "USUARIO Y/O CONTRASEÑA INVALIDA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
