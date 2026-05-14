namespace TutoriasApp.Entidades
{
    /// <summary>
    /// Entidad que representa a un tutor del sistema de tutorías.
    /// </summary>
    public class Tutor
    {
        public int IdTutor { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Especialidad { get; set; } = string.Empty;
        public string FotoPath { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        /// <summary>Promedio de votos del tutor (calculado en tiempo de ejecución).</summary>
        public double PromedioVotos { get; set; }

        public Tutor() { }

        public override string ToString() => Nombre;
    }
}
