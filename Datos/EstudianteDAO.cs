using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Proyecto_POE.Entidades;

namespace Proyecto_POE.Datos
{
    public class EstudianteDAO
    {
        private ConexionBD _conexion = new ConexionBD();

        public Estudiante ObtenerPorId(int idEstudiante)
        {
            Estudiante est = null;
            using (SqlConnection conn = _conexion.LeerConexion())
            {
                string query = "SELECT IdEstudiante, Matricula, Nombres, Apellidos, Email, Activo FROM Estudiantes WHERE IdEstudiante = @Id AND Activo = 1";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", idEstudiante);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        est = new Estudiante
                        {
                            IdEstudiante = Convert.ToInt32(reader["IdEstudiante"]),
                            Matricula = reader["Matricula"].ToString(),
                            Nombres = reader["Nombres"].ToString(),
                            Apellidos = reader["Apellidos"].ToString(),
                            Email = reader["Email"].ToString(),
                            Activo = Convert.ToBoolean(reader["Activo"])
                        };
                    }
                }
            }
            return est;
        }
    }
}
