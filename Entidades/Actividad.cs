using System;

namespace Proyecto_POE.Entidades
{
    public class Actividad
    {
        public int IdActividad { get; set; }
        public int? IdAsignatura { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public bool Activo { get; set; }

        public Actividad()
        {
            FechaPublicacion = DateTime.Now;
            Activo = true;
        }
    }
}
