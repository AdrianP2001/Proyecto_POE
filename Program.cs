using System;
using System.Windows.Forms;
using Proyecto_POE.Presentacion;

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

                string mensaje = "No se pudo establecer conexión con la base de datos SQL Server.\n\n" +
                                 "Se intentaron las siguientes conexiones:\n" +
                                 "1. Servidor configurado en App.config.\n" +
                                 "2. Servidor LocalDB de Visual Studio ((localdb)\\MSSQLLocalDB).\n" +
                                 "3. Servidor local SQLEXPRESS (.\\SQLEXPRESS).\n\n" +
                                 $"Detalles del error: {ex.Message}\n\n" +
                                 "Asegúrese de que el servicio de SQL Server esté iniciado y configurado de acuerdo a su entorno.\n\n" +
                                 "¿Desea iniciar la aplicación de todos modos? (Nota: Las funciones de datos fallarán si no hay base de datos).";

                DialogResult resultado = MessageBox.Show(
                    mensaje, 
                    "Error de Conexión de Base de Datos", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Warning
                );

                if (resultado == DialogResult.No)
                {
                    return; // Sale del programa
                }
            }

            Application.Run(new FrmMenuPrincipal());
        }
    }
}
