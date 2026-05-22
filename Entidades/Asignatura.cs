using System;

namespace Proyecto_POE.Entidades
{
    public class Asignatura
    {
        public int IdAsignatura { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Facultad { get; set; }
        public string Area { get; set; }
        public string Descripcion { get; set; }
        public string Modalidad { get; set; }
        public bool Activo { get; set; }

        public Asignatura()
        {
            Activo = true;
        }
    }
}
