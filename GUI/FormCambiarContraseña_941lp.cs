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
    public partial class FormCambiarContraseña_941lp : Form
    {
        bllUsuario_941lp bllUsuario_941lp;
        public FormCambiarContraseña_941lp()
        {
            InitializeComponent();
            bllUsuario_941lp = new bllUsuario_941lp();
        }

        private void btnAceptarCambioContraseña_Click(object sender, EventArgs e)
        {
            try
            {
                string contraseñaActual_941lp = txtContraseñaActual.Text;
                string contraseñaNueva_941lp = txtContraseñaNueva.Text;
                string contraseñaConfirmacion_941lp = txtContraseñaConfirmacion.Text;
                if (bllUsuario_941lp.ValidarContraseñaActual_941lp(contraseñaActual_941lp) == false) throw new Exception("Contraseña actual incorrecta");
                if (contraseñaActual_941lp == contraseñaNueva_941lp) throw new Exception("La nueva contraseña no puede ser igual a la actual");
                if (contraseñaNueva_941lp != contraseñaConfirmacion_941lp) throw new Exception("La contraseña nueva y la confirmación no coinciden");
                bllUsuario_941lp.ModificarContraseña_941lp(sessionManager941lp.Gestor_941lp.RetornarUsuarioSession_941lp(), contraseñaNueva_941lp);
                MessageBox.Show("Su contraseña a sido modificada con exito");
                btnCancelar_Click(null, null);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void FormCambiarContraseña_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
