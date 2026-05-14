using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Proyecto_POE.Entidades;

namespace Proyecto_POE.Datos
{
    public class GaleriaDAO
    {
        private ConexionBD _conexion = new ConexionBD();

        public List<ImagenGaleria> ObtenerTodas()
        {
            List<ImagenGaleria> lista = new List<ImagenGaleria>();
            using (SqlConnection conn = _conexion.LeerConexion())
            {
                string query = "SELECT IdImagen, IdActividad, Titulo, RutaLocal, FechaSubida, Activo FROM Galeria WHERE Activo = 1";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new ImagenGaleria
                        {
                            IdImagen = Convert.ToInt32(reader["IdImagen"]),
                            IdActividad = reader["IdActividad"] != DBNull.Value ? Convert.ToInt32(reader["IdActividad"]) : (int?)null,
                            Titulo = reader["Titulo"].ToString(),
                            RutaLocal = reader["RutaLocal"].ToString(),
                            FechaSubida = Convert.ToDateTime(reader["FechaSubida"]),
                            Activo = Convert.ToBoolean(reader["Activo"])
                        });
                    }
                }
            }
            return lista;
        }
    }
}
