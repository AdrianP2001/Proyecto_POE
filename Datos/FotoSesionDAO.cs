using System.Collections.Generic;
using System.Data.SqlClient;
using TutoriasApp.Entidades;

namespace TutoriasApp.Datos
{
    public class FotoSesionDAO
    {
        private readonly ConexionBD _conexion = new ConexionBD();

        public List<FotoSesion> ListarTodas()
        {
            var lista = new List<FotoSesion>();
            using (var conn = _conexion.LeerConexion())
            {
                var cmd = new SqlCommand("SELECT IdFoto, IdSesion, RutaImagen, Descripcion FROM FotosSesion ORDER BY IdFoto", conn);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        lista.Add(new FotoSesion
                        {
                            IdFoto = (int)r["IdFoto"],
                            IdSesion = (int)r["IdSesion"],
                            RutaImagen = r["RutaImagen"].ToString() ?? "",
                            Descripcion = r["Descripcion"]?.ToString() ?? ""
                        });
            }
            return lista;
        }

        public void Registrar(FotoSesion foto)
        {
            using (var conn = _conexion.LeerConexion())
            {
                var cmd = new SqlCommand("INSERT INTO FotosSesion (IdSesion, RutaImagen, Descripcion) VALUES (@ses, @ruta, @desc)", conn);
                cmd.Parameters.AddWithValue("@ses", foto.IdSesion);
                cmd.Parameters.AddWithValue("@ruta", foto.RutaImagen);
                cmd.Parameters.AddWithValue("@desc", foto.Descripcion);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
