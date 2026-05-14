using System.Collections.Generic;
using TutoriasApp.Datos;
using TutoriasApp.Entidades;

namespace TutoriasApp.Negocio
{
    /// <summary>
    /// Gestiona la galería de fotos de sesiones realizadas.
    /// </summary>
    public class GaleriaManager
    {
        private readonly FotoSesionDAO _fotoDAO = new FotoSesionDAO();

        public List<FotoSesion> ObtenerFotos() => _fotoDAO.ListarTodas();

        public void AgregarFoto(FotoSesion foto) => _fotoDAO.Registrar(foto);
    }
}
