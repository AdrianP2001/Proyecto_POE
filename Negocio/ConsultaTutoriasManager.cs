using System.Collections.Generic;
using TutoriasApp.Datos;
using TutoriasApp.Entidades;

namespace TutoriasApp.Negocio
{
    /// <summary>
    /// Orquesta la consulta de materias, grupos y su detalle completo (tutores, horarios, recursos).
    /// </summary>
    public class ConsultaTutoriasManager
    {
        private readonly GrupoEstudioDAO _grupoDAO = new GrupoEstudioDAO();
        private readonly TutorDAO _tutorDAO = new TutorDAO();
        private readonly FacultadDAO _facultadDAO = new FacultadDAO();

        public List<GrupoEstudio> ObtenerTodos() => _grupoDAO.Listar();

        public List<Facultad> ObtenerFacultades() => _facultadDAO.Listar();

        /// <summary>
        /// Carga el detalle completo de un grupo: tutores, horarios y recursos.
        /// </summary>
        public GrupoEstudio? ObtenerDetalleCompleto(int idGrupo)
        {
            var grupo = _grupoDAO.ObtenerDetalle(idGrupo);
            if (grupo == null) return null;

            grupo.Tutores = _tutorDAO.ListarPorGrupo(idGrupo);
            grupo.Horarios = _grupoDAO.ListarHorariosDeGrupo(idGrupo);
            grupo.Recursos = _grupoDAO.ListarRecursosDeGrupo(idGrupo);
            return grupo;
        }
    }
}
