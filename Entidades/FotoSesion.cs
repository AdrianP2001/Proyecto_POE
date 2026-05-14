namespace TutoriasApp.Entidades
{
    /// <summary>
    /// Entidad que representa una foto de una sesión de tutoría realizada.
    /// La ruta de imagen es relativa al directorio del ejecutable.
    /// </summary>
    public class FotoSesion
    {
        public int IdFoto { get; set; }
        public int IdSesion { get; set; }
        public string RutaImagen { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;

        public FotoSesion() { }
    }
}
