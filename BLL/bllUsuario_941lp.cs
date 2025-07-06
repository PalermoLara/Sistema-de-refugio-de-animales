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
        encriptador_941lp seguridad_941lp;
        ormPerfil_941lp ormPerfil_941lp;
        public bllUsuario_941lp()
        {
            orm_941lp = new ormUsuario_941lp();
            seguridad_941lp = new encriptador_941lp();
            ormPerfil_941lp = new ormPerfil_941lp();
        }

        public void Alta_941lp(string dni_941lp, string nombre_941lp, string apellido_941lp,string rol_941lp, string email_941lp)
        {
            try
            { 
                string nombreUsuario_941lp = dni_941lp + nombre_941lp;
                string contraseña_941lp = HashearContraseña_941lp(dni_941lp + apellido_941lp); // lógica de negocio: contraseña inicial hasheada
                Usuario_941lp nuevoUsuario_941lp = new Usuario_941lp( dni_941lp, nombreUsuario_941lp, contraseña_941lp, nombre_941lp, apellido_941lp, rol_941lp, email_941lp, false, 0, "es", true, null);
                orm_941lp.Alta_941lp(nuevoUsuario_941lp);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public bool VerificarContraseñaNoSeaDNIyApellido(string contraseña_941lp)
        {
            bool coincide_941lp = false;
            string contraseñaVieja_941lp = HashearContraseña_941lp(sessionManager941lp.Gestor_941lp.RetornarUsuarioSession_941lp().dni_941lp + sessionManager941lp.Gestor_941lp.RetornarUsuarioSession_941lp().apellido_941lp);
            if (contraseña_941lp== contraseñaVieja_941lp)
            {
                coincide_941lp = true;
            }
            return coincide_941lp;
        }

        public bool ValidarExistenciaNombreUsuario_941lp(string nombreUsuario_941lp)
        {
            return orm_941lp.ValidarExistenciaNombreUsuario_941lp(nombreUsuario_941lp);
        }

        public string HashearContraseña_941lp(string contraseñaUsuario_941lp)
        {
            return seguridad_941lp.GetSHA256_941lp(contraseñaUsuario_941lp);
        }

        public void ReiniciarIntentos_941lp(Usuario_941lp usuario_941lp)
        {
            usuario_941lp.intentos_941lp = 0;
            orm_941lp.Modificar_941lp(usuario_941lp);
        }


        public bool ValidarContraseñaActual_941lp(string usuario_941lp, string contraseña_941lp)
        {
            string contraseñaHasheada_941lp = HashearContraseña_941lp(contraseña_941lp);
            return orm_941lp.ValidarContraseña_941lp(usuario_941lp,contraseñaHasheada_941lp);
        }

        public bool ValidarDNI_941lp(string dni_941lp)
        {
            return orm_941lp.ValidarDni_941lp(dni_941lp);
        }

        public int AumentarIntentos_941lp(Usuario_941lp nombreUsuario941lp_941lp)
        {
            return orm_941lp.AumentarIntentos_941lp(nombreUsuario941lp_941lp);
        }

        public void Modificar_941lp(string dni_941lp, string rol_941lp, string email_941lp)
        {
            try
            {
                Usuario_941lp nuevoUsuario_941lp = BuscarUsuarioPorDNI_941lp(dni_941lp);
                nuevoUsuario_941lp.rol_941lp = rol_941lp;
                nuevoUsuario_941lp.email_941lp = email_941lp;
                orm_941lp.Modificar_941lp(nuevoUsuario_941lp);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public void CambiarIdioma_941lp(string dni_941lp, string idioma_941lp)
        {
            try
            {
                Usuario_941lp nuevoUsuario_941lp = BuscarUsuarioPorDNI_941lp(dni_941lp);
                nuevoUsuario_941lp.lenguaje_941lp = idioma_941lp;
                orm_941lp.Modificar_941lp(nuevoUsuario_941lp);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public void ActivarDesactivar_941lp(string dni_941lp)
        {
            try
            {
                Usuario_941lp usuario_941lp = BuscarUsuarioPorDNI_941lp(dni_941lp);
                if (usuario_941lp == null)
                {
                    MessageBox.Show("Usuario no encontrado");
                    return;
                }
                //Invierte el valor actual del campo activo_941lp
                usuario_941lp.activo_941lp = !usuario_941lp.activo_941lp;
                string mensaje = usuario_941lp.activo_941lp ? "Se ha activado al usuario con éxito" : "Se ha desactivado al usuario con éxito";
                orm_941lp.Modificar_941lp(usuario_941lp);
                MessageBox.Show(mensaje);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public Usuario_941lp BuscarUsuarioPorDNI_941lp(string dni_941lp)
        {
            return orm_941lp.ObtenerUsuarioPorDni_941lp(dni_941lp);
        }

        public void Desbloquear_941lp(string dni_941lp)
        {
            try
            {
                Usuario_941lp usuario_941lp = BuscarUsuarioPorDNI_941lp(dni_941lp);
                if (usuario_941lp == null)
                {
                    MessageBox.Show("Usuario no encontrado");
                    return;
                }
                else if (usuario_941lp.bloqueo_941lp)
                {
                    usuario_941lp.contraseña_941lp = HashearContraseña_941lp(usuario_941lp.dni_941lp + usuario_941lp.apellido_941lp);
                    usuario_941lp.bloqueo_941lp = false;
                    usuario_941lp.intentos_941lp = 0;
                    usuario_941lp.horaDesbloquear_941lp = null;
                    orm_941lp.Modificar_941lp(usuario_941lp);
                    MessageBox.Show("Usuario desbloqueado exitosamente");
                }
                else
                {
                    MessageBox.Show("El usuario ya se encuentra desbloqueado");
                    return;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public bool UsuarioActivo_941lp(Usuario_941lp usuario_941lp)
        {
            return usuario_941lp.activo_941lp;
        }

        public bool UsuarioBloqueado_941lp(Usuario_941lp usuario_941lp)
        {
            if (!usuario_941lp.bloqueo_941lp)
                return false;

            if (usuario_941lp.intentos_941lp < 3 && usuario_941lp.horaDesbloquear_941lp.HasValue && DateTime.Now > usuario_941lp.horaDesbloquear_941lp.Value.AddMinutes(1))
            {
                usuario_941lp.bloqueo_941lp = false;
                usuario_941lp.intentos_941lp = 0;
                usuario_941lp.horaDesbloquear_941lp = null;
                orm_941lp.Modificar_941lp(usuario_941lp);
                return false;
            }

            return true;
        }

        public bool ValidarAdminSupremo(string nombreUsuario_941lp, string contraseña_941lp)
        {
            bool adminSupremo = false;
            if(ormUsuario_941lp.AdminSupremo.nombreUsuario_941lp == nombreUsuario_941lp && ormUsuario_941lp.AdminSupremo.contraseña_941lp == contraseña_941lp)
            {
                adminSupremo = true;
            }
            return adminSupremo;
        }

        public void SetAdminSupremo()
        {
            sessionManager941lp.Gestor_941lp.SetUsuario_941lp(ormUsuario_941lp.AdminSupremo);
        }

        public bool ValidarEmail_941lp(string email_941lp, string dni_941lp)
        {
            return orm_941lp.ValidarEmail_941lp(email_941lp, dni_941lp);
        }

        public void ModificarContraseña_941lp(Usuario_941lp usuario_941lp,string contraseñaNueva_941lp)
        {
            usuario_941lp.contraseña_941lp = HashearContraseña_941lp(contraseñaNueva_941lp);
            orm_941lp.Modificar_941lp(usuario_941lp);
            sessionManager941lp.Gestor_941lp.SetUsuario_941lp(usuario_941lp);
        }

        public List<Usuario_941lp> RetornarUsuarios_941lp()
        {
            return orm_941lp.RetornarUsuarios_941lp();
        }

        public HashSet<string> ObtenerPermisosSimplesDeUsuario_941lp(string nombrePerfil)
        {
            var perfilComposite = ormPerfil_941lp.ObtenerCompositePerfiles_941lp(); 

            if (!perfilComposite.TryGetValue(nombrePerfil, out var perfil))
                throw new Exception($"Perfil '{nombrePerfil}' no encontrado.");

            var permisosSimples = new HashSet<string>();
            ExpandirPermisosSimplesRecursivo_941lp((Familia_941lp)perfil, permisosSimples);
            return permisosSimples;
        }

        private void ExpandirPermisosSimplesRecursivo_941lp(Familia_941lp familia, HashSet<string> acumulador)
        {
            foreach (var permiso in familia.ObtenerPermisos_941lp())
            {
                if (permiso is PermisoSimple_941lp simple)
                {
                    acumulador.Add(simple.nombrePermiso_941lp);
                }
                else if (permiso is Familia_941lp subFamilia)
                {
                    ExpandirPermisosSimplesRecursivo_941lp(subFamilia, acumulador);
                }
            }
        }

    }
}
