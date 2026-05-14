using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TutoriasApp.Entidades;

namespace TutoriasApp.Datos
{
    public class MateriaDAO
    {
        private readonly ConexionBD _conexion = new ConexionBD();

        private const string BaseQuery = @"
            SELECT m.IdMateria, m.Nombre, m.Descripcion, m.FotoPath, m.IdFacultad,
                   f.Nombre AS NombreFacultad
            FROM Materias m
            LEFT JOIN Facultades f ON m.IdFacultad = f.IdFacultad";

        public List<Materia> Listar()
        {
            var lista = new List<Materia>();
            using (var conn = _conexion.LeerConexion())
            {
                var cmd = new SqlCommand(BaseQuery + " ORDER BY m.Nombre", conn);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read()) lista.Add(Map(r));
            }
            return lista;
        }

        public List<Materia> ListarPorFacultad(int idFacultad)
        {
            var lista = new List<Materia>();
            using (var conn = _conexion.LeerConexion())
            {
                var cmd = new SqlCommand(BaseQuery + " WHERE m.IdFacultad = @idFac ORDER BY m.Nombre", conn);
                cmd.Parameters.AddWithValue("@idFac", idFacultad);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read()) lista.Add(Map(r));
            }
            return lista;
        }

        private static Materia Map(SqlDataReader r) => new Materia
        {
            IdMateria = (int)r["IdMateria"],
            Nombre = r["Nombre"].ToString() ?? "",
            Descripcion = r["Descripcion"]?.ToString() ?? "",
            FotoPath = r["FotoPath"]?.ToString() ?? "",
            IdFacultad = r["IdFacultad"] != DBNull.Value ? (int)r["IdFacultad"] : 0,
            NombreFacultad = r["NombreFacultad"]?.ToString() ?? ""
        };
    }
}
