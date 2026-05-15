using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using Proyecto_POE.Datos;

namespace Proyecto_POE.Negocio
{
    /// <summary>
    /// Clase de diagnóstico para asegurar que el entorno de desarrollo es correcto.
    /// Útil para los compañeros de equipo tras un 'git pull'.
    /// </summary>
    public class DepuradorSistema
    {
        public static List<string> EjecutarDiagnostico()
        {
            List<string> logs = new List<string>();
            logs.Add($"--- Diagnóstico iniciado: {DateTime.Now} ---");

            // 1. Verificar Conexión a Base de Datos
            try
            {
                ConexionBD con = new ConexionBD();
                using (var sqlCon = con.LeerConexion())
                {
                    sqlCon.Open();
                    logs.Add("[OK] Conexión a SQL Server exitosa.");
                }
            }
            catch (Exception ex)
            {
                logs.Add($"[ERROR] SQL Server no responde: {ex.Message}");
                logs.Add("   SUGERENCIA: Verifica el 'Data Source' en App.config y que SQL esté iniciado.");
            }

            // 2. Verificar Librerías (iText)
            try
            {
                // Intentamos instanciar algo de la librería PDF
                var writer = new iText.Kernel.Pdf.PdfWriter(new MemoryStream());
                logs.Add("[OK] Librería iText7 (PDF) cargada correctamente.");
            }
            catch
            {
                logs.Add("[ERROR] Librería iText7 no encontrada.");
                logs.Add("   SUGERENCIA: Clic derecho en Solución > Restaurar paquetes NuGet.");
            }

            // 3. Verificar Tablas Críticas
            string[] tablas = { "SesionesTutoria", "Asignaturas", "Tutores", "Estudiantes" };
            ConexionBD con2 = new ConexionBD();
            using (var sqlCon = con2.LeerConexion())
            {
                try
                {
                    sqlCon.Open();
                    foreach (var tabla in tablas)
                    {
                        var cmd = new SqlCommand($"SELECT TOP 1 * FROM {tabla}", sqlCon);
                        cmd.ExecuteNonQuery();
                        logs.Add($"[OK] Tabla '{tabla}' verificada.");
                    }
                }
                catch (Exception ex)
                {
                    logs.Add($"[ERROR] Error en tablas: {ex.Message}");
                    logs.Add("   SUGERENCIA: Ejecuta 'Depurador_DB.sql' en tu base de datos.");
                }
            }

            logs.Add("--- Diagnóstico finalizado ---");
            return logs;
        }

        public static void MostrarReporte()
        {
            var logs = EjecutarDiagnostico();
            string mensaje = string.Join("\n", logs);
            MessageBox.Show(mensaje, "Depurador de Sistema - Proyecto_POE", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
