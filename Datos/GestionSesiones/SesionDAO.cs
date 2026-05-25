using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Proyecto_POE.Datos;
using Proyecto_POE.Entidades.GestionSesiones;

namespace Proyecto_POE.Datos.GestionSesiones
{
    public class SesionDAO
    {
        private ConexionBD conexion = new ConexionBD();

        public void Registrar(Sesion sesion)
        {
            using (var conn = conexion.LeerConexion())
            {
                string query = "INSERT INTO SesionesTutoria (Fecha, HoraInicio, HoraFin, Ubicacion, OrdenSecuencial, IdAsignatura, IdTutor, Activo) " +
                               "VALUES (@fecha, @inicio, @fin, @ubicacion, @orden, @idAsignatura, @idTutor, 1)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@fecha", sesion.Fecha);
                cmd.Parameters.AddWithValue("@inicio", sesion.HoraInicio);
                cmd.Parameters.AddWithValue("@fin", sesion.HoraFin);
                cmd.Parameters.AddWithValue("@ubicacion", sesion.Ubicacion);
                cmd.Parameters.AddWithValue("@orden", sesion.OrdenSecuencial);
                cmd.Parameters.AddWithValue("@idAsignatura", (object)sesion.IdAsignatura ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@idTutor", (object)sesion.IdTutor ?? DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Sesion> Listar()
        {
            List<Sesion> lista = new List<Sesion>();
            using (var conn = conexion.LeerConexion())
            {
                string query = @"
                    SELECT s.IdSesion, s.Fecha, s.HoraInicio, s.HoraFin, s.Ubicacion, s.OrdenSecuencial, s.IdAsignatura, s.IdTutor,
                           a.Nombre AS AsignaturaNombre,
                           t.Nombres + ' ' + t.Apellidos AS TutorNombre
                    FROM SesionesTutoria s
                    LEFT JOIN Asignaturas a ON s.IdAsignatura = a.IdAsignatura
                    LEFT JOIN Tutores t ON s.IdTutor = t.IdTutor
                    WHERE s.Activo = 1
                    ORDER BY s.OrdenSecuencial ASC";
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
                            OrdenSecuencial = (int)reader["OrdenSecuencial"],
                            IdAsignatura = reader["IdAsignatura"] != DBNull.Value ? (int?)reader["IdAsignatura"] : null,
                            IdTutor = reader["IdTutor"] != DBNull.Value ? (int?)reader["IdTutor"] : null,
                            AsignaturaNombre = reader["AsignaturaNombre"]?.ToString() ?? string.Empty,
                            TutorNombre = reader["TutorNombre"]?.ToString() ?? string.Empty
                        });
                    }
                }
            }
            return lista;
        }

        public List<Sesion> ObtenerPorAsignatura(int idAsignatura)
        {
            List<Sesion> lista = new List<Sesion>();
            using (var conn = conexion.LeerConexion())
            {
                string query = @"
                    SELECT s.IdSesion, s.Fecha, s.HoraInicio, s.HoraFin, s.Ubicacion, s.OrdenSecuencial, s.IdAsignatura, s.IdTutor,
                           a.Nombre AS AsignaturaNombre,
                           t.Nombres + ' ' + t.Apellidos AS TutorNombre
                    FROM SesionesTutoria s
                    LEFT JOIN Asignaturas a ON s.IdAsignatura = a.IdAsignatura
                    LEFT JOIN Tutores t ON s.IdTutor = t.IdTutor
                    WHERE s.IdAsignatura = @IdAsignatura AND s.Activo = 1
                    ORDER BY s.Fecha ASC, s.HoraInicio ASC";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdAsignatura", idAsignatura);
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
                            OrdenSecuencial = (int)reader["OrdenSecuencial"],
                            IdAsignatura = reader["IdAsignatura"] != DBNull.Value ? (int?)reader["IdAsignatura"] : null,
                            IdTutor = reader["IdTutor"] != DBNull.Value ? (int?)reader["IdTutor"] : null,
                            AsignaturaNombre = reader["AsignaturaNombre"]?.ToString() ?? string.Empty,
                            TutorNombre = reader["TutorNombre"]?.ToString() ?? string.Empty
                        });
                    }
                }
            }
            return lista;
        }

        public int ObtenerOCrearSesionParaAsignatura(int idAsignatura)
        {
            using (SqlConnection conn = conexion.LeerConexion())
            {
                conn.Open();
                string querySelect = "SELECT TOP 1 IdSesion FROM SesionesTutoria WHERE IdAsignatura = @IdAsignatura AND Activo = 1";
                if (idAsignatura <= 0)
                {
                    querySelect = "SELECT TOP 1 IdSesion FROM SesionesTutoria WHERE Activo = 1";
                }
                
                using (SqlCommand cmd = new SqlCommand(querySelect, conn))
                {
                    if (idAsignatura > 0)
                        cmd.Parameters.AddWithValue("@IdAsignatura", idAsignatura);
                    
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToInt32(result);
                    }
                }

                int? idTutor = null;
                string queryTutor = "SELECT TOP 1 IdTutor FROM Tutores WHERE Activo = 1";
                using (SqlCommand cmd = new SqlCommand(queryTutor, conn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        idTutor = Convert.ToInt32(result);
                    }
                }

                if (idTutor == null)
                {
                    string queryInsertTutor = "INSERT INTO Tutores (Nombres, Apellidos, Especialidad, Activo) OUTPUT INSERTED.IdTutor VALUES ('Tutor', 'General', 'Multidisciplinario', 1)";
                    using (SqlCommand cmd = new SqlCommand(queryInsertTutor, conn))
                    {
                        idTutor = (int)cmd.ExecuteScalar();
                    }
                }

                int finalIdAsignatura = idAsignatura;
                if (finalIdAsignatura <= 0)
                {
                    string queryAsig = "SELECT TOP 1 IdAsignatura FROM Asignaturas WHERE Activo = 1";
                    using (SqlCommand cmd = new SqlCommand(queryAsig, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            finalIdAsignatura = Convert.ToInt32(result);
                        }
                    }
                }

                if (finalIdAsignatura <= 0)
                {
                    string queryInsertAsig = "INSERT INTO Asignaturas (Codigo, Nombre, Activo) OUTPUT INSERTED.IdAsignatura VALUES ('GEN001', 'General', 1)";
                    using (SqlCommand cmd = new SqlCommand(queryInsertAsig, conn))
                    {
                        finalIdAsignatura = (int)cmd.ExecuteScalar();
                    }
                }

                string queryInsertSesion = @"
                    INSERT INTO SesionesTutoria (IdAsignatura, IdTutor, Fecha, HoraInicio, HoraFin, Ubicacion, OrdenSecuencial, Activo)
                    OUTPUT INSERTED.IdSesion
                    VALUES (@IdAsig, @IdTutor, @Fecha, '12:00:00', '13:00:00', 'Aula Virtual', 1, 1)";
                using (SqlCommand cmd = new SqlCommand(queryInsertSesion, conn))
                {
                    cmd.Parameters.AddWithValue("@IdAsig", finalIdAsignatura);
                    cmd.Parameters.AddWithValue("@IdTutor", idTutor);
                    cmd.Parameters.AddWithValue("@Fecha", DateTime.Today);
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public int ObtenerOCrearSesionParaTutor(int idTutor)
        {
            using (SqlConnection conn = conexion.LeerConexion())
            {
                conn.Open();
                string querySelect = "SELECT TOP 1 IdSesion FROM SesionesTutoria WHERE IdTutor = @IdTutor AND Activo = 1";
                using (SqlCommand cmd = new SqlCommand(querySelect, conn))
                {
                    cmd.Parameters.AddWithValue("@IdTutor", idTutor);
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToInt32(result);
                    }
                }

                int? idAsignatura = null;
                string queryAsig = "SELECT TOP 1 IdAsignatura FROM Asignaturas WHERE Activo = 1";
                using (SqlCommand cmd = new SqlCommand(queryAsig, conn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        idAsignatura = Convert.ToInt32(result);
                    }
                }

                if (idAsignatura == null)
                {
                    string queryInsertAsig = "INSERT INTO Asignaturas (Codigo, Nombre, Activo) OUTPUT INSERTED.IdAsignatura VALUES ('GEN001', 'General', 1)";
                    using (SqlCommand cmd = new SqlCommand(queryInsertAsig, conn))
                    {
                        idAsignatura = (int)cmd.ExecuteScalar();
                    }
                }

                string queryInsertSesion = @"
                    INSERT INTO SesionesTutoria (IdAsignatura, IdTutor, Fecha, HoraInicio, HoraFin, Ubicacion, OrdenSecuencial, Activo)
                    OUTPUT INSERTED.IdSesion
                    VALUES (@IdAsig, @IdTutor, @Fecha, '12:00:00', '13:00:00', 'Aula Virtual', 1, 1)";
                using (SqlCommand cmd = new SqlCommand(queryInsertSesion, conn))
                {
                    cmd.Parameters.AddWithValue("@IdAsig", idAsignatura);
                    cmd.Parameters.AddWithValue("@IdTutor", idTutor);
                    cmd.Parameters.AddWithValue("@Fecha", DateTime.Today);
                    return (int)cmd.ExecuteScalar();
                }
            }
        }
    }
}
