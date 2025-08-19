using BE;
using BLL;
using Microsoft.VisualBasic;
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
    public partial class FormularioMenuPrincipal941lp : Form, IObserver_941lp
    {
        bllUsuario_941lp bllUsuario_941lp;
        private readonly FormGestionUsuario941lp formularioAdministradorUsuario_941lp;
        private readonly FormCambiarContraseña_941lp formularioCambiarContraseña_941lp;
        private FormularioLogIn941lp formularioLogIn941lp;
        private FormRegistroAnimales_941lp formRegistroDeAnimales_941lp;
        private FormGestorCedentes_941lp formGestorCedentes_941Lp;
        private FormFichaDeIngreso_941lp formFichaDeIngreso_941Lp;
        private FormGestionFichaMedica_941lp formGestionFichaMedica_941lp;
        private FormMedicamentos_941lp formMedicamentos_941lp;
        private FormGeneracionDePerfiles_941lp formGestionDePerfiles_941lp;
        private FormCambioDeIdioma_941lp FormCambioDeIdioma_941lp;
        private formBitacoraEventos_941lp formBitacoraEventos_941lp;
        private List<Panel> submenus_941lp;

        public FormularioMenuPrincipal941lp()
        {
            InitializeComponent();
            InicializarSubmenus_941lp();
            bllUsuario_941lp = new bllUsuario_941lp();
            formularioAdministradorUsuario_941lp = new FormGestionUsuario941lp();
            formularioCambiarContraseña_941lp = new FormCambiarContraseña_941lp();
            formularioLogIn941lp = new FormularioLogIn941lp();
            formRegistroDeAnimales_941lp = new FormRegistroAnimales_941lp();
            formGestorCedentes_941Lp = new FormGestorCedentes_941lp();
            formFichaDeIngreso_941Lp = new FormFichaDeIngreso_941lp();
            formGestionFichaMedica_941lp = new FormGestionFichaMedica_941lp();
            formMedicamentos_941lp = new FormMedicamentos_941lp();
            formGestionDePerfiles_941lp = new FormGeneracionDePerfiles_941lp();
            FormCambioDeIdioma_941lp = new FormCambioDeIdioma_941lp();
            formBitacoraEventos_941lp = new formBitacoraEventos_941lp();
        }

        private void AplicarTraduccion_941lp()
        {
            string idioma = sessionManager941lp.Gestor_941lp.Idioma_941lp;
            RecorrerControlesParaTraducir_941lp.TraducirControles_941lp(this, this.Name, idioma);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            TraductorSubject_941lp.Instancia_941lp.Desuscribir_941lp(this);
            base.OnFormClosed(e);
        }

        private void InicializarSubmenus_941lp()
        {
            submenus_941lp = new List<Panel>
            {
                panelSubMenuAdministrador,
                panelSubMenuMaestro,
                panelSubMenuUsuario,
                panelSubMenuResportes,
                panelSubMenuFichas
            };
            OcultarSubmenus_941lp();
        }

        private void OcultarSubmenus_941lp()
        {
            foreach (var panel_941lp in submenus_941lp)
                panel_941lp.Visible = false;
        }

        private void MostrarSubMenu_941lp(Panel submenu_941lp)
        {
            bool estabaVisible_941lp = submenu_941lp.Visible;
            OcultarSubmenus_941lp();
            submenu_941lp.Visible = !estabaVisible_941lp;
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                string titulo_941lp = TraductorHelper_941lp.TraducirMensaje_941lp(this.Name, "MSG_TITULO_CERRAR_SESION", "CERRAR SESIÓN...");
                string cuerpo_941lp = TraductorHelper_941lp.TraducirMensaje_941lp(this.Name, "MSG_PREGUNTA_CERRAR_SESION", "¿Desea cerrar la sesión?");
                DialogResult dr_941lp = MessageBox.Show(cuerpo_941lp, titulo_941lp, MessageBoxButtons.OKCancel);
                if(dr_941lp == DialogResult.OK)
                {
                    var usuario_941lp = sessionManager941lp.Gestor_941lp.RetornarUsuarioSession_941lp();
                    usuario_941lp.lenguaje_941lp = sessionManager941lp.Gestor_941lp.Idioma_941lp;
                    bllUsuario_941lp.CambiarIdioma_941lp(usuario_941lp.dni_941lp, usuario_941lp.lenguaje_941lp);
                    sessionManager941lp.Gestor_941lp.UnsetUsuario_941lp();
                    GestorFormulario941lp.gestorFormSG_941lp.DefinirEstado_941lp(new EstadoLogIn941lp());
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnGestionDeUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                formularioAdministradorUsuario_941lp.Owner = this;
                formularioAdministradorUsuario_941lp.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnCambiarContraseña_Click(object sender, EventArgs e)
        {
            try
            {
                formularioCambiarContraseña_941lp.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void FormularioMenu_Load(object sender, EventArgs e)
        {
            if (bllUsuario_941lp.ValidarAdminSupremo(sessionManager941lp.Gestor_941lp.RetornarUsuarioSession_941lp().nombreUsuario_941lp, sessionManager941lp.Gestor_941lp.RetornarUsuarioSession_941lp().contraseña_941lp))
            {
                btnCambiarContraseña.Enabled = false;
            }
            var permisos_941lp = sessionManager941lp.Gestor_941lp.RetornarPermisosUsuario_941lp();
            var perfil_941lp = sessionManager941lp.Gestor_941lp.RetornarUsuarioSession_941lp().rol_941lp;
            AplicarPermisosAFormulario_941lp(this, permisos_941lp, perfil_941lp);
            TraductorSubject_941lp.Instancia_941lp.Suscribir_941lp(this);
            AplicarTraduccion_941lp();
        }

        public void RefrescarPermisos_941lp()
        {
            var usuario_941lp = sessionManager941lp.Gestor_941lp.RetornarUsuarioSession_941lp();
            var permisos_941lp = bllUsuario_941lp.ObtenerPermisosSimplesDeUsuario_941lp(usuario_941lp.rol_941lp);
            AplicarPermisosAFormulario_941lp(this, permisos_941lp, usuario_941lp.rol_941lp);
        }

        private void btnUsuarioMenuPrincipal_Click(object sender, EventArgs e)
        {
            try
            {
                MostrarSubMenu_941lp(panelSubMenuUsuario);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnAdministradorMenuPrincipal_Click(object sender, EventArgs e)
        {
            try
            {
                MostrarSubMenu_941lp(panelSubMenuAdministrador);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnMaestroMenuPrincipal_Click(object sender, EventArgs e)
        {
            try
            {
                MostrarSubMenu_941lp(panelSubMenuMaestro);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnFichas_Click(object sender, EventArgs e)
        {
            try
            {
                MostrarSubMenu_941lp(panelSubMenuFichas);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            try
            {
                MostrarSubMenu_941lp(panelSubMenuResportes);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            try
            {
                OcultarSubmenus_941lp();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnIniciarSesion2_Click(object sender, EventArgs e)
        {
            try
            {
                formularioLogIn941lp.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnAnimales_Click(object sender, EventArgs e)
        {
            formRegistroDeAnimales_941lp.ShowDialog();
        }

        private void btnAbrirRegistroCedentes_Click(object sender, EventArgs e)
        {
            formGestorCedentes_941Lp.ShowDialog();
        }

        private void btnFichaIngreso_Click(object sender, EventArgs e)
        {
            formFichaDeIngreso_941Lp.ShowDialog();
        }

        private void btnFichaMedica_Click(object sender, EventArgs e)
        {
            formGestionFichaMedica_941lp.ShowDialog();
        }

        private void btnABMMedicamentos_Click(object sender, EventArgs e)
        {
            formMedicamentos_941lp.ShowDialog();
        }

        private void btnGestionarPerfiles_Click(object sender, EventArgs e)
        {
            formGestionDePerfiles_941lp.Owner = this;
            formGestionDePerfiles_941lp.ShowDialog();
        }

        public void AplicarPermisosAFormulario_941lp(Form formulario_941lp, HashSet<string> permisosSimples_941lp, string nombrePerfil_941lp)
        {
            foreach (Control control_941lp in formulario_941lp.Controls)
            {
                AplicarPermisosRecursivo_941lp(control_941lp, permisosSimples_941lp, nombrePerfil_941lp);
            }
        }

        private void AplicarPermisosRecursivo_941lp(Control control_941lp, HashSet<string> permisos_941lp, string nombrePerfil_941lp)
        {
            if (control_941lp is Button btn_941lp)
            {
                if (btn_941lp.Tag == null || btn_941lp.Tag == "")
                {
                    btn_941lp.Enabled = true; // Siempre habilitado si no tiene tag
                }
                else
                {
                    string tag_941lp = btn_941lp.Tag.ToString().Trim();

                    // Habilitar si el tag está en los permisos simples o es el nombre del perfil
                    btn_941lp.Enabled = permisos_941lp.Contains(tag_941lp) || tag_941lp.Equals(nombrePerfil_941lp, StringComparison.OrdinalIgnoreCase);
                }
            }

            // Recorrer hijos (como Paneles, GroupBoxes, etc.)
            foreach (Control hijo_941lp in control_941lp.Controls)
            {
                AplicarPermisosRecursivo_941lp(hijo_941lp, permisos_941lp, nombrePerfil_941lp);
            }
        }

        public void ActualizarTraduccion_941lp(string idioma_941lp)
        {
            AplicarTraduccion_941lp();
        }

        private void btnCambiarIdioma_Click(object sender, EventArgs e)
        {
            FormCambioDeIdioma_941lp.ShowDialog();
        }

        private void btnBitacoraEventos_Click(object sender, EventArgs e)
        {
            formBitacoraEventos_941lp.ShowDialog();
        }
    }
}
