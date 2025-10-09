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
using System.Windows.Forms;

namespace BLL
{
    public class bllCertificado_941lp
    {
        ormCertificado_941lp orm_941lp;
        bllBitacoraEventos_941lp bllBitacoraEvento_941lp;
        public bllCertificado_941lp()
        {
            orm_941lp = new ormCertificado_941lp();
            bllBitacoraEvento_941lp = new bllBitacoraEventos_941lp();
        }

        public void Alta_941lp(string dni_941lp, int codigoAnimal_941lp, string especie_941lp, string raza_941lp, string nombreAnimal_941lp, string nombreAdoptante_941lp, string apellidoAdoptante_941lp)
        {
            try
            {
                string codigo_941lp = DateTime.Now.ToString("d") + dni_941lp.Substring(0, 3);
                CertificadoAdopcion_941lp nuevoCertificado_941lp = new CertificadoAdopcion_941lp(codigo_941lp,dni_941lp, codigoAnimal_941lp, especie_941lp, raza_941lp, nombreAnimal_941lp, nombreAdoptante_941lp, apellidoAdoptante_941lp, DateTime.Now);
                orm_941lp.Alta_941lp(nuevoCertificado_941lp);
                bllBitacoraEvento_941lp.Alta_941lp(sessionManager941lp.Gestor_941lp.RetornarUsuarioSession_941lp().nombreUsuario_941lp, "Gestion certificado de adopción", "Generación de certificado de adopción", 2);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public bool VerificarExistencia_941lp(string dni_941lp, int codigoAnimal_941lp)
        {
            return orm_941lp.ExisteCertificado_941lp(dni_941lp, codigoAnimal_941lp);
        }

        public void Modificar_941lp(string codigo_941lp, string dni_941lp, int codigoAnimal_941lp, string especie_941lp, string raza_941lp, string nombreAnimal_941lp, string nombreAdoptante_941lp, string apellidoAdoptante_941lp)
        {
            try
            {
                CertificadoAdopcion_941lp certificado_941lp = BuscarCertificadoPorCodigo_941lp(codigo_941lp);
                certificado_941lp.dni_941lp = dni_941lp;
                certificado_941lp.codigoAnimal_941lp = codigoAnimal_941lp;
                certificado_941lp.especie_941lp = especie_941lp;
                certificado_941lp.raza_941lp = raza_941lp;
                certificado_941lp.nombreAnimal_941lp = nombreAnimal_941lp;
                certificado_941lp.nombreAdoptante_941lp = nombreAdoptante_941lp;
                certificado_941lp.apellidoAdoptante_941lp = apellidoAdoptante_941lp;
                orm_941lp.Modificar_941lp(certificado_941lp);
                bllBitacoraEvento_941lp.Alta_941lp(sessionManager941lp.Gestor_941lp.RetornarUsuarioSession_941lp().nombreUsuario_941lp, "Gestion certificados de adopción", "Certificado de adopción modificado", 3);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public void Imprimir_941lp(CertificadoAdopcion_941lp cert_941lp, string nombreArchivo_941lp)
        {
            try
            {
                string documentosPath_941lp = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string carpetaCertificados_941lp = Path.Combine(documentosPath_941lp, "Certificados de adopción");

                if (!Directory.Exists(carpetaCertificados_941lp))
                    Directory.CreateDirectory(carpetaCertificados_941lp);

                string rutaArchivo_941lp = Path.Combine(carpetaCertificados_941lp, nombreArchivo_941lp);

                Document doc_941lp = new Document(PageSize.A4, 70, 70, 70, 70);

                using (FileStream stream_941lp = new FileStream(rutaArchivo_941lp, FileMode.Create))
                {
                    PdfWriter.GetInstance(doc_941lp, stream_941lp);
                    doc_941lp.Open();

                    // Título
                    Paragraph titulo_941lp = new Paragraph("CERTIFICADO DE ADOPCIÓN",
                        FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 22, BaseColor.BLACK));
                    titulo_941lp.Alignment = Element.ALIGN_CENTER;
                    doc_941lp.Add(titulo_941lp);

                    doc_941lp.Add(new Paragraph("\n"));

                    // Texto principal
                    Paragraph cuerpo_941lp = new Paragraph(
                        $"Se certifica que el/la Sr./Sra. {cert_941lp.nombreAdoptante_941lp} {cert_941lp.apellidoAdoptante_941lp}, " +
                        $"DNI {cert_941lp.dni_941lp}, ha adoptado oficialmente a {cert_941lp.nombreAnimal_941lp}, " +
                        $"un ejemplar de la especie {cert_941lp.especie_941lp} de raza {cert_941lp.raza_941lp}.\n\n" +
                        $"El código del animal es {cert_941lp.codigoAnimal_941lp}, y el código de adopción asignado es {cert_941lp.codigo_941lp}.\n\n" +
                        $"Esta adopción fue registrada con fecha {cert_941lp.fecha_941lp.ToLongDateString()}.",
                        FontFactory.GetFont(FontFactory.TIMES_ROMAN, 14, BaseColor.BLACK)
                    );
                    cuerpo_941lp.Alignment = Element.ALIGN_JUSTIFIED;
                    doc_941lp.Add(cuerpo_941lp);

                    doc_941lp.Add(new Paragraph("\n\n\n"));

                    // Separador decorativo
                    Paragraph separador_941lp = new Paragraph("═══════════════════════════════════════════════",
                        FontFactory.GetFont(FontFactory.COURIER_BOLD, 12, BaseColor.GRAY));
                    separador_941lp.Alignment = Element.ALIGN_CENTER;
                    doc_941lp.Add(separador_941lp);

                    doc_941lp.Add(new Paragraph("\n\n"));

                    // Firmas
                    PdfPTable firmas_941lp = new PdfPTable(2);
                    firmas_941lp.WidthPercentage = 80;
                    firmas_941lp.HorizontalAlignment = Element.ALIGN_CENTER;

                    PdfPCell firma1_941lp = new PdfPCell(new Phrase("_________________________\nFirma del Adoptante",
                        FontFactory.GetFont(FontFactory.HELVETICA, 12)));
                    firma1_941lp.Border = PdfPCell.NO_BORDER;
                    firma1_941lp.HorizontalAlignment = Element.ALIGN_CENTER;

                    PdfPCell firma2_941lp = new PdfPCell(new Phrase("_________________________\nFirma del Responsable",
                        FontFactory.GetFont(FontFactory.HELVETICA, 12)));
                    firma2_941lp.Border = PdfPCell.NO_BORDER;
                    firma2_941lp.HorizontalAlignment = Element.ALIGN_CENTER;

                    firmas_941lp.AddCell(firma1_941lp);
                    firmas_941lp.AddCell(firma2_941lp);

                    doc_941lp.Add(firmas_941lp);

                    doc_941lp.Add(new Paragraph("\n\n\n"));

                    // Pie de página
                    Paragraph pie_941lp = new Paragraph("Centro de Adopciones - Registro Oficial de Animales",
                        FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 10, BaseColor.DARK_GRAY));
                    pie_941lp.Alignment = Element.ALIGN_CENTER;
                    doc_941lp.Add(pie_941lp);

                    // Nueva página para el siguiente certificado
                    doc_941lp.NewPage();
                    

                    doc_941lp.Close();
                }

                MessageBox.Show($"Los certificados se guardaron en:\n{rutaArchivo_941lp}",
                    "Impresión Exitosa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el certificado:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        public CertificadoAdopcion_941lp BuscarCertificadoPorCodigo_941lp(string codigo_941lp_941lp)
        {
            return orm_941lp.RetornarCertificados_941lp().Find(x=>x.codigo_941lp == codigo_941lp_941lp);
        }

        public List<CertificadoAdopcion_941lp> RetornarCertificado_941lp()
        {
            List<CertificadoAdopcion_941lp> aux_941lp = new List<CertificadoAdopcion_941lp>();
            foreach (CertificadoAdopcion_941lp c_941lp in orm_941lp.RetornarCertificados_941lp())
            {
                aux_941lp.Add(new CertificadoAdopcion_941lp(c_941lp.codigo_941lp, c_941lp.dni_941lp, c_941lp.codigoAnimal_941lp, c_941lp.especie_941lp, c_941lp.raza_941lp, c_941lp.nombreAnimal_941lp, c_941lp.nombreAdoptante_941lp, c_941lp.apellidoAdoptante_941lp, c_941lp.fecha_941lp));
            }
            return aux_941lp;
        }
    }
}
