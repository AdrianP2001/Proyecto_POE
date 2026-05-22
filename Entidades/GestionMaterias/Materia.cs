using System.Drawing;

namespace Proyecto_POE.Entidades.GestionMaterias
{
    public class Materia
    {
        public string Nombre { get; set; } = string.Empty;
        public string Facultad { get; set; } = string.Empty;
        public string Area { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public DateTime FechaRegistro { get; set; }
        public string Modalidad { get; set; } = string.Empty;
        public string DiasDisponibles { get; set; } = string.Empty;
        public Image? Imagen { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
