using System;
using System.Collections.Generic;
using Proyecto_POE.Datos;
using Proyecto_POE.Entidades;

namespace Proyecto_POE.Negocio
{
    public class GestorTutorias
    {
        private TutorDAO _tutorDAO = new TutorDAO();

        public List<Tutor> ListarTutores()
        {
            return _tutorDAO.ObtenerTodos();
        }

        public bool RegistrarTutor(Tutor tutor)
        {
            if (string.IsNullOrWhiteSpace(tutor.Nombres) || string.IsNullOrWhiteSpace(tutor.Apellidos))
                throw new ArgumentException("El nombre y el apellido del tutor son obligatorios.");
            
            return _tutorDAO.Insertar(tutor);
        }
    }
}
