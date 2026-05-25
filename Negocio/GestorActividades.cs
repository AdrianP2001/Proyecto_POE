using System;
using System.Collections.Generic;
using Proyecto_POE.Datos;
using Proyecto_POE.Entidades;

namespace Proyecto_POE.Negocio
{
    public class GestorActividades
    {
        private ActividadDAO _actividadDAO = new ActividadDAO();

        public List<Actividad> ListarActividadesPorAsignatura(int idAsignatura)
        {
            if (idAsignatura <= 0)
                throw new ArgumentException("Id de asignatura invalido.");

            return _actividadDAO.ObtenerActividades(idAsignatura);
        }

        public List<Actividad> ListarTodas()
        {
            return _actividadDAO.ObtenerTodas();
        }
    }
}
