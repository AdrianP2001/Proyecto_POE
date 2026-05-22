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
    }
}
