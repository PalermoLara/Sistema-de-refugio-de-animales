using BE;
using BLL;
using SERVICIOS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormularioLogIn941lp : Form
    {
        bllUsuario_941lp bllUsuario_941lp;
        private readonly FormCambiarContraseña_941lp formularioCambiarContraseña_941lp;
        bllBitacoraEventos_941lp bllBitacoraEvento_941lp;
        public FormularioLogIn941lp()
        {
            InitializeComponent();
            bllUsuario_941lp = new bllUsuario_941lp();
            formularioCambiarContraseña_941lp = new FormCambiarContraseña_941lp();
            bllBitacoraEvento_941lp = new bllBitacoraEventos_941lp();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNombreUsuario.Text == "" || txtContraseñaUsuario.Text == "") throw new Exception("Faltan ingresar datos");
                if (sessionManager941lp.Gestor_941lp.RetornarUsuarioSession_941lp() != null) throw new Exception("Ya hay una sesión iniciada");
                if (bllUsuario_941lp.ValidarAdminSupremo(txtNombreUsuario.Text, txtContraseñaUsuario.Text))
                {
                    bllUsuario_941lp.SetAdminSupremo();
                    GestorFormulario941lp.gestorFormSG_941lp.DefinirEstado_941lp(new EstadoMenu941lp());
                }
                else
                {
                    if (bllUsuario_941lp.ValidarExistenciaNombreUsuario_941lp(txtNombreUsuario.Text.Trim()))
                    {
                        Usuario_941lp usuario_941lp = bllUsuario_941lp.RetornarUsuarios_941lp().Find(x => x.nombreUsuario_941lp == txtNombreUsuario.Text);
                        if (bllUsuario_941lp.UsuarioActivo_941lp(usuario_941lp))
                        {
                            if (!(bllUsuario_941lp.UsuarioBloqueado_941lp(usuario_941lp)))
                            {
                                if (bllUsuario_941lp.ValidarContraseñaActual_941lp(usuario_941lp.nombreUsuario_941lp, txtContraseñaUsuario.Text))
                                {
                                    bllUsuario_941lp.ReiniciarIntentos_941lp(usuario_941lp);
                                    sessionManager941lp.Gestor_941lp.SetUsuario_941lp(usuario_941lp);
                                    if (bllUsuario_941lp.VerificarContraseñaNoSeaDNIyApellido(sessionManager941lp.Gestor_941lp.RetornarUsuarioSession_941lp().contraseña_941lp))
                                    {
                                        MessageBox.Show("Primer inicio de sesión. Debe cambiar su contraseña", "CAMBIO DE CONTRASEÑA REQUERIDO", MessageBoxButtons.OK);
                                        formularioCambiarContraseña_941lp.ShowDialog();
                                    }
                                    sessionManager941lp.Gestor_941lp.Idioma_941lp = usuario_941lp.lenguaje_941lp;
                                    TraductorSubject_941lp.Instancia_941lp.Notificar_941lp(usuario_941lp.lenguaje_941lp);
                                    var usuario = sessionManager941lp.Gestor_941lp.RetornarUsuarioSession_941lp();
                                    var perfilNombre = usuario.rol_941lp; 
                                    var permisosSimples = bllUsuario_941lp.ObtenerPermisosSimplesDeUsuario_941lp(perfilNombre);

                                    sessionManager941lp.Gestor_941lp.SetPermisosUsuario_941lp(permisosSimples);
                                    bllBitacoraEvento_941lp.Alta_941lp(sessionManager941lp.Gestor_941lp.RetornarUsuarioSession_941lp().nombreUsuario_941lp, "Iniciar sesión", "Incio de sesión de usuario", 1);
                                    GestorFormulario941lp.gestorFormSG_941lp.DefinirEstado_941lp(new EstadoMenu941lp());
                                }
                                else
                                {
                                    if (bllUsuario_941lp.AumentarIntentos_941lp(usuario_941lp) == 3)
                                    {
                                        MessageBox.Show("Usted a sido bloqueado");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Contraseña incorrecta");
                                    }
                                }
                            }
                            else
                            {

                                MessageBox.Show("Usuario bloqueado");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Usuario inactivo");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Usuario no encontrado");
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void FormularioLogIn941lp_Load(object sender, EventArgs e)
        {

        }

        private void FormularioLogIn941lp_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnIniciarSesion.PerformClick();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void FormularioLogIn941lp_Load_1(object sender, EventArgs e)
        {
        }

        private void checkBoxMostrarConstraseña_CheckedChanged(object sender, EventArgs e)
        {
            txtContraseñaUsuario.UseSystemPasswordChar = !checkBoxMostrarConstraseña.Checked;
        }
    }
}
