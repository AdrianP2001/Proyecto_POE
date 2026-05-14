using System;

namespace Proyecto_POE.Entidades
{
    public class EstudianteSesion
    {
        public int IdInscripcion { get; set; }
        public int IdEstudiante { get; set; }
        public int IdSesion { get; set; }
        public bool Asistencia { get; set; }
        public bool Activo { get; set; }

        public EstudianteSesion()
        {
            Asistencia = false;
            Activo = true;
        }
    }
}
