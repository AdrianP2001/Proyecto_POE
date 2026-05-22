using System;
using System.Collections.Generic;
using Proyecto_POE.Datos;
using Proyecto_POE.Entidades;

namespace Proyecto_POE.Negocio
{
    public class GestorAsignaturas
    {
        private AsignaturaDAO _asignaturaDAO = new AsignaturaDAO();

        public List<Asignatura> ListarAsignaturas()
        {
            return _asignaturaDAO.ObtenerTodas();
        }
    }
}
