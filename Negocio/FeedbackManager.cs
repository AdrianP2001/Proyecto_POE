using TutoriasApp.Datos;
using TutoriasApp.Entidades;

namespace TutoriasApp.Negocio
{
    /// <summary>
    /// Gestiona comentarios/sugerencias y la votación al tutor del mes.
    /// Incluye validaciones de negocio: longitud mínima de comentario y rango de calificación.
    /// </summary>
    public class FeedbackManager
    {
        private readonly ComentarioDAO _comentarioDAO = new ComentarioDAO();
        private readonly VotacionDAO _votacionDAO = new VotacionDAO();
        private readonly TutorDAO _tutorDAO = new TutorDAO();

        /// <summary>
        /// Registra un comentario. Retorna "OK" o mensaje de error de validación.
        /// </summary>
        public string RegistrarComentario(string nombre, string texto, int? idGrupo)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return "Error: El nombre del estudiante es obligatorio.";
            if (string.IsNullOrWhiteSpace(texto) || texto.Trim().Length < 10)
                return "Error: El comentario debe tener al menos 10 caracteres.";

            _comentarioDAO.Registrar(new Comentario
            {
                NombreEstudiante = nombre.Trim(),
                TextoComentario = texto.Trim(),
                IdGrupo = idGrupo
            });
            return "OK";
        }

        /// <summary>
        /// Registra el voto de un estudiante a un tutor. Calificación válida: 1-5.
        /// </summary>
        public string VotarTutor(int idTutor, int calificacion)
        {
            if (idTutor <= 0)
                return "Error: Debe seleccionar un tutor.";
            if (calificacion < 1 || calificacion > 5)
                return "Error: La calificación debe estar entre 1 y 5 estrellas.";

            _votacionDAO.Registrar(new VotacionTutor(idTutor, calificacion));
            return "OK";
        }

        public Tutor? ObtenerTutorDelMes() => _tutorDAO.ObtenerTutorDelMes();
    }
}
