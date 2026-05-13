using System;

namespace TutoriasApp.Entidades
{
    public class Sesion
    {
        public int ID { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public string Ubicacion { get; set; }
        public int OrdenSecuencial { get; set; }

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
