using BE;
using BLL;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using SERVICIOS;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Net;

namespace GUI
{
    public partial class FormGestionUsuario941lp : Form, IObserver_941lp
    {
        bllUsuario_941lp bllUsuario_941lp;
        bllPerfil_941lp bllPerfil_941lp;
        ModoOperacion_941lp modo_941lp;
        public FormGestionUsuario941lp()
        {
            InitializeComponent();
            bllUsuario_941lp = new bllUsuario_941lp();
            bllPerfil_941lp = new bllPerfil_941lp();
            btnAplicar.Enabled = false;
            btnCancelar.Enabled = false;
            modo_941lp = ModoOperacion_941lp.Consulta;
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

        private void FormAdministradorUsuario_Load(object sender, EventArgs e)
        {
            dataUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataUsuarios.MultiSelect = false;
            dataUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            txtModo.ReadOnly = true;
            MostrarGrillaUsuarios_941lp(bllUsuario_941lp.RetornarUsuarios_941lp());
            HabilitarTxt_941lp(false);
            DefinirModoEnTxt_941lp();
            LlenarComboBoxCompuestos_941lp(bllPerfil_941lp.RetornarPerfiles_941lp());
            TraductorSubject_941lp.Instancia_941lp.Suscribir_941lp(this);
            AplicarTraduccion_941lp();
        }

        private void LlenarComboBoxCompuestos_941lp(List<Perfil_941lp> listaPermisos_941lp)
        {
            comboBoxRoles.Items.Clear();
            foreach (var permiso_941lp in listaPermisos_941lp)
            {
                if (permiso_941lp.GetType() == typeof(Familia_941lp))
                    comboBoxRoles.Items.Add(permiso_941lp.nombrePermiso_941lp);
            }
        }

        enum ModoOperacion_941lp
        {
            Consulta,
            Alta,
            Modificar,
            ActivarDesactivar,
            Desbloquear
        }

        private void HabilitarTxt_941lp(bool habilitar_941lp)
        {
            if(modo_941lp==ModoOperacion_941lp.Alta)
            {
                txtDni.Enabled = habilitar_941lp;
                AplicarColorControles_941lp(txtDni);
                txtApellidoUsuario.Enabled = habilitar_941lp;
                AplicarColorControles_941lp(txtApellidoUsuario);
                txtNombreUsuario.Enabled = habilitar_941lp;
                AplicarColorControles_941lp(txtNombreUsuario);
                txtEmailUsuario.Enabled = habilitar_941lp;
                AplicarColorControles_941lp(txtEmailUsuario);
                comboBoxRoles.Enabled = habilitar_941lp;
                AplicarColorControles_941lp(comboBoxRoles);
            }
            if(modo_941lp == ModoOperacion_941lp.Modificar)
            {
                txtDni.Enabled = !habilitar_941lp;
                txtApellidoUsuario.Enabled = !habilitar_941lp;
                txtNombreUsuario.Enabled = !habilitar_941lp;
                txtEmailUsuario.Enabled = habilitar_941lp;
                comboBoxRoles.Enabled = habilitar_941lp;
            }
            else
            {
                txtDni.Enabled = habilitar_941lp;
                txtApellidoUsuario.Enabled = habilitar_941lp;
                txtNombreUsuario.Enabled = habilitar_941lp;
                txtEmailUsuario.Enabled = habilitar_941lp;
                comboBoxRoles.Enabled = habilitar_941lp;
            }
            AplicarColorControles_941lp(txtDni);
            AplicarColorControles_941lp(txtApellidoUsuario);
            AplicarColorControles_941lp(txtNombreUsuario);
            AplicarColorControles_941lp(txtEmailUsuario);
            AplicarColorControles_941lp(comboBoxRoles);
        }

        private void MostrarGrillaUsuarios_941lp(List<Usuario_941lp> usuariosLista_941lp)
        {
            dataUsuarios.Rows.Clear();

            foreach (Usuario_941lp u_941lp in usuariosLista_941lp)
            {
                // Si está seleccionada la opción de solo activos, y el usuario no lo es, lo omitimos
                if (rbActivosConsulta.Checked && !u_941lp.activo_941lp)
                {
                    continue;
                }

                // Agregar la fila
                int rowIndex = dataUsuarios.Rows.Add(u_941lp.dni_941lp,u_941lp.nombre_941lp,u_941lp.apellido_941lp,u_941lp.nombreUsuario_941lp,u_941lp.rol_941lp,u_941lp.email_941lp,u_941lp.bloqueo_941lp);

                // Aplicar color solo si está seleccionada la opción "Todos"
                if (rbTodosConsulta.Checked)
                {
                    if (!u_941lp.activo_941lp)
                    {
                        dataUsuarios.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Red;
                    }
                    else if (u_941lp.bloqueo_941lp)
                    {
                        dataUsuarios.Rows[rowIndex].DefaultCellStyle.BackColor = Color.MediumPurple;
                    }
                }
            }
        }

        private void btnAltaUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                modo_941lp = ModoOperacion_941lp.Alta;
                VisibilidadDeBotones_941lp();
                HabilitarTxt_941lp(true);
                DefinirModoEnTxt_941lp();
                LimpiarTxt_941lp();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message);
            }
        }

        private void VisibilidadDeBotones_941lp()
        {
            btnAltaUsuario.Enabled = false;
            AplicarColorControles_941lp(btnAltaUsuario);
            btnModificarUsuario.Enabled = false;
            AplicarColorControles_941lp(btnModificarUsuario);
            btnSalir.Enabled = false;
            AplicarColorControles_941lp(btnSalir);
            btnDesbloquearUsuario.Enabled = false;
            AplicarColorControles_941lp(btnDesbloquearUsuario);
            btnActivarDesactivar.Enabled = false;
            AplicarColorControles_941lp(btnActivarDesactivar);        
            btnCancelar.Enabled = true;
            AplicarColorControles_941lp(btnCancelar);
            btnAplicar.Enabled = true;
            AplicarColorControles_941lp(btnAplicar);
        }

        private void DefinirModoEnTxt_941lp()
        {
            txtModo.Text = modo_941lp.ToString();
        }

        private void btnActDesactUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                modo_941lp = ModoOperacion_941lp.ActivarDesactivar;
                VisibilidadDeBotones_941lp();
                HabilitarTxt_941lp(false);
                DefinirModoEnTxt_941lp();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message);
            }
        }

        private void btnModificarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                modo_941lp = ModoOperacion_941lp.Modificar;
                VisibilidadDeBotones_941lp();
                HabilitarTxt_941lp(true);
                DefinirModoEnTxt_941lp();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); 
            }
        }

        private void dataUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(modo_941lp!=ModoOperacion_941lp.Alta)
                {
                    txtDni.Text = dataUsuarios.SelectedRows[0].Cells[0].Value.ToString();
                    //nombre real
                    txtNombreUsuario.Text = dataUsuarios.SelectedRows[0].Cells[1].Value.ToString();
                    txtApellidoUsuario.Text = dataUsuarios.SelectedRows[0].Cells[2].Value.ToString();
                    comboBoxRoles.Text = dataUsuarios.SelectedRows[0].Cells[4].Value.ToString();
                    txtEmailUsuario.Text = dataUsuarios.SelectedRows[0].Cells[5].Value.ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnDesbloquearUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                modo_941lp = ModoOperacion_941lp.Desbloquear;
                VisibilidadDeBotones_941lp();
                HabilitarTxt_941lp(false);
                DefinirModoEnTxt_941lp();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); 
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                if (modo_941lp != ModoOperacion_941lp.Consulta && modo_941lp != ModoOperacion_941lp.Alta)
                {
                    string mensaje_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGestionUsuario941lp", "MSG_SELECCIONAR_USUARIO_FALTA", "Seleccione un usuario");
                    if (dataUsuarios.SelectedRows.Count == 0) throw new Exception(mensaje_941lp);
                }
                switch (modo_941lp)
                {
                    case ModoOperacion_941lp.Consulta:
                        btnAplicar.Enabled = true;
                        break;
                    case ModoOperacion_941lp.Alta:
                        ValidarCargaDeTxt_941lp();
                        ControlDeIngresoDeDatos_941lp(txtDni.Text, txtNombreUsuario.Text, txtApellidoUsuario.Text, comboBoxRoles.Text, txtEmailUsuario.Text);
                        string exception_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGestionUsuario941lp", "MSG_DNI_REPETIDO", "DNI repetido");
                        if (bllUsuario_941lp.ValidarDNI_941lp(txtDni.Text)) { throw new Exception(exception_941lp); }
                        string exception1_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGestionUsuario941lp", "MSG_EMAIL_REPETIDO", "Email repetido");
                        if (bllUsuario_941lp.ValidarEmail_941lp(txtEmailUsuario.Text, txtDni.Text)) throw new Exception(exception1_941lp);
                        bllUsuario_941lp.Alta_941lp(txtDni.Text,txtNombreUsuario.Text,txtApellidoUsuario.Text,comboBoxRoles.Text,txtEmailUsuario.Text);
                        string mensaje_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGestionUsuario941lp", "MSG_USUARIO_ALTA_EXITOSAMENTE", "Usuario dado de alta exitosamente");
                        MessageBox.Show(mensaje_941lp);
                        break;
                    case ModoOperacion_941lp.Modificar:
                        ValidarCargaDeTxt_941lp();
                        ControlDeIngresoDeDatos_941lp(txtDni.Text, txtNombreUsuario.Text, txtApellidoUsuario.Text, comboBoxRoles.Text, txtEmailUsuario.Text);
                        string exception2_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGestionUsuario941lp", "MSG_EMAIL_REPETIDO", "Email repetido");
                        if (bllUsuario_941lp.ValidarEmail_941lp(txtEmailUsuario.Text, txtDni.Text)) throw new Exception(exception2_941lp);
                        bllUsuario_941lp.Modificar_941lp(txtDni.Text,comboBoxRoles.Text, txtEmailUsuario.Text);
                        string mensaje1_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGestionUsuario941lp", "MSG_USUARIO_MODIFICADO_EXITOSAMENTE", "Usuario modificado exitosamente");
                        MessageBox.Show(mensaje1_941lp);
                        break;
                    case ModoOperacion_941lp.ActivarDesactivar:
                        bllUsuario_941lp.ActivarDesactivar_941lp(dataUsuarios.SelectedRows[0].Cells[0].Value.ToString());
                        break;
                    case ModoOperacion_941lp.Desbloquear:
                        bllUsuario_941lp.Desbloquear_941lp(dataUsuarios.SelectedRows[0].Cells[0].Value.ToString());
                        break;
                    default:
                        string mensaje2_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGestionUsuario941lp", "MSG_ERROR_EN_LA_OPERACION", "Error en la operación");
                        MessageBox.Show(mensaje2_941lp);
                        break;
                }
                MostrarGrillaUsuarios_941lp(bllUsuario_941lp.RetornarUsuarios_941lp());
                ModoAceptarCancelar_941lp();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void ValidarCargaDeTxt_941lp()
        {
            if (string.IsNullOrWhiteSpace(txtDni.Text) ||
                        string.IsNullOrWhiteSpace(txtNombreUsuario.Text) ||
                        string.IsNullOrWhiteSpace(txtApellidoUsuario.Text)  ||
                        string.IsNullOrWhiteSpace(txtEmailUsuario.Text) ||
                        comboBoxRoles.SelectedItem == null)
            {
                string exception_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGestionUsuario941lp", "MSG_FALTAN_CAMPOS_OBLIGATORIOS", "Debe completar todos los campos obligatorios.");
                throw new Exception(exception_941lp);
            }
        }
        private void LimpiarTxt_941lp()
        {
            foreach (Control c_941lp in this.Controls)
            {
                if (c_941lp is TextBox t_941lp && t_941lp.Name != "txtModo")
                {
                    t_941lp.Text = "";
                }
            }
            comboBoxRoles.SelectedItem = null;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                ModoAceptarCancelar_941lp();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void ModoAceptarCancelar_941lp()
        {
            modo_941lp = ModoOperacion_941lp.Consulta;
            btnCancelar.Enabled = false;
            AplicarColorControles_941lp(btnCancelar);
            btnAplicar.Enabled = false;
            AplicarColorControles_941lp(btnAplicar);
            btnAltaUsuario.Enabled = true;
            AplicarColorControles_941lp(btnAltaUsuario);
            btnActivarDesactivar.Enabled = true;
            AplicarColorControles_941lp(btnActivarDesactivar);
            btnModificarUsuario.Enabled = true;
            AplicarColorControles_941lp(btnModificarUsuario);
            btnDesbloquearUsuario.Enabled = true;
            AplicarColorControles_941lp(btnDesbloquearUsuario);
            btnSalir.Enabled = true;
            AplicarColorControles_941lp(btnSalir);
            HabilitarTxt_941lp(false);
            DefinirModoEnTxt_941lp();
            LimpiarTxt_941lp();
        }

        private void AplicarColorControles_941lp(Control control_941lp)
        {
            if(control_941lp.Enabled == false)
            {
                control_941lp.BackColor = Color.LightSteelBlue;
            }
            else
            {
                control_941lp.BackColor = Color.White;
            }
        }

        private void ControlDeIngresoDeDatos_941lp(string dni_941lp, string nombre_941lp, string apellido_941lp, string rol_941lp, string email_941lp)
        {
            try
            {
                // Regex reutilizables
                var regexTexto_941lp = new Regex(@"^[A-Za-zÁÉÍÓÚáéíóúÑñÜü\s]+$");
                var regexGmail_941lp = new Regex(@"^[a-zA-Z0-9._%+-]+@gmail\.com$", RegexOptions.IgnoreCase);
                var regexDni = new Regex(@"^\d{8}$");
                // Validaciones
                if (!regexDni.IsMatch(dni_941lp))
                {
                    string exception_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGestionUsuario941lp", "MSG_DNI_INVALIDO", "El DNI ingresado es inválido. Debe contener exactamente 8 dígitos y solo números.");
                    throw new ArgumentException(exception_941lp);
                }
                if (!regexTexto_941lp.IsMatch(nombre_941lp))
                {
                    string exception_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGestionUsuario941lp", "MSG_NOMBRE_INVALIDO", "El nombre ingresado es inválido. Solo se permiten letras y espacios.");
                    throw new ArgumentException(exception_941lp);
                }
                if (!regexTexto_941lp.IsMatch(apellido_941lp))
                {
                    string exception_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGestionUsuario941lp", "MSG_APELLIDO_INVALIDO", "El apellido ingresado es inválido. Solo se permiten letras y espacios.");
                    throw new ArgumentException(exception_941lp);
                }
                if (!regexGmail_941lp.IsMatch(email_941lp))
                {
                    string exception_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGestionUsuario941lp", "MSG_EMAIL_INVALIDO", "El email ingresado debe ser una dirección válida de Gmail.");
                    throw new ArgumentException(exception_941lp);
                }
            }
            catch (ArgumentException ex)
            {
                string exception_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGestionUsuario941lp", "MSG_ERROR_VALIDACION", $"Error de validación");
                throw new Exception($"{exception_941lp}: { ex.Message }");
            }
            catch (Exception ex)
            {
                string exception_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGestionUsuario941lp", "MSG_ERROR_INESPERADO", $"Ocurrió un error inesperado durante la validación de datos.{ex}");
                throw new Exception(exception_941lp);
            }
        }

        private void rbTodosConsulta_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                MostrarGrillaUsuarios_941lp(bllUsuario_941lp.RetornarUsuarios_941lp());
            }
            catch (Exception ex){ MessageBox.Show(ex.Message); }
        }

        private void rbActivosConsulta_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                MostrarGrillaUsuarios_941lp(bllUsuario_941lp.RetornarUsuarios_941lp());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public void ActualizarTraduccion_941lp(string idioma_941lp)
        {
            AplicarTraduccion_941lp();
        }
    }
}
