using System;
using System.Collections.Generic;
using System.IO;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Geom;
using iText.Kernel.Colors;
using Proyecto_POE.Datos.ResultadosGestion;
using Proyecto_POE.Entidades.ResultadosGestion;

namespace Proyecto_POE.Negocio.ResultadosGestion
{
    public class ReporteManager
    {
        private ReporteDAO dao = new ReporteDAO();

        public List<ReporteImpacto> ObtenerEstadisticas()
        {
            return dao.ObtenerImpactoPorMateria();
        }

        public string GenerarInformePDF(string rutaDestino)
        {
            try
            {
                var datos = ObtenerEstadisticas();

                using (PdfWriter writer = new PdfWriter(rutaDestino))
                {
                    using (PdfDocument pdf = new PdfDocument(writer))
                    {
                        Document document = new Document(pdf, PageSize.A4);
                        document.SetMargins(36, 36, 36, 36);

                        // Título
                        Paragraph header = new Paragraph("INFORME DE GESTIÓN Y RESULTADOS DE TUTORÍAS")
                            .SetTextAlignment(TextAlignment.CENTER)
                            .SetFontSize(18)
                            .SetBold()
                            .SetFontColor(ColorConstants.BLUE);
                        document.Add(header);

                        document.Add(new Paragraph($"Fecha de generación: {DateTime.Now:dd/MM/yyyy HH:mm}")
                            .SetTextAlignment(TextAlignment.RIGHT)
                            .SetFontSize(10));

                        document.Add(new Paragraph("\n"));

                        // Tabla de resultados
                        Table table = new Table(UnitValue.CreatePercentArray(new float[] { 30, 20, 15, 15, 20 }))
                            .UseAllAvailableWidth();

                        // Encabezados
                        table.AddHeaderCell(new Cell().Add(new Paragraph("Asignatura").SetBold()));
                        table.AddHeaderCell(new Cell().Add(new Paragraph("Facultad").SetBold()));
                        table.AddHeaderCell(new Cell().Add(new Paragraph("Sesiones").SetBold()));
                        table.AddHeaderCell(new Cell().Add(new Paragraph("Asistentes").SetBold()));
                        table.AddHeaderCell(new Cell().Add(new Paragraph("Puntaje Feedback").SetBold()));

                        foreach (var item in datos)
                        {
                            table.AddCell(item.NombreAsignatura);
                            table.AddCell(item.Facultad);
                            table.AddCell(item.TotalSesiones.ToString());
                            table.AddCell(item.TotalAsistentes.ToString());
                            table.AddCell(item.PromedioCalificacion.ToString("F2"));
                        }

                        document.Add(table);

                        // Resumen Ejecutivo
                        document.Add(new Paragraph("\nResumen Ejecutivo")
                            .SetBold()
                            .SetUnderline());
                        
                        int granTotalAsistentes = 0;
                        datos.ForEach(d => granTotalAsistentes += d.TotalAsistentes);

                        document.Add(new Paragraph($"Total de estudiantes impactados en el periodo: {granTotalAsistentes}"));
                        document.Add(new Paragraph("Nota: Este informe ha sido generado automáticamente por el Sistema de Gestión de Red de Tutorías Proyecto_POE."));

                        document.Close();
                    }
                }
                return "OK";
            }
            catch (Exception ex)
            {
                return "Error al generar PDF: " + ex.Message;
            }
        }
    }
}
