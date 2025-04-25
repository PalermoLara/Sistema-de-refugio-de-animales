using BE;
using ORM;
using SERVICIOS;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BLL
{
    public class bllUsuario_941lp
    {
        ormUsuario_941lp orm_941lp;
        seguridad941lp seguridad_941lp;
        public bllUsuario_941lp()
        {
            orm_941lp = new ormUsuario_941lp();
            seguridad_941lp = new seguridad941lp();
        }

        public void Alta_941lp(string dni_941lp, string nombre_941lp, string apellido_941lp,string email_941lp,string rol_941lp)
        {
            try
            { 
                string nombreUsuario_941lp = dni_941lp + nombre_941lp;
                string contraseña_941lp = HashearContraseña_941lp(apellido_941lp + dni_941lp); // lógica de negocio: contraseña inicial hasheada
                Usuario_941lp nuevoUsuario_941lp = new Usuario_941lp( dni_941lp, nombreUsuario_941lp, contraseña_941lp, nombre_941lp, apellido_941lp, rol_941lp, email_941lp, false, 0, "es", true);
                orm_941lp.Alta_941lp(nuevoUsuario_941lp);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public bool ValidarExistenciaNombreUsuario_941lp(string nombreUsuario_941lp)
        {
            return orm_941lp.ValidarExistenciaNombreUsuario_941lp(nombreUsuario_941lp);
        }

        private string HashearContraseña_941lp(string contraseñaUsuario_941lp)
        {
            return seguridad_941lp.GetSHA256_941lp(contraseñaUsuario_941lp);
        }

        public bool ValidarContraseñaActual_941lp(string contraseña_941lp)
        {
            string contraseñaHasheada_941lp = HashearContraseña_941lp(contraseña_941lp);
            return orm_941lp.ValidarContraseñaActual_941lp(contraseñaHasheada_941lp);
        }

        public bool ValidarDNI_941lp(string dni_941lp)
        {
            return orm_941lp.ValidarDni_941lp(dni_941lp);
        }

        public void AumentarIntentos_941lp(Usuario_941lp nombreUsuario941lp_941lp)
        {
             orm_941lp.AumentarIntentos_941lp(nombreUsuario941lp_941lp);
        }

        public void Modificar_941lp(string dni_941lp, string nombre_941lp, string apellido_941lp, string rol_941lp, string email_941lp)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nombre_941lp) || string.IsNullOrWhiteSpace(apellido_941lp) ||
                    string.IsNullOrWhiteSpace(email_941lp) || string.IsNullOrWhiteSpace(rol_941lp))
                {
                    throw new Exception("Faltan datos obligatorios");
                }
                Usuario_941lp nuevoUsuario_941lp = BuscarUsuarioPorDNI_941lp(dni_941lp);
                nuevoUsuario_941lp.nombre_941lp = nombre_941lp;
                nuevoUsuario_941lp.apellido_941lp = apellido_941lp;
                nuevoUsuario_941lp.rol_941lp = rol_941lp;
                nuevoUsuario_941lp.email_941lp = email_941lp;
                orm_941lp.Modificar_941lp(nuevoUsuario_941lp);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public void ActivarDesactivar_941lp(string dni_941lp)
        {
            try
            {
                Usuario_941lp usuario_941lp = BuscarUsuarioPorDNI_941lp(dni_941lp);
                if (usuario_941lp.activo_941lp)
                {
                    usuario_941lp.activo_941lp = false;
                    MessageBox.Show("Se ha desactivado al usuario con exito");
                }
                else
                {
                    usuario_941lp.activo_941lp = true;
                    MessageBox.Show("Se ha activado al usuario con exito");
                }
                orm_941lp.Modificar_941lp(usuario_941lp);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public Usuario_941lp BuscarUsuarioPorDNI_941lp(string dni_941lp)
        {
            return orm_941lp.RetornarUsuarios_941lp().Find(x => x.dni_941lp == dni_941lp);
        }

        public void Desbloquear_941lp(string dni_941lp)
        {
            try
            {
                Usuario_941lp usuario_941lp = BuscarUsuarioPorDNI_941lp(dni_941lp);
                if (!usuario_941lp.bloqueo_941lp)
                {
                    throw new Exception("El usuario ya se encuentra desbloqueado");
                }
                usuario_941lp.bloqueo_941lp = false;
                orm_941lp.Modificar_941lp(usuario_941lp);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public void ModificarContraseña_941lp(Usuario_941lp usuario_941lp,string contraseñaNueva_941lp)
        {
            usuario_941lp.contraseña_941lp = HashearContraseña_941lp(contraseñaNueva_941lp);
            orm_941lp.Modificar_941lp(usuario_941lp);
        }

        public List<Usuario_941lp> RetornarUsuarios_941lp()
        {
            return orm_941lp.RetornarUsuarios_941lp();
        }
    }
}
