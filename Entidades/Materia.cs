namespace TutoriasApp.Entidades
{
    /// <summary>
    /// Entidad que representa una materia o asignatura disponible para tutorías.
    /// </summary>
    public class Materia
    {
        public int IdMateria { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string FotoPath { get; set; } = string.Empty;
        public int IdFacultad { get; set; }
        public string NombreFacultad { get; set; } = string.Empty;

        public Materia() { }

        public override string ToString() => Nombre;
    }
}
