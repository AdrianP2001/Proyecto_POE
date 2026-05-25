using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Proyecto_POE.Entidades;

namespace Proyecto_POE.Datos
{
    public class TutorDAO
    {
        private ConexionBD _conexion = new ConexionBD();

        public List<Tutor> ObtenerTodos()
        {
            List<Tutor> lista = new List<Tutor>();
            using (SqlConnection conn = _conexion.LeerConexion())
            {
                string query = "SELECT IdTutor, Nombres, Apellidos, Especialidad, Activo FROM Tutores WHERE Activo = 1";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Tutor
                        {
                            IdTutor = Convert.ToInt32(reader["IdTutor"]),
                            Nombres = reader["Nombres"].ToString(),
                            Apellidos = reader["Apellidos"].ToString(),
                            Especialidad = reader["Especialidad"].ToString(),
                            Activo = Convert.ToBoolean(reader["Activo"])
                        });
                    }
                }
            }
            return lista;
        }

        public List<Tutor> ObtenerPorAsignatura(int idAsignatura)
        {
            List<Tutor> lista = new List<Tutor>();
            using (SqlConnection conn = _conexion.LeerConexion())
            {
                string query = @"
                    SELECT DISTINCT t.IdTutor, t.Nombres, t.Apellidos, t.Especialidad, t.Activo 
                    FROM Tutores t
                    INNER JOIN SesionesTutoria s ON t.IdTutor = s.IdTutor
                    WHERE s.IdAsignatura = @IdAsignatura AND t.Activo = 1 AND s.Activo = 1";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdAsignatura", idAsignatura);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Tutor
                        {
                            IdTutor = Convert.ToInt32(reader["IdTutor"]),
                            Nombres = reader["Nombres"].ToString(),
                            Apellidos = reader["Apellidos"].ToString(),
                            Especialidad = reader["Especialidad"].ToString(),
                            Activo = Convert.ToBoolean(reader["Activo"])
                        });
                    }
                }
            }
            return lista;
        }

        public Tuple<Tutor, double> ObtenerTutorDelMes()
        {
            using (SqlConnection conn = _conexion.LeerConexion())
            {
                string query = @"
                    SELECT TOP 1 t.IdTutor, t.Nombres, t.Apellidos, t.Especialidad, AVG(CAST(f.Calificacion AS FLOAT)) AS Promedio
                    FROM Feedback f
                    INNER JOIN SesionesTutoria s ON f.IdSesion = s.IdSesion
                    INNER JOIN Tutores t ON s.IdTutor = t.IdTutor
                    WHERE f.Activo = 1 AND s.Activo = 1 AND t.Activo = 1
                    GROUP BY t.IdTutor, t.Nombres, t.Apellidos, t.Especialidad
                    ORDER BY Promedio DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var tutor = new Tutor
                        {
                            IdTutor = Convert.ToInt32(reader["IdTutor"]),
                            Nombres = reader["Nombres"].ToString(),
                            Apellidos = reader["Apellidos"].ToString(),
                            Especialidad = reader["Especialidad"].ToString(),
                            Activo = true
                        };
                        double promedio = Convert.ToDouble(reader["Promedio"]);
                        return new Tuple<Tutor, double>(tutor, promedio);
                    }
                }
            }
            return null;
        }
    }
}
