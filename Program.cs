using System;
using System.Windows.Forms;
using TutoriasApp.Presentacion.GestionSesiones;

namespace TutoriasApp
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
