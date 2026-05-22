using System.Configuration;
using System.Data.SqlClient;

namespace Proyecto_POE.Datos
{
    public class ConexionBD
    {
        // Se recomienda usar App.config para la cadena de conexión
        private string cadenaConexion = ConfigurationManager.ConnectionStrings["TutoriaConn"]?.ConnectionString 
                                        ?? "Data Source=.;Initial Catalog=TutoriasDB;Integrated Security=True;TrustServerCertificate=True";

        public SqlConnection LeerConexion()
        {
            return new SqlConnection(cadenaConexion);
        }
    }
}
