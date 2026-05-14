using System;
using Proyecto_POE.Datos;
using Proyecto_POE.Entidades;

namespace Proyecto_POE.Negocio
{
    public class GestorFeedback
    {
        private FeedbackDAO _feedbackDAO = new FeedbackDAO();

        public void RegistrarFeedback(Feedback feedback)
        {
            if (feedback.Calificacion < 1 || feedback.Calificacion > 5)
            {
                throw new ArgumentException("La calificación debe estar entre 1 y 5.");
            }

            if (string.IsNullOrWhiteSpace(feedback.Comentarios))
            {
                throw new ArgumentException("Los comentarios no pueden estar vacíos.");
            }

            _feedbackDAO.InsertarFeedback(feedback);
        }
    }
}
