using System;
using System.Windows.Forms;
using Proyecto_POE.Presentacion.GestionSesiones;

namespace Proyecto_POE
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmGestionSesiones());
        }
    }
}
