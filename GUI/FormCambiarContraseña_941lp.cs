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
    public partial class FormCambiarContraseña_941lp : Form, IObserver_941lp
    {
        bllUsuario_941lp bllUsuario_941lp;
        public FormCambiarContraseña_941lp()
        {
            InitializeComponent();
            bllUsuario_941lp = new bllUsuario_941lp();
            TraductorSubject_941lp.Instancia_941lp.Suscribir_941lp(this);
            AplicarTraduccion_941lp();
        }

        private void AplicarTraduccion_941lp()
        {
            string idioma = sessionManager941lp.Gestor_941lp.Idioma_941lp;
            TraductorHelper_941lp.TraducirControles_941lp(this, this.Name, idioma);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            TraductorSubject_941lp.Instancia_941lp.Desuscribir_941lp(this);
            base.OnFormClosed(e);
        }

        private void btnAceptarCambioContraseña_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtContraseñaActual.Text == "" || txtContraseñaConfirmacion.Text == "" || txtContraseñaNueva.Text == "")
                {
                    throw new Exception("Faltan ingresar contraseñas");
                }
                string contraseñaActual_941lp = txtContraseñaActual.Text;
                string contraseñaNueva_941lp = txtContraseñaNueva.Text;
                string contraseñaConfirmacion_941lp = txtContraseñaConfirmacion.Text;
                if (bllUsuario_941lp.ValidarContraseñaActual_941lp(sessionManager941lp.Gestor_941lp.RetornarUsuarioSession_941lp().nombreUsuario_941lp,contraseñaActual_941lp) == false) throw new Exception("Contraseña actual incorrecta");
                if (contraseñaActual_941lp == contraseñaNueva_941lp) throw new Exception("La nueva contraseña no puede ser igual a la actual");
                if (contraseñaNueva_941lp != contraseñaConfirmacion_941lp) throw new Exception("La contraseña nueva y la confirmación no coinciden");
                if (bllUsuario_941lp.VerificarContraseñaNoSeaDNIyApellido(bllUsuario_941lp.HashearContraseña_941lp(contraseñaNueva_941lp))) throw new Exception("La contraseña no puede ser su dni y apellido");
                bllUsuario_941lp.ModificarContraseña_941lp(sessionManager941lp.Gestor_941lp.RetornarUsuarioSession_941lp(), contraseñaNueva_941lp);
                MessageBox.Show("Su contraseña a sido modificada con exito");
                if (btnSalir.Enabled == false) { btnSalir.Enabled = true; }
                sessionManager941lp.Gestor_941lp.UnsetUsuario_941lp();
                GestorFormulario941lp.gestorFormSG_941lp.DefinirEstado_941lp(new EstadoLogIn941lp());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void FormCambiarContraseña_Load(object sender, EventArgs e)
        {
            if (sessionManager941lp.Gestor_941lp.RetornarUsuarioSession_941lp().contraseña_941lp ==bllUsuario_941lp.HashearContraseña_941lp(sessionManager941lp.Gestor_941lp.RetornarUsuarioSession_941lp().dni_941lp + sessionManager941lp.Gestor_941lp.RetornarUsuarioSession_941lp().apellido_941lp))
            {
                btnSalir.Enabled = false;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                txtContraseñaActual.Clear();
                txtContraseñaNueva.Clear();
                txtContraseñaConfirmacion.Clear();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void checkBoxMostrarConstraseñas_CheckedChanged(object sender, EventArgs e)
        {
            txtContraseñaActual.UseSystemPasswordChar = !checkBoxMostrarConstraseñas.Checked;
            txtContraseñaConfirmacion.UseSystemPasswordChar = !checkBoxMostrarConstraseñas.Checked;
            txtContraseñaNueva.UseSystemPasswordChar = !checkBoxMostrarConstraseñas.Checked;
        }

        public void ActualizarTraduccion_941lp(string idioma_941lp)
        {
            AplicarTraduccion_941lp();
        }
    }
}
