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

        public void Imprimir_941lp(List<Evento_941lp> listaEventos_941lp, string nombreArchivo_941lp)
        {
            try
            {
                string documentosPath_941lp = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string carpetaBitacora_941lp = Path.Combine(documentosPath_941lp, "Bitacora");

                if (!Directory.Exists(carpetaBitacora_941lp))
                {
                    Directory.CreateDirectory(carpetaBitacora_941lp);
                }

                string rutaArchivo_941lp = Path.Combine(carpetaBitacora_941lp, nombreArchivo_941lp);

                Document doc_941lp = new Document(PageSize.A4, 10, 10, 10, 10);

                using (FileStream stream_941lp = new FileStream(rutaArchivo_941lp, FileMode.Create))
                {
                    PdfWriter.GetInstance(doc_941lp, stream_941lp);
                    doc_941lp.Open();

                    Paragraph titulo_941lp = new Paragraph("Reporte de Eventos del Sistema",
                        FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14));
                    titulo_941lp.Alignment = Element.ALIGN_CENTER;
                    doc_941lp.Add(titulo_941lp);
                    doc_941lp.Add(new Paragraph(" ")); 

                    PdfPTable tabla_941lp = new PdfPTable(6);
                    tabla_941lp.WidthPercentage = 100;

                    string[] headers_941lp = { "LogIn", "Fecha", "Hora", "Módulo", "Evento", "Criticidad" };
                    foreach (var h_941lp in headers_941lp)
                    {
                        PdfPCell cell_941lp = new PdfPCell(new Phrase(h_941lp,
                            FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10)));
                        cell_941lp.BackgroundColor = BaseColor.LIGHT_GRAY;
                        cell_941lp.HorizontalAlignment = Element.ALIGN_CENTER;
                        tabla_941lp.AddCell(cell_941lp);
                    }

                    foreach (var ev_941lp in listaEventos_941lp)
                    {
                        tabla_941lp.AddCell(ev_941lp.login_941lp);
                        tabla_941lp.AddCell(ev_941lp.fecha_941lp.ToShortDateString());
                        tabla_941lp.AddCell(ev_941lp.hora_941lp.ToString(@"hh\:mm\:ss"));
                        tabla_941lp.AddCell(ev_941lp.modulo_941lp);
                        tabla_941lp.AddCell(ev_941lp.evento_941lp);
                        tabla_941lp.AddCell(ev_941lp.criticidad_941lp.ToString());
                    }

                    doc_941lp.Add(tabla_941lp);
                    doc_941lp.Close();

                    MessageBox.Show($"El reporte se guardó en:\n{rutaArchivo_941lp}",
                        "Impresión Exitosa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            
        }
    }
}
