using System;

namespace Proyecto_POE.Entidades
{
    public class Estudiante
    {
        public int IdEstudiante { get; set; }
        public string Matricula { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public bool Activo { get; set; }

        public Estudiante()
        {
            Activo = true;
        }
    }
}
