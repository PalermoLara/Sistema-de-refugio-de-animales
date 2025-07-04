using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using Image = iTextSharp.text.Image;

namespace SERVICIOS.Reportes_941lp
{
    public class ReporteFichaIngreso_941lp
    {
        public void GenerarFichaIngresoPDF(string pathSalida,string nombre,string apellido, string telefono, string dni,string especie,DateTime fecha,TimeSpan hora,string razon,string zona,string rutaLogo)
        {
            Document doc = new Document(PageSize.A4);
            PdfWriter.GetInstance(doc, new FileStream(pathSalida, FileMode.Create));
            doc.Open();

            // Fuente
            var fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, BaseColor.BLACK);
            var fuenteSubtitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.BLACK);
            var fuenteNormal = FontFactory.GetFont(FontFactory.HELVETICA, 11, BaseColor.BLACK);

            // Logo
            if (File.Exists(rutaLogo))
            {
                Image logo = Image.GetInstance(rutaLogo);
                logo.ScaleAbsolute(80f, 80f);
                logo.Alignment = Element.ALIGN_LEFT;
                doc.Add(logo);
            }

            // Título principal
            Paragraph titulo = new Paragraph("WHISKER-WARE", fuenteTitulo);
            titulo.Alignment = Element.ALIGN_CENTER;
            doc.Add(titulo);

            doc.Add(new Paragraph("\n"));

            // Fecha de ingreso
            Paragraph fechaIngreso = new Paragraph($"Fecha de ingreso: {fecha:dd/MM/yyyy}", fuenteSubtitulo);
            fechaIngreso.Alignment = Element.ALIGN_RIGHT;
            doc.Add(fechaIngreso);

            doc.Add(new Paragraph("\n"));

            // Subtítulo
            Paragraph subtitulo = new Paragraph("Ficha de Ingreso", fuenteSubtitulo);
            subtitulo.Alignment = Element.ALIGN_CENTER;
            doc.Add(subtitulo);

            doc.Add(new Paragraph("\n"));

            // Datos
            PdfPTable tabla = new PdfPTable(2);
            tabla.WidthPercentage = 90;
            tabla.DefaultCell.Border = Rectangle.NO_BORDER;
            tabla.SetWidths(new float[] { 1.5f, 4f });

            void AgregarFila(string etiqueta, string valor)
            {
                tabla.AddCell(new Phrase(etiqueta, fuenteSubtitulo));
                tabla.AddCell(new Phrase(valor, fuenteNormal));
            }

            AgregarFila("Código Animal:", dni);
            AgregarFila("Especie:", especie);
            AgregarFila("Nombre del Cedente:", nombre);
            AgregarFila("Apellido del Cedente:", apellido);
            AgregarFila("Teléfono del Cedente:", telefono);
            AgregarFila("Fecha:", fecha.ToShortDateString());
            AgregarFila("Hora:", hora.ToString(@"hh\:mm"));
            AgregarFila("Razón:", razon);
            AgregarFila("Zona:", zona);

            doc.Add(tabla);

            doc.Close();
        }
    }
}
