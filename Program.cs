using System;
using System.Windows.Forms;
using Proyecto_POE.Presentacion.GestionSesiones;
using Proyecto_POE.Presentacion.ResultadosGestion;

namespace Proyecto_POE
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Ejecutar diagnóstico al inicio para ayudar a los compañeros
            DepuradorSistema.MostrarReporte();

            Application.Run(new FrmResultadosGestion());
        }
    }
}
