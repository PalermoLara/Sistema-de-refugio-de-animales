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
        public FormularioLogIn941lp()
        {
            InitializeComponent();
            bllUsuario_941lp = new bllUsuario_941lp();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNombreUsuario.Text == "" || txtContraseñaUsuario.Text == "") throw new Exception("Faltan ingresar datos");
                if (bllUsuario_941lp.ValidarExistenciaNombreUsuario_941lp(txtNombreUsuario.Text.Trim()))
                {
                    Usuario_941lp usuario_941lp = bllUsuario_941lp.RetornarUsuarios_941lp().Find(x => x.nombreUsuario_941lp == txtNombreUsuario.Text);
                    if (bllUsuario_941lp.ValidarContraseñaActual_941lp(txtContraseñaUsuario.Text))
                    {
                        if (usuario_941lp.activo_941lp == true)
                        {
                            if (usuario_941lp.bloqueo_941lp == false)
                            {
                                sessionManager941lp.Gestor_941lp.LogIn(usuario_941lp);
                                GestorFormulario941lp.gestorFormSG_941lp.DefinirEstado_941lp(new EstadoMenu941lp());
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
                        bllUsuario_941lp.AumentarIntentos_941lp(usuario_941lp);
                        MessageBox.Show("Contraseña incorrecta");
                    }
                }
                else
                {
                    MessageBox.Show("Usuario no encontrado");
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
    }
}
