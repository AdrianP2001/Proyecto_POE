using System;

namespace Proyecto_POE.Entidades.GestionSesiones
{
    public class Sesion
    {
        public int ID { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public string Ubicacion { get; set; } = string.Empty;
        public int OrdenSecuencial { get; set; }
        public int? IdAsignatura { get; set; }
        public int? IdTutor { get; set; }
        public string AsignaturaNombre { get; set; } = string.Empty;
        public string TutorNombre { get; set; } = string.Empty;

        public Sesion() { }

        public Sesion(DateTime fecha, TimeSpan inicio, TimeSpan fin, string ubicacion)
        {
            this.Fecha = fecha;
            this.HoraInicio = inicio;
            this.HoraFin = fin;
            this.Ubicacion = ubicacion;
        }
    }
}
