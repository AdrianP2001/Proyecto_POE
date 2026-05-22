using System;

namespace Proyecto_POE.Entidades
{
    public class Feedback
    {
        public int IdFeedback { get; set; }
        public int IdEstudiante { get; set; }
        public int IdSesion { get; set; }
        public int Calificacion { get; set; }
        public string Comentarios { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool Activo { get; set; }

        public Feedback()
        {
            FechaRegistro = DateTime.Now;
            Activo = true;
        }
    }
}
