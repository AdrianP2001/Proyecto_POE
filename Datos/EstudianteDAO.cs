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

        public Estudiante ObtenerOCrearPorNombre(string nombreCompleto)
        {
            if (string.IsNullOrWhiteSpace(nombreCompleto))
                throw new ArgumentException("El nombre del estudiante es obligatorio.");

            string[] partes = nombreCompleto.Trim().Split(new char[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries);
            string nombres = partes[0];
            string apellidos = partes.Length > 1 ? partes[1] : "Estudiante";

            using (SqlConnection conn = _conexion.LeerConexion())
            {
                conn.Open();
                string querySelect = "SELECT IdEstudiante, Matricula, Nombres, Apellidos, Email, Activo FROM Estudiantes WHERE Nombres = @Nombres AND Apellidos = @Apellidos AND Activo = 1";
                using (SqlCommand cmd = new SqlCommand(querySelect, conn))
                {
                    cmd.Parameters.AddWithValue("@Nombres", nombres);
                    cmd.Parameters.AddWithValue("@Apellidos", apellidos);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Estudiante
                            {
                                IdEstudiante = Convert.ToInt32(reader["IdEstudiante"]),
                                Matricula = reader["Matricula"].ToString(),
                                Nombres = reader["Nombres"].ToString(),
                                Apellidos = reader["Apellidos"].ToString(),
                                Email = reader["Email"]?.ToString() ?? string.Empty,
                                Activo = Convert.ToBoolean(reader["Activo"])
                            };
                        }
                    }
                }

                string matriculaNueva = "EST" + DateTime.Now.ToString("yyyyMMddHHmmss");
                string queryInsert = "INSERT INTO Estudiantes (Matricula, Nombres, Apellidos, Email, Activo) " +
                                     "OUTPUT INSERTED.IdEstudiante VALUES (@Matricula, @Nombres, @Apellidos, @Email, 1)";
                using (SqlCommand cmd = new SqlCommand(queryInsert, conn))
                {
                    cmd.Parameters.AddWithValue("@Matricula", matriculaNueva);
                    cmd.Parameters.AddWithValue("@Nombres", nombres);
                    cmd.Parameters.AddWithValue("@Apellidos", apellidos);
                    cmd.Parameters.AddWithValue("@Email", nombres.ToLower() + "." + apellidos.ToLower() + "@tutorias.edu");
                    int newId = (int)cmd.ExecuteScalar();
                    return new Estudiante
                    {
                        IdEstudiante = newId,
                        Matricula = matriculaNueva,
                        Nombres = nombres,
                        Apellidos = apellidos,
                        Email = nombres.ToLower() + "." + apellidos.ToLower() + "@tutorias.edu",
                        Activo = true
                    };
                }
            }
        }
    }
}
