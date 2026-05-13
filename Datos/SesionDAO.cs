using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TutoriasApp.Entidades;

namespace TutoriasApp.Datos
{
    public class SesionDAO
    {
        private ConexionBD conexion = new ConexionBD();

        public void Registrar(Sesion sesion)
        {
            using (var conn = conexion.LeerConexion())
            {
                string query = "INSERT INTO SesionesTutoria (Fecha, HoraInicio, HoraFin, Ubicacion, OrdenSecuencial) " +
                               "VALUES (@fecha, @inicio, @fin, @ubicacion, @orden)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@fecha", sesion.Fecha);
                cmd.Parameters.AddWithValue("@inicio", sesion.HoraInicio);
                cmd.Parameters.AddWithValue("@fin", sesion.HoraFin);
                cmd.Parameters.AddWithValue("@ubicacion", sesion.Ubicacion);
                cmd.Parameters.AddWithValue("@orden", sesion.OrdenSecuencial);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Sesion> Listar()
        {
            List<Sesion> lista = new List<Sesion>();
            using (var conn = conexion.LeerConexion())
            {
                string query = "SELECT * FROM SesionesTutoria ORDER BY OrdenSecuencial ASC";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Sesion
                        {
                            ID = (int)reader["IdSesion"],
                            Fecha = (DateTime)reader["Fecha"],
                            HoraInicio = (TimeSpan)reader["HoraInicio"],
                            HoraFin = (TimeSpan)reader["HoraFin"],
                            Ubicacion = reader["Ubicacion"]?.ToString() ?? string.Empty,
                            OrdenSecuencial = (int)reader["OrdenSecuencial"]
                        });
                    }
                }
            }
            return lista;
        }
    }
}
