using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VentasLibros
{  /* Comentarios 8569*/
    /* Pasamos a branch "panic" y arreglamos problema grave */
    /* segundo commit en branch "panic" */
    /* 3er commit ya en "master" */
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmVentasLibros());
        }
    }
}
