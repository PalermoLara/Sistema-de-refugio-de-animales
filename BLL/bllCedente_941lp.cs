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
    public class bllCedente_941lp
    {
        ormCedente_941lp orm_941lp;
        encriptador_941lp seguridad_941lp;
        public bllCedente_941lp()
        {
            orm_941lp = new ormCedente_941lp();
            seguridad_941lp = new encriptador_941lp();
        }

        public void Alta_941lp(string dni_941lp, string nombre_941lp, string apellido_941lp, string direccion_941lp, string telefono_941lp)
        {
            try
            {
                string direccionEncriptada_941lp = EncriptarDireccion_941lp(direccion_941lp); // lógica de negocio: dirección encriptada
                Cedente_941lp nuevoCedente_941lp = new Cedente_941lp(dni_941lp, nombre_941lp, apellido_941lp, direccionEncriptada_941lp, telefono_941lp, true);
                orm_941lp.Alta_941lp(nuevoCedente_941lp);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public string EncriptarDireccion_941lp(string direccion_941lp)
        {
            return seguridad_941lp.Encrypt_941lp(direccion_941lp);
        }

        public bool ValidarDNI_941lp(string dni_941lp)
        {
            return orm_941lp.ValidarDni_941lp(dni_941lp);
        }

        public void Modificar_941lp(string dni_941lp, string nombre_941lp, string apellido_941lp, string direccion_941lp, string telefono_941lp)
        {
            try
            {
                Cedente_941lp cedente_941lp = BuscarCedentePorDNI_941lp(dni_941lp);
                cedente_941lp.nombre_941lp = nombre_941lp;
                cedente_941lp.apellido_941lp = apellido_941lp;
                cedente_941lp.direccion_941lp = EncriptarDireccion_941lp( direccion_941lp);
                cedente_941lp.telefono_941lp = telefono_941lp;
                orm_941lp.Modificar_941lp(cedente_941lp);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public void ActivarDesactivar_941lp(string dni_941lp)
        {
            try
            {
                Cedente_941lp cedente_941lp = BuscarCedentePorDNI_941lp(dni_941lp);
                if (cedente_941lp == null)
                {
                    string mensaje_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGestorCedentes_941lp", "MSG_CEDENTE_NO_ENCONTRADO", "Cedente no encontrado");
                    MessageBox.Show(mensaje_941lp);
                    return;
                }
                //Invierte el valor actual del campo activo_941lp
                cedente_941lp.activo_941lp = !cedente_941lp.activo_941lp;
                string activado_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGestorCedentes_941lp", "MSG_CEDENTE_ACTIVADO", "Se ha activado al cedente con éxito");
                string noActivado_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGestorCedentes_941lp", "MSG_CEDENTE_NO_ACTIVADO", "Se ha desactivado al cedente con éxito");
                string mensaje = cedente_941lp.activo_941lp ? activado_941lp : noActivado_941lp;
                orm_941lp.Modificar_941lp(cedente_941lp);
                MessageBox.Show(mensaje);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public Cedente_941lp BuscarCedentePorDNI_941lp(string dni_941lp)
        {
            return orm_941lp.ObtenerCedentePorDni_941lp(dni_941lp);
        }

        public List<Cedente_941lp> RetornarCedentes_941lp()
        {
            List<Cedente_941lp> aux_941lp = new List<Cedente_941lp>();
            foreach(Cedente_941lp c_941lp in orm_941lp.RetornarCedentes_941lp())
            {
                aux_941lp.Add(new Cedente_941lp(c_941lp.dni_941lp, c_941lp.nombre_941lp, c_941lp.apellido_941lp, c_941lp.direccion_941lp, c_941lp.telefono_941lp, c_941lp.activo_941lp));
            }
            return aux_941lp;
        }

        public string DireccionDesencriptada(string dni_941lp)
        {
            Cedente_941lp cedente_941lp = BuscarCedentePorDNI_941lp(dni_941lp);
            return  seguridad_941lp.Decrypt(cedente_941lp.direccion_941lp);
        }
    }
}

