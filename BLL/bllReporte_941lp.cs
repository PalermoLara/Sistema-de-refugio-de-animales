using BE;
using iTextSharp.text;
using iTextSharp.text.pdf;
using ORM;
using SERVICIOS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.DataVisualization.Charting;
using System.Windows.Forms;

namespace BLL
{
    public class bllReporte_941lp
    {
        public void GenerarReportePDF_941lp()
        {
            ormReporteAdopciones_941lp orm_941lp = new ormReporteAdopciones_941lp();
            List<ReporteMensualAdopciones_941lp> datos = orm_941lp.ObtenerReporteMensual_941lp();

            // Crear carpeta si no existe
            string carpetaReportes = @"C:\ReportesInteligentes";
            if (!Directory.Exists(carpetaReportes))
                Directory.CreateDirectory(carpetaReportes);

            string nombreArchivo = $"ReporteAdopciones_{DateTime.Now:yyyy-MM-dd_HH-mm}.pdf";
            string rutaSalida = Path.Combine(carpetaReportes, nombreArchivo);

            // Crear gráfico principal
            Chart chart = new Chart();
            chart.Width = 800;
            chart.Height = 400;
            chart.ChartAreas.Add("Area1");

            Series s1 = new Series("Ingresos") { ChartType = SeriesChartType.Column };
            Series s2 = new Series("Adopciones") { ChartType = SeriesChartType.Column };
            Series s3 = new Series("% Adopción") { ChartType = SeriesChartType.Line, BorderWidth = 3, YAxisType = AxisType.Secondary };

            foreach (var item in datos)
            {
                string label = $"{item.MesNombre_941lp} {item.Año_941lp}";
                s1.Points.AddXY(label, item.Ingresos_941lp);
                s2.Points.AddXY(label, item.Adopciones_941lp);
                s3.Points.AddXY(label, item.Porcentaje_941lp);
            }

            chart.Series.Add(s1);
            chart.Series.Add(s2);
            chart.Series.Add(s3);

            chart.ChartAreas[0].AxisX.Interval = 1;
            chart.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            chart.Legends.Add("Leyenda");

            string rutaGrafico = Path.Combine(Path.GetTempPath(), "graficoAdopciones.png");
            chart.SaveImage(rutaGrafico, ChartImageFormat.Png);

            // Crear PDF
            Document doc = new Document(PageSize.A4, 50, 50, 50, 50);
            PdfWriter.GetInstance(doc, new FileStream(rutaSalida, FileMode.Create));
            doc.Open();

            // 🔹 Título
            var titulo = new Paragraph("Reporte de Adopciones vs Ingresos de Animales",
                new Font(Font.FontFamily.HELVETICA, 16, Font.BOLD))
            {
                Alignment = Element.ALIGN_CENTER
            };
            doc.Add(titulo);

            // 🔹 Fecha
            var fecha = new Paragraph($"Generado el {DateTime.Now:dd/MM/yyyy HH:mm}\n\n",
                new Font(Font.FontFamily.HELVETICA, 10, Font.ITALIC))
            {
                Alignment = Element.ALIGN_RIGHT
            };
            doc.Add(fecha);

            // 🔹 Introducción explicativa
            var introduccion = new Paragraph(
                "Este reporte inteligente integra información proveniente de varias tablas de la base de datos —" +
                "principalmente FichaDeIngreso_941lp, CertificadoAdopcion_941lp y Animal_941lp— " +
                "para analizar las tendencias de adopción de animales en el refugio.\n\n" +
                "El objetivo principal es evaluar la relación entre los ingresos de animales y las adopciones " +
                "realizadas en distintos períodos de tiempo, permitiendo detectar variaciones, medir la eficacia " +
                "de las campañas de adopción y servir como base para la toma de decisiones estratégicas.\n\n" +
                "A continuación se muestra un gráfico comparativo entre el número de ingresos, adopciones y " +
                "el porcentaje de adopción mensual.",
                new Font(Font.FontFamily.HELVETICA, 11, Font.NORMAL))
            {
                Alignment = Element.ALIGN_JUSTIFIED
            };
            doc.Add(introduccion);
            doc.Add(new Paragraph("\n"));

            // 🔹 Gráfico principal
            iTextSharp.text.Image grafico = iTextSharp.text.Image.GetInstance(rutaGrafico);
            grafico.ScaleToFit(500f, 300f);
            grafico.Alignment = Element.ALIGN_CENTER;
            doc.Add(grafico);
            doc.Add(new Paragraph("\n"));

            // 🔹 Tabla con datos
            PdfPTable tabla = new PdfPTable(5);
            tabla.WidthPercentage = 100;
            tabla.AddCell("Año");
            tabla.AddCell("Mes");
            tabla.AddCell("Ingresos");
            tabla.AddCell("Adopciones");
            tabla.AddCell("% Adopción");

            foreach (var d in datos)
            {
                tabla.AddCell(d.Año_941lp.ToString());
                tabla.AddCell(d.MesNombre_941lp);
                tabla.AddCell(d.Ingresos_941lp.ToString());
                tabla.AddCell(d.Adopciones_941lp.ToString());
                tabla.AddCell($"{d.Porcentaje_941lp}%");
            }

            doc.Add(tabla);


            var especies = orm_941lp.ObtenerAdopcionesPorEspecie_941lp();
            if (especies.Count > 0)
            {
                // Nueva página
                doc.NewPage();

                var subtitulo = new Paragraph("Distribución de Adopciones por Especie",
                    new Font(Font.FontFamily.HELVETICA, 14, Font.BOLD))
                {
                    Alignment = Element.ALIGN_CENTER
                };
                doc.Add(subtitulo);
                doc.Add(new Paragraph("\n"));

                Chart chartPie = new Chart();
                chartPie.Width = 600;
                chartPie.Height = 350;
                chartPie.ChartAreas.Add("PieArea");
                Series seriePie = new Series("Adopciones por Especie")
                {
                    ChartType = SeriesChartType.Pie,
                    IsValueShownAsLabel = true
                };

                foreach (var e in especies)
                    seriePie.Points.AddXY(e.Especie, e.Cantidad);

                chartPie.Series.Add(seriePie);
                chartPie.Legends.Add("Leyenda");

                string rutaPie = Path.Combine(Path.GetTempPath(), "graficoEspecies.png");
                chartPie.SaveImage(rutaPie, ChartImageFormat.Png);

                iTextSharp.text.Image graficoPie = iTextSharp.text.Image.GetInstance(rutaPie);
                graficoPie.ScaleToFit(450f, 300f);
                graficoPie.Alignment = Element.ALIGN_CENTER;
                doc.Add(graficoPie);
                doc.Add(new Paragraph("\n"));

                var explicacionPie = new Paragraph(
                    "Este gráfico circular muestra la proporción de adopciones realizadas según la especie del animal. " +
                    "Permite identificar qué tipo de animales son adoptados con mayor frecuencia y orientar las campañas " +
                    "de adopción o rescate según las tendencias observadas.",
                    new Font(Font.FontFamily.HELVETICA, 11, Font.NORMAL))
                {
                    Alignment = Element.ALIGN_JUSTIFIED
                };
                doc.Add(explicacionPie);
            }

            // 🔹 Conclusión general
            doc.Add(new Paragraph("\n"));
            var conclusion = new Paragraph(
                "Conclusión: El análisis de estos datos permite comprender la evolución de las adopciones en relación " +
                "a la cantidad de animales ingresados, facilitando la toma de decisiones para mejorar los procesos " +
                "de rescate, cuidado y adopción en el refugio.",
                new Font(Font.FontFamily.HELVETICA, 11, Font.ITALIC))
            {
                Alignment = Element.ALIGN_JUSTIFIED
            };
            doc.Add(conclusion);

            doc.Close();

            string mensaje_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormCertificadoDeAdopcion_941lp", "MSG_REPORTE_INTELIGENTE_RUTA", "Reporte generado correctamente en:");
            MessageBox.Show($"{mensaje_941lp} {rutaSalida}");
        }

    }
}
