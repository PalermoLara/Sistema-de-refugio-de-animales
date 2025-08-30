using BE;
using iTextSharp.text;
using iTextSharp.text.pdf;
using ORM;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace BLL
{
    public class bllBitacoraEventos_941lp
    {
        ormBitacoraEventos_941lp orm_941lp;
        public bllBitacoraEventos_941lp()
        {
            orm_941lp = new ormBitacoraEventos_941lp();
        }

        public void Alta_941lp(string login_941lp, string modulo_941lp,string evento_941lp, int criticidad_941lp)
        {
            try
            {
                Evento_941lp nuevoEvento_941lp = new Evento_941lp(login_941lp,DateTime.Now.Date, DateTime.Now.TimeOfDay,modulo_941lp, evento_941lp, criticidad_941lp);
                orm_941lp.Alta_941lp(nuevoEvento_941lp);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public List<Evento_941lp> Filtros_941lp(Dictionary<string, string> filtros_941lp)
        {
            return orm_941lp.Filtros_941lp(filtros_941lp);
        }

        public List<Evento_941lp> RetornarEventos_941lp()
        {
            List<Evento_941lp> aux_941lp = new List<Evento_941lp>();
            foreach (Evento_941lp c_941lp in orm_941lp.RetornarEventos_941lp())
            {
                aux_941lp.Add(new Evento_941lp(c_941lp.codigo_941lp,c_941lp.login_941lp, c_941lp.fecha_941lp, c_941lp.hora_941lp, c_941lp.modulo_941lp, c_941lp.evento_941lp, c_941lp.criticidad_941lp));
            }
            return aux_941lp;
        }

        public void Imprimir_941lp(List<Evento_941lp> listaEventos, string nombreArchivo)
        {
            try
            {
                string documentosPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string carpetaBitacora = Path.Combine(documentosPath, "Bitacora");

                // 📂 Crear carpeta si no existe
                if (!Directory.Exists(carpetaBitacora))
                {
                    Directory.CreateDirectory(carpetaBitacora);
                }

                // 📄 Ruta final del archivo PDF
                string rutaArchivo = Path.Combine(carpetaBitacora, nombreArchivo);

                Document doc = new Document(PageSize.A4, 10, 10, 10, 10);

                using (FileStream stream = new FileStream(rutaArchivo, FileMode.Create))
                {
                    PdfWriter.GetInstance(doc, stream);
                    doc.Open();

                    // 📝 Título
                    Paragraph titulo = new Paragraph("Reporte de Eventos del Sistema",
                        FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14));
                    titulo.Alignment = Element.ALIGN_CENTER;
                    doc.Add(titulo);
                    doc.Add(new Paragraph(" ")); // espacio

                    // 📊 Tabla con 6 columnas
                    PdfPTable tabla = new PdfPTable(6);
                    tabla.WidthPercentage = 100;

                    // Encabezados
                    string[] headers = { "LogIn", "Fecha", "Hora", "Módulo", "Evento", "Criticidad" };
                    foreach (var h in headers)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(h,
                            FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10)));
                        cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        tabla.AddCell(cell);
                    }

                    // Datos
                    foreach (var ev in listaEventos)
                    {
                        tabla.AddCell(ev.login_941lp);
                        tabla.AddCell(ev.fecha_941lp.ToShortDateString());
                        tabla.AddCell(ev.hora_941lp.ToString(@"hh\:mm\:ss"));
                        tabla.AddCell(ev.modulo_941lp);
                        tabla.AddCell(ev.evento_941lp);
                        tabla.AddCell(ev.criticidad_941lp.ToString());
                    }

                    doc.Add(tabla);
                    doc.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            
        }
    }
}
