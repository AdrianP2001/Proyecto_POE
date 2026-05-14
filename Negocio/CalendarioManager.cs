using System.Collections.Generic;
using TutoriasApp.Datos;
using TutoriasApp.Entidades;

namespace TutoriasApp.Negocio
{
    /// <summary>
    /// Gestiona la agenda de próximas tutorías con soporte de filtro por facultad.
    /// </summary>
    public class CalendarioManager
    {
        private readonly GrupoEstudioDAO _grupoDAO = new GrupoEstudioDAO();
        private readonly FacultadDAO _facultadDAO = new FacultadDAO();

        public List<Facultad> ObtenerFacultades() => _facultadDAO.Listar();

        /// <summary>
        /// Retorna grupos con sesiones futuras, opcionalmente filtrados por facultad.
        /// </summary>
        public List<GrupoEstudio> ObtenerAgenda(int? idFacultad = null)
            => _grupoDAO.ListarProximos(idFacultad);
    }
}
