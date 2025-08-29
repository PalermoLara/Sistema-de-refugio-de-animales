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
    public class bllAdoptantes_941lp
    {
        ormAdoptantes_941lp orm_941lp;
        bllBitacoraEventos_941lp bllBitacoraEvento_941lp;
        public bllAdoptantes_941lp()
        {
            orm_941lp = new ormAdoptantes_941lp();
            bllBitacoraEvento_941lp = new bllBitacoraEventos_941lp();
        }

        public void Alta_941lp(string dni_941lp, string nombre_941lp, string apellido_941lp,  string telefono_941lp, int edad_941lp, string domicilio_941lp, bool mascotas_941lp)
        {
            try
            {
                Adoptante_941lp nuevoAdoptante_941lp = new Adoptante_941lp(dni_941lp, nombre_941lp, apellido_941lp,telefono_941lp,edad_941lp, domicilio_941lp, mascotas_941lp, true);
                orm_941lp.Alta_941lp(nuevoAdoptante_941lp);
                bllBitacoraEvento_941lp.Alta_941lp(sessionManager941lp.Gestor_941lp.RetornarUsuarioSession_941lp().nombreUsuario_941lp, "Gestion adoptantes", "Adoptante dado de alta", 2);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public bool ValidarDNI_941lp(string dni_941lp)
        {
            return orm_941lp.ValidarDni_941lp(dni_941lp);
        }

        public bool VerificarAdoptanteVivo_941lp(bool vivo_941lp)
        {
            return vivo_941lp;
        }

        public void Modificar_941lp(string dni_941lp, string nombre_941lp, string apellido_941lp, string telefono_941lp, int edad_941lp, string domicilio_941lp, bool mascotas_941lp)
        {
            try
            {
                Adoptante_941lp adoptante_941lp = BuscarAdoptantePorDNI_941lp(dni_941lp);
                adoptante_941lp.nombre_941lp = nombre_941lp;
                adoptante_941lp.apellido_941lp = apellido_941lp;
                adoptante_941lp.telefono_941lp = telefono_941lp;
                adoptante_941lp.edad_941lp = edad_941lp;
                adoptante_941lp.domicilio_941lp = domicilio_941lp;
                adoptante_941lp.mascotas_941lp = mascotas_941lp;
                orm_941lp.Modificar_941lp(adoptante_941lp);
                bllBitacoraEvento_941lp.Alta_941lp(sessionManager941lp.Gestor_941lp.RetornarUsuarioSession_941lp().nombreUsuario_941lp, "Gestion adoptantes", "Adoptante modificado", 3);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public void ActivarDesactivar_941lp(string dni_941lp)
        {
            try
            {
                Adoptante_941lp adoptante_941lp = BuscarAdoptantePorDNI_941lp(dni_941lp);
                if (adoptante_941lp == null)
                {
                    string mensaje1_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGestionAdoptantes_941lp", "MSG_ADOPTANTE_NO_ENCONTRADO", "Adoptante no encontrado");
                    MessageBox.Show(mensaje1_941lp);
                    return;
                }
                //Invierte el valor actual del campo activo_941lp
                adoptante_941lp.activo_941lp = !adoptante_941lp.activo_941lp;
                string activado_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGestionAdoptantes_941lp", "MSG_ADOPTANTE_ACTIVADO", "Se ha activado al adoptante con éxito");
                string noActivado_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGestionAdoptantes_941lp", "MSG_ADOPTANTE_NO_ACTIVADO", "Se ha desactivado al adoptante con éxito");
                string mensaje_941lp;
                if (adoptante_941lp.activo_941lp)
                {
                    mensaje_941lp = activado_941lp;
                    bllBitacoraEvento_941lp.Alta_941lp(sessionManager941lp.Gestor_941lp.RetornarUsuarioSession_941lp().nombreUsuario_941lp, "Gestion adoptantes", "Adoptante activado", 3);
                }
                else
                {
                    mensaje_941lp = noActivado_941lp;
                    bllBitacoraEvento_941lp.Alta_941lp(sessionManager941lp.Gestor_941lp.RetornarUsuarioSession_941lp().nombreUsuario_941lp, "Gestion adoptantes", "Adoptante desactivado", 3);
                }
                orm_941lp.Modificar_941lp(adoptante_941lp);
                MessageBox.Show(mensaje_941lp);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public Adoptante_941lp BuscarAdoptantePorDNI_941lp(string dni_941lp)
        {
            return orm_941lp.ObtenerAdoptantePorDni_941lp(dni_941lp);
        }

        public List<Adoptante_941lp> RetornarAdoptantes_941lp()
        {
            List<Adoptante_941lp> aux_941lp = new List<Adoptante_941lp>();
            foreach (Adoptante_941lp c_941lp in orm_941lp.RetornarAdoptantes_941lp())
            {
                aux_941lp.Add(new Adoptante_941lp(c_941lp.dni_941lp, c_941lp.nombre_941lp, c_941lp.apellido_941lp,  c_941lp.telefono_941lp, c_941lp.edad_941lp, c_941lp.domicilio_941lp, c_941lp.mascotas_941lp, c_941lp.activo_941lp));
            }
            return aux_941lp;
        }
    }
}
