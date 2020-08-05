using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyConnection;

namespace Tienda2
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (DbConnection conn = new DbConnection(true))
            {
                if (conn.NuevoIngreso() == true)
                {
                    Application.Run(new Inicial());
                }
                else
                {
                    NuevoIngreso add = new NuevoIngreso();
                    add.ShowDialog();
                }
            }
           
        }
    }
}
