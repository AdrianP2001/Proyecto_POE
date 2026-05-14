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
    }
}
