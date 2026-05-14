using System;

namespace TutoriasApp.Entidades
{
    /// <summary>
    /// Entidad que representa un comentario o sugerencia de un estudiante.
    /// </summary>
    public class Comentario
    {
        public int IdComentario { get; set; }
        public string NombreEstudiante { get; set; } = string.Empty;
        public string TextoComentario { get; set; } = string.Empty;
        public DateTime FechaRegistro { get; set; }
        public int? IdGrupo { get; set; }

        public Comentario() { }
    }
}
