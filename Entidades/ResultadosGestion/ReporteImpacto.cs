using System;

namespace Proyecto_POE.Entidades.ResultadosGestion
{
    /// <summary>
    /// Representa los métricas de impacto por asignatura.
    /// </summary>
    public class ReporteImpacto
    {
        public string NombreAsignatura { get; set; } = string.Empty;
        public string Facultad { get; set; } = string.Empty;
        public int TotalSesiones { get; set; }
        public int TotalAsistentes { get; set; }
        public double PromedioCalificacion { get; set; }
        
        // El impacto se calcula como asistentes / sesiones (promedio de asistencia)
        public double IndiceImpacto => TotalSesiones > 0 ? (double)TotalAsistentes / TotalSesiones : 0;
    }
}
