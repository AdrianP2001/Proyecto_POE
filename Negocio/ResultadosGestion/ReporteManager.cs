using iText.IO.Font.Constants;
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
                            .SetFontColor(ColorConstants.BLUE);
                        document.Add(header);

                        document.Add(new Paragraph($"Fecha de generación: {DateTime.Now:dd/MM/yyyy HH:mm}")
                            .SetTextAlignment(TextAlignment.RIGHT)
                            .SetFontSize(10));

                        document.Add(new Paragraph("\n"));

                        // Tabla de resultados
                        float[] columnWidths = { 3, 2, 1, 1, 2 };
                        Table table = new Table(UnitValue.CreateRelativeArray(columnWidths)).SetWidth(UnitValue.CreatePercentValue(100));

                        // Encabezados simples (sin SetProperty que rompe)
                        table.AddHeaderCell(new Cell().Add(new Paragraph("Asignatura")));
                        table.AddHeaderCell(new Cell().Add(new Paragraph("Facultad")));
                        table.AddHeaderCell(new Cell().Add(new Paragraph("Sesiones")));
                        table.AddHeaderCell(new Cell().Add(new Paragraph("Asistentes")));
                        table.AddHeaderCell(new Cell().Add(new Paragraph("Puntaje Feedback")));

                        foreach (var item in datos)
                        {
                            table.AddCell(new Cell().Add(new Paragraph(item.NombreAsignatura)));
                            table.AddCell(new Cell().Add(new Paragraph(item.Facultad)));
                            table.AddCell(new Cell().Add(new Paragraph(item.TotalSesiones.ToString())));
                            table.AddCell(new Cell().Add(new Paragraph(item.TotalAsistentes.ToString())));
                            table.AddCell(new Cell().Add(new Paragraph(item.PromedioCalificacion.ToString("F2"))));
                        }

                        document.Add(table);

                        // Resumen Ejecutivo
                        document.Add(new Paragraph("\nResumen Ejecutivo").SetFontSize(14));
                        
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
