using System;

namespace Proyecto_POE.Entidades
{
    public class Tutor
    {
        public int IdTutor { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Especialidad { get; set; }
        public string FotoRuta { get; set; } = string.Empty;
        public bool Activo { get; set; }

        public Tutor()
        {
            Activo = true;
        }
    }
}
