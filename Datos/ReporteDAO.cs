using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Proyecto_POE.Datos;
using Proyecto_POE.Entidades;

namespace Proyecto_POE.Datos
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
                        ISNULL(Stats.TotalSesiones, 0) AS TotalSesiones,
                        ISNULL(Stats.TotalAsistentes, 0) AS TotalAsistentes,
                        ISNULL(Feed.PromedioCalificacion, 0) AS PromedioCalificacion
                    FROM Asignaturas A
                    LEFT JOIN (
                        -- Subconsulta para contar sesiones y asistentes sin duplicar por feedback
                        SELECT 
                            S.IdAsignatura,
                            COUNT(DISTINCT S.IdSesion) AS TotalSesiones,
                            COUNT(ES.IdEstudiante) AS TotalAsistentes
                        FROM SesionesTutoria S
                        LEFT JOIN Estudiante_Sesiones ES ON S.IdSesion = ES.IdSesion AND ES.Asistencia = 1
                        GROUP BY S.IdAsignatura
                    ) Stats ON A.IdAsignatura = Stats.IdAsignatura
                    LEFT JOIN (
                        -- Subconsulta para el promedio de feedback independiente
                        SELECT 
                            S.IdAsignatura,
                            AVG(CAST(F.Calificacion AS FLOAT)) AS PromedioCalificacion
                        FROM SesionesTutoria S
                        JOIN Feedback F ON S.IdSesion = F.IdSesion
                        GROUP BY S.IdAsignatura
                    ) Feed ON A.IdAsignatura = Feed.IdAsignatura
                    WHERE A.Activo = 1
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
