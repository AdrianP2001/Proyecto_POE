using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TutoriasApp.Entidades;

namespace TutoriasApp.Datos
{
    public class TutorDAO
    {
        private readonly ConexionBD _conexion = new ConexionBD();

        public List<Tutor> Listar()
        {
            var lista = new List<Tutor>();
            using (var conn = _conexion.LeerConexion())
            {
                var cmd = new SqlCommand("SELECT IdTutor, Nombre, Especialidad, FotoPath, Email FROM Tutores ORDER BY Nombre", conn);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read()) lista.Add(Map(r));
            }
            return lista;
        }

        public List<Tutor> ListarPorGrupo(int idGrupo)
        {
            var lista = new List<Tutor>();
            using (var conn = _conexion.LeerConexion())
            {
                var cmd = new SqlCommand(@"SELECT t.IdTutor, t.Nombre, t.Especialidad, t.FotoPath, t.Email
                    FROM Tutores t INNER JOIN GrupoTutores gt ON t.IdTutor = gt.IdTutor
                    WHERE gt.IdGrupo = @id", conn);
                cmd.Parameters.AddWithValue("@id", idGrupo);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read()) lista.Add(Map(r));
            }
            return lista;
        }

        public Tutor? ObtenerTutorDelMes()
        {
            using (var conn = _conexion.LeerConexion())
            {
                var cmd = new SqlCommand(@"SELECT TOP 1 t.IdTutor, t.Nombre, t.Especialidad, t.FotoPath, t.Email,
                        AVG(CAST(v.Calificacion AS FLOAT)) AS Promedio
                    FROM Tutores t INNER JOIN VotacionTutor v ON t.IdTutor = v.IdTutor
                    WHERE MONTH(v.FechaVoto) = MONTH(GETDATE()) AND YEAR(v.FechaVoto) = YEAR(GETDATE())
                    GROUP BY t.IdTutor, t.Nombre, t.Especialidad, t.FotoPath, t.Email
                    ORDER BY Promedio DESC", conn);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    if (r.Read())
                    {
                        var tutor = Map(r);
                        tutor.PromedioVotos = (double)r["Promedio"];
                        return tutor;
                    }
                }
            }
            return null;
        }

        private static Tutor Map(SqlDataReader r) => new Tutor
        {
            IdTutor = (int)r["IdTutor"],
            Nombre = r["Nombre"].ToString() ?? "",
            Especialidad = r["Especialidad"]?.ToString() ?? "",
            FotoPath = r["FotoPath"]?.ToString() ?? "",
            Email = r["Email"]?.ToString() ?? ""
        };
    }
}
