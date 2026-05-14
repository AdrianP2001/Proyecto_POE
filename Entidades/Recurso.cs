namespace TutoriasApp.Entidades
{
    /// <summary>
    /// Recurso de aprendizaje (PDF, enlace, documento) asociado a un grupo de estudio.
    /// </summary>
    public class Recurso
    {
        public int IdRecurso { get; set; }
        public int IdGrupo { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;

        public Recurso() { }

        public override string ToString() => Descripcion;
    }
}
