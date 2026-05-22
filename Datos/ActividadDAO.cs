using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Proyecto_POE.Entidades;

namespace Proyecto_POE.Datos
{
    public class ActividadDAO
    {
        private ConexionBD _conexion = new ConexionBD();

        public List<Actividad> ObtenerActividades(int idAsignatura)
        {
            List<Actividad> lista = new List<Actividad>();
            using (SqlConnection conn = _conexion.LeerConexion())
            {
                string query = "SELECT IdActividad, IdAsignatura, Titulo, Descripcion, FechaPublicacion, FechaVencimiento, Activo " +
                               "FROM Actividades WHERE IdAsignatura = @IdAsignatura AND Activo = 1";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdAsignatura", idAsignatura);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Actividad
                        {
                            IdActividad = Convert.ToInt32(reader["IdActividad"]),
                            IdAsignatura = reader["IdAsignatura"] != DBNull.Value ? Convert.ToInt32(reader["IdAsignatura"]) : (int?)null,
                            Titulo = reader["Titulo"].ToString(),
                            Descripcion = reader["Descripcion"].ToString(),
                            FechaPublicacion = Convert.ToDateTime(reader["FechaPublicacion"]),
                            FechaVencimiento = reader["FechaVencimiento"] != DBNull.Value ? Convert.ToDateTime(reader["FechaVencimiento"]) : (DateTime?)null,
                            Activo = Convert.ToBoolean(reader["Activo"])
                        });
                    }
                }
            }
            return lista;
        }
    }
}
