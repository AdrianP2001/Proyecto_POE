using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Proyecto_POE.Entidades;

namespace Proyecto_POE.Datos
{
    public class AsignaturaDAO
    {
        private ConexionBD _conexion = new ConexionBD();

        public List<Asignatura> ObtenerTodas()
        {
            List<Asignatura> lista = new List<Asignatura>();
            using (SqlConnection conn = _conexion.LeerConexion())
            {
                string query = "SELECT IdAsignatura, Codigo, Nombre, Facultad, Area, Descripcion, Modalidad, Activo FROM Asignaturas WHERE Activo = 1";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Asignatura
                        {
                            IdAsignatura = Convert.ToInt32(reader["IdAsignatura"]),
                            Codigo = reader["Codigo"]?.ToString() ?? string.Empty,
                            Nombre = reader["Nombre"]?.ToString() ?? string.Empty,
                            Facultad = reader["Facultad"]?.ToString() ?? string.Empty,
                            Area = reader["Area"]?.ToString() ?? string.Empty,
                            Descripcion = reader["Descripcion"]?.ToString() ?? string.Empty,
                            Modalidad = reader["Modalidad"]?.ToString() ?? string.Empty,
                            Activo = Convert.ToBoolean(reader["Activo"])
                        });
                    }
                }
            }
            return lista;
        }

        public bool Insertar(Asignatura asignatura)
        {
            using (SqlConnection conn = _conexion.LeerConexion())
            {
                string query = "INSERT INTO Asignaturas (Codigo, Nombre, Facultad, Area, Descripcion, Modalidad, Activo) " +
                               "VALUES (@Codigo, @Nombre, @Facultad, @Area, @Descripcion, @Modalidad, @Activo)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Codigo", asignatura.Codigo ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Nombre", asignatura.Nombre ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Facultad", asignatura.Facultad ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Area", asignatura.Area ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Descripcion", asignatura.Descripcion ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Modalidad", asignatura.Modalidad ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Activo", asignatura.Activo);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Eliminar(int idAsignatura)
        {
            using (SqlConnection conn = _conexion.LeerConexion())
            {
                string query = "UPDATE Asignaturas SET Activo = 0 WHERE IdAsignatura = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", idAsignatura);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
