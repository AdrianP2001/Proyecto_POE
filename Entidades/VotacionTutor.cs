using System;

namespace TutoriasApp.Entidades
{
    /// <summary>
    /// Entidad que representa el voto de un estudiante a un tutor (escala 1-5).
    /// </summary>
    public class VotacionTutor
    {
        public int IdVoto { get; set; }
        public int IdTutor { get; set; }
        public int Calificacion { get; set; }
        public DateTime FechaVoto { get; set; }

        public VotacionTutor() { }

        public VotacionTutor(int idTutor, int calificacion)
        {
            IdTutor = idTutor;
            Calificacion = calificacion;
            FechaVoto = DateTime.Now;
        }
    }
}
