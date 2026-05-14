using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TutoriasApp.Entidades;

namespace TutoriasApp.Datos
{
    public class GrupoEstudioDAO
    {
        private readonly ConexionBD _conexion = new ConexionBD();

        private const string BaseSelect = @"
            SELECT g.IdGrupo, g.IdMateria, m.Nombre AS NombreMateria, g.Descripcion, g.Cupo
            FROM GruposEstudio g INNER JOIN Materias m ON g.IdMateria = m.IdMateria";

        public List<GrupoEstudio> Listar()
        {
            var lista = new List<GrupoEstudio>();
            using (var conn = _conexion.LeerConexion())
            {
                var cmd = new SqlCommand(BaseSelect + " ORDER BY m.Nombre, g.IdGrupo", conn);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read()) lista.Add(Map(r));
            }
            return lista;
        }

        public List<GrupoEstudio> ListarProximos(int? idFacultad = null)
        {
            var lista = new List<GrupoEstudio>();
            using (var conn = _conexion.LeerConexion())
            {
                string sql = BaseSelect + @"
                    INNER JOIN HorariosGrupo hg ON g.IdGrupo = hg.IdGrupo
                    INNER JOIN SesionesTutoria s ON hg.IdSesion = s.IdSesion
                    WHERE s.Fecha >= CAST(GETDATE() AS DATE)";
                if (idFacultad.HasValue) sql += " AND m.IdFacultad = @idFac";
                sql += " ORDER BY m.Nombre";

                var cmd = new SqlCommand(sql, conn);
                if (idFacultad.HasValue) cmd.Parameters.AddWithValue("@idFac", idFacultad.Value);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read()) lista.Add(Map(r));
            }
            return lista;
        }

        public GrupoEstudio? ObtenerDetalle(int idGrupo)
        {
            using (var conn = _conexion.LeerConexion())
            {
                var cmd = new SqlCommand(BaseSelect + " WHERE g.IdGrupo = @id", conn);
                cmd.Parameters.AddWithValue("@id", idGrupo);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    if (r.Read()) return Map(r);
            }
            return null;
        }

        public List<Sesion> ListarHorariosDeGrupo(int idGrupo)
        {
            var lista = new List<Sesion>();
            using (var conn = _conexion.LeerConexion())
            {
                var cmd = new SqlCommand(@"SELECT s.IdSesion, s.Fecha, s.HoraInicio, s.HoraFin, s.Ubicacion, s.OrdenSecuencial
                    FROM SesionesTutoria s INNER JOIN HorariosGrupo hg ON s.IdSesion = hg.IdSesion
                    WHERE hg.IdGrupo = @id ORDER BY s.Fecha, s.HoraInicio", conn);
                cmd.Parameters.AddWithValue("@id", idGrupo);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        lista.Add(new Sesion
                        {
                            ID = (int)r["IdSesion"],
                            Fecha = (DateTime)r["Fecha"],
                            HoraInicio = (TimeSpan)r["HoraInicio"],
                            HoraFin = (TimeSpan)r["HoraFin"],
                            Ubicacion = r["Ubicacion"].ToString() ?? "",
                            OrdenSecuencial = (int)r["OrdenSecuencial"]
                        });
            }
            return lista;
        }

        public List<Recurso> ListarRecursosDeGrupo(int idGrupo)
        {
            var lista = new List<Recurso>();
            using (var conn = _conexion.LeerConexion())
            {
                var cmd = new SqlCommand("SELECT IdRecurso, IdGrupo, Descripcion, Url FROM Recursos WHERE IdGrupo = @id", conn);
                cmd.Parameters.AddWithValue("@id", idGrupo);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        lista.Add(new Recurso
                        {
                            IdRecurso = (int)r["IdRecurso"],
                            IdGrupo = (int)r["IdGrupo"],
                            Descripcion = r["Descripcion"].ToString() ?? "",
                            Url = r["Url"].ToString() ?? ""
                        });
            }
            return lista;
        }

        private static GrupoEstudio Map(SqlDataReader r) => new GrupoEstudio
        {
            IdGrupo = (int)r["IdGrupo"],
            IdMateria = (int)r["IdMateria"],
            NombreMateria = r["NombreMateria"].ToString() ?? "",
            Descripcion = r["Descripcion"]?.ToString() ?? "",
            Cupo = (int)r["Cupo"]
        };
    }
}
