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
                string query = "SELECT IdAsignatura, Codigo, Nombre, Activo FROM Asignaturas WHERE Activo = 1";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Asignatura
                        {
                            IdAsignatura = Convert.ToInt32(reader["IdAsignatura"]),
                            Codigo = reader["Codigo"].ToString(),
                            Nombre = reader["Nombre"].ToString(),
                            Activo = Convert.ToBoolean(reader["Activo"])
                        });
                    }
                }
            }
            return lista;
        }
    }
}
