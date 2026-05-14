using System.Collections.Generic;

namespace TutoriasApp.Entidades
{
    /// <summary>
    /// Entidad que representa un grupo de estudio de tutoría para una materia.
    /// Contiene colecciones de navegación (Tutores, Recursos, Horarios).
    /// </summary>
    public class GrupoEstudio
    {
        public int IdGrupo { get; set; }
        public int IdMateria { get; set; }
        public string NombreMateria { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public int Cupo { get; set; }

        // Colecciones de navegación (cargadas por el Manager)
        public List<Tutor> Tutores { get; set; } = new List<Tutor>();
        public List<Recurso> Recursos { get; set; } = new List<Recurso>();
        public List<Sesion> Horarios { get; set; } = new List<Sesion>();

        public GrupoEstudio() { }

        public override string ToString() => $"{NombreMateria} — {Descripcion}";
    }
}
