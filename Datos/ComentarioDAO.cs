using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TutoriasApp.Entidades;

namespace TutoriasApp.Datos
{
    public class ComentarioDAO
    {
        private readonly ConexionBD _conexion = new ConexionBD();

        public void Registrar(Comentario comentario)
        {
            using (var conn = _conexion.LeerConexion())
            {
                var cmd = new SqlCommand(@"INSERT INTO Comentarios (NombreEstudiante, Comentario, IdGrupo)
                    VALUES (@nombre, @comentario, @grupo)", conn);
                cmd.Parameters.AddWithValue("@nombre", comentario.NombreEstudiante);
                cmd.Parameters.AddWithValue("@comentario", comentario.TextoComentario);
                cmd.Parameters.AddWithValue("@grupo", comentario.IdGrupo.HasValue ? (object)comentario.IdGrupo.Value : DBNull.Value);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Comentario> Listar()
        {
            var lista = new List<Comentario>();
            using (var conn = _conexion.LeerConexion())
            {
                var cmd = new SqlCommand("SELECT IdComentario, NombreEstudiante, Comentario, FechaRegistro, IdGrupo FROM Comentarios ORDER BY FechaRegistro DESC", conn);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        lista.Add(new Comentario
                        {
                            IdComentario = (int)r["IdComentario"],
                            NombreEstudiante = r["NombreEstudiante"]?.ToString() ?? "",
                            TextoComentario = r["Comentario"].ToString() ?? "",
                            FechaRegistro = (DateTime)r["FechaRegistro"],
                            IdGrupo = r["IdGrupo"] != DBNull.Value ? (int?)r["IdGrupo"] : null
                        });
            }
            return lista;
        }
    }
}
