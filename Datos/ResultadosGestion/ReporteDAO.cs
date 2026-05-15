using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Proyecto_POE.Datos;
using Proyecto_POE.Entidades.ResultadosGestion;

namespace Proyecto_POE.Datos.ResultadosGestion
{
    public class ReporteDAO
    {
        private ConexionBD conexion = new ConexionBD();

        public List<ReporteImpacto> ObtenerImpactoPorMateria()
        {
            List<ReporteImpacto> lista = new List<ReporteImpacto>();
            using (var conn = conexion.LeerConexion())
            {
                // Query complejo que agrupa por asignatura y cuenta sesiones, asistentes y promedio de feedback
                string query = @"
                    SELECT 
                        A.Nombre AS Asignatura,
                        A.Facultad,
                        COUNT(DISTINCT S.IdSesion) AS TotalSesiones,
                        COUNT(ES.IdEstudiante) AS TotalAsistentes,
                        AVG(CAST(F.Calificacion AS FLOAT)) AS PromedioCalificacion
                    FROM Asignaturas A
                    LEFT JOIN SesionesTutoria S ON A.IdAsignatura = S.IdAsignatura
                    LEFT JOIN Estudiante_Sesiones ES ON S.IdSesion = ES.IdSesion AND ES.Asistencia = 1
                    LEFT JOIN Feedback F ON S.IdSesion = F.IdSesion
                    WHERE A.Activo = 1
                    GROUP BY A.Nombre, A.Facultad
                    ORDER BY TotalAsistentes DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new ReporteImpacto
                        {
                            NombreAsignatura = reader["Asignatura"].ToString() ?? "N/A",
                            Facultad = reader["Facultad"]?.ToString() ?? "N/A",
                            TotalSesiones = (int)reader["TotalSesiones"],
                            TotalAsistentes = (int)reader["TotalAsistentes"],
                            PromedioCalificacion = reader["PromedioCalificacion"] != DBNull.Value 
                                                  ? (double)reader["PromedioCalificacion"] : 0
                        });
                    }
                }
            }
            return lista;
        }
    }
}
