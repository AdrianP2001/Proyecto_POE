using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Proyecto_POE.Entidades;

namespace Proyecto_POE.Datos
{
    public class FeedbackDAO
    {
        private ConexionBD _conexion = new ConexionBD();

        public void InsertarFeedback(Feedback f)
        {
            using (SqlConnection conn = _conexion.LeerConexion())
            {
                string query = "INSERT INTO Feedback (IdEstudiante, IdSesion, Calificacion, Comentarios, FechaRegistro, Activo) " +
                               "VALUES (@IdEst, @IdSesion, @Calificacion, @Comentarios, @Fecha, @Activo)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdEst", f.IdEstudiante);
                cmd.Parameters.AddWithValue("@IdSesion", f.IdSesion);
                cmd.Parameters.AddWithValue("@Calificacion", f.Calificacion);
                cmd.Parameters.AddWithValue("@Comentarios", f.Comentarios ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Fecha", f.FechaRegistro);
                cmd.Parameters.AddWithValue("@Activo", f.Activo);
                
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
