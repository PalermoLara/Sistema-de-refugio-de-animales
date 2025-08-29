using BE;
using ORM;
using SERVICIOS;
using System;
using System.Collections.Generic;
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
