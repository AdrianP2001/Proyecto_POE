using System;
using System.Windows.Forms;
using Proyecto_POE.Presentacion;
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

            // Inicializar o actualizar la base de datos automáticamente si es necesario
            try
            {
                new Datos.ConexionBD().InicializarBaseDeDatos();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al inicializar la base de datos al inicio: " + ex.Message);
            }

            Application.Run(new FrmMenuPrincipal());
        }
    }
}
