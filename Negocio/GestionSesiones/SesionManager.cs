using System;
using System.Collections.Generic;
using System.Linq;
using Proyecto_POE.Datos.GestionSesiones;
using Proyecto_POE.Entidades.GestionSesiones;

namespace Proyecto_POE.Negocio.GestionSesiones
{
    /// <summary>
    /// Arquitecto Senior: Clase encargada de orquestar la lógica de negocio para las Sesiones.
    /// Implementa validaciones críticas de cruce de horarios y gestión de integridad.
    /// </summary>
    public class SesionManager
    {
        private SesionDAO dao = new SesionDAO();

        public string ProcesarRegistro(Sesion nueva)
        {
            // 1. Validaciones de Integridad de la Entidad
            if (string.IsNullOrWhiteSpace(nueva.Ubicacion))
                return "Error: La ubicación o enlace virtual es obligatorio.";

            if (nueva.HoraFin <= nueva.HoraInicio)
                return "Error: La hora de fin debe ser posterior a la de inicio.";

            if (nueva.Fecha.Date < DateTime.Now.Date)
                return "Error: No se pueden programar sesiones en fechas pasadas.";

            try 
            {
                var sesionesExistentes = dao.Listar();

                // 2. Lógica de Negocio Avanzada: No permitir ningún traslape en la misma fecha
                // Se elimina la validación por ubicación para asegurar que el cronograma sea único por rango horario.
                bool hayConflicto = sesionesExistentes.Any(s =>
                    s.Fecha.Date == nueva.Fecha.Date &&
                    nueva.HoraInicio < s.HoraFin && s.HoraInicio < nueva.HoraFin);

                if (hayConflicto)
                    return "Conflicto: Ya existe una tutoría programada en esa ubicación y rango horario.";

                // 3. Gestión Automática del Orden Secuencial
                // Se calcula basado en la cantidad de sesiones existentes para mantener la trazabilidad.
                nueva.OrdenSecuencial = sesionesExistentes.Count + 1;

                // 4. Persistencia en Capa de Datos
                dao.Registrar(nueva);
                return "OK";
            }
            catch (Exception ex)
            {
                // Loguear error aquí en una app real
                return "Excepción técnica: " + ex.Message;
            }
        }

        public List<Sesion> ObtenerCronograma()
        {
            // Retorna la lista ordenada por fecha y hora para la UI
            return dao.Listar()
                      .OrderBy(s => s.Fecha)
                      .ThenBy(s => s.HoraInicio)
                      .ToList();
        }
    }
}
