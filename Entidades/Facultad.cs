namespace TutoriasApp.Entidades
{
    public class Facultad
    {
        public int IdFacultad { get; set; }
        public string Nombre { get; set; } = string.Empty;

        public Facultad() { }

        public Facultad(int id, string nombre)
        {
            IdFacultad = id;
            Nombre = nombre;
        }

        public override string ToString() => Nombre;
    }
}
