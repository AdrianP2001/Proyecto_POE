using System.Collections.Generic;
using System.Data.SqlClient;
using TutoriasApp.Entidades;

namespace TutoriasApp.Datos
{
    public class FacultadDAO
    {
        private readonly ConexionBD _conexion = new ConexionBD();

        public List<Facultad> Listar()
        {
            var lista = new List<Facultad>();
            using (var conn = _conexion.LeerConexion())
            {
                var cmd = new SqlCommand("SELECT IdFacultad, Nombre FROM Facultades ORDER BY Nombre", conn);
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        lista.Add(new Facultad { IdFacultad = (int)reader["IdFacultad"], Nombre = reader["Nombre"].ToString() ?? "" });
            }
            return lista;
        }
    }
}
