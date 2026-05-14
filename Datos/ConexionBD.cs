using System.Configuration;
using System.Data.SqlClient;

namespace Proyecto_POE.Datos
{
    public class ConexionBD
    {
        // Se recomienda usar App.config para la cadena de conexión
        private string cadenaConexion = ConfigurationManager.ConnectionStrings["TutoriaConn"]?.ConnectionString 
                                        ?? "Server=.;Database=TutoriasDB;Integrated Security=True";

        public SqlConnection LeerConexion()
        {
            return new SqlConnection(cadenaConexion);
        }
    }
}
