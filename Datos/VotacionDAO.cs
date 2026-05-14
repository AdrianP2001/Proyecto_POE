using System.Data.SqlClient;
using TutoriasApp.Entidades;

namespace TutoriasApp.Datos
{
    public class VotacionDAO
    {
        private readonly ConexionBD _conexion = new ConexionBD();

        public void Registrar(VotacionTutor voto)
        {
            using (var conn = _conexion.LeerConexion())
            {
                var cmd = new SqlCommand("INSERT INTO VotacionTutor (IdTutor, Calificacion) VALUES (@tutor, @cal)", conn);
                cmd.Parameters.AddWithValue("@tutor", voto.IdTutor);
                cmd.Parameters.AddWithValue("@cal", voto.Calificacion);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
