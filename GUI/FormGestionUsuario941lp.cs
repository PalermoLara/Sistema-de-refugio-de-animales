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
    public partial class FormGestionUsuario941lp : Form
    {
        bllUsuario_941lp bllUsuario_941lp;
        ModoOperacion_941lp modo_941lp;
        public FormGestionUsuario941lp()
        {
            InitializeComponent();
            bllUsuario_941lp = new bllUsuario_941lp();
            btnAplicar.Enabled = false;
            btnCancelar.Enabled = false;
            modo_941lp = ModoOperacion_941lp.Consulta;
        }

        private void FormAdministradorUsuario_Load(object sender, EventArgs e)
        {
            dataUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataUsuarios.MultiSelect = false;
            dataUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            MostrarGrillaUsuarios_941lp(bllUsuario_941lp.RetornarUsuarios_941lp());
            HabilitarTxt_941lp(false);
            DefinirModoEnTxt_941lp();
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
                txtApellidoUsuario.Enabled = habilitar_941lp;
                txtNombreUsuario.Enabled = habilitar_941lp;
                txtEmailUsuario.Enabled = habilitar_941lp;
                comboBoxRoles.Enabled = habilitar_941lp;
            }
            if(modo_941lp == ModoOperacion_941lp.Modificar)
            {
                txtDni.Enabled = !habilitar_941lp;
                txtApellidoUsuario.Enabled = habilitar_941lp;
                txtNombreUsuario.Enabled = habilitar_941lp;
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
        }

        private void MostrarGrillaUsuarios_941lp(List<Usuario_941lp> usuariosLista_941lp)
        {
            dataUsuarios.Rows.Clear();
            foreach (Usuario_941lp u_941lp in usuariosLista_941lp)
            {
                // Añadir una nueva fila
                int rowIndex = dataUsuarios.Rows.Add(u_941lp.dni_941lp, u_941lp.nombre_941lp, u_941lp.apellido_941lp, u_941lp.nombreUsuario_941lp, u_941lp.rol_941lp, u_941lp.email_941lp, u_941lp.bloqueo_941lp);
                // Si el usuario no está activo y el checkbox no está marcado, se pone en rojo
                if (!u_941lp.activo_941lp && !checkBoxActivosConsulta.Checked)
                {
                    dataUsuarios.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Red;
                }
                // Si el usuario está bloqueado, se pone en azul
                if (u_941lp.bloqueo_941lp && !checkBoxActivosConsulta.Checked && checkBoxTodosConsulta.Checked)
                {
                    dataUsuarios.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightSteelBlue;
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
            btnModificarUsuario.Enabled = false;
            btnSalir.Enabled = false;
            btnDesbloquearUsuario.Enabled = false;
            btnActivarDesactivar.Enabled = false;
            btnCancelar.Enabled = true;
            btnAplicar.Enabled = true;
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
                    if (dataUsuarios.SelectedRows.Count == 0) throw new Exception("Seleccione un usuario");
                }
                switch (modo_941lp)
                {
                    case ModoOperacion_941lp.Consulta:
                        btnAplicar.Enabled = true;
                        MostrarGrillaUsuarios_941lp(bllUsuario_941lp.RetornarUsuarios_941lp());
                        break;
                    case ModoOperacion_941lp.Alta:
                        ValidarCargaDeTxt_941lp();
                        ControlDeIngresoDeDatos_941lp(txtDni.Text, txtNombreUsuario.Text, txtApellidoUsuario.Text, comboBoxRoles.Text, txtEmailUsuario.Text);
                        if (bllUsuario_941lp.ValidarDNI_941lp(txtDni.Text)) { throw new Exception("DNI repetido"); }
                        bllUsuario_941lp.Alta_941lp(txtDni.Text,txtNombreUsuario.Text,txtApellidoUsuario.Text,comboBoxRoles.Text,txtEmailUsuario.Text);
                        MessageBox.Show("Usuario dado de alta exitosamente");
                        MostrarGrillaUsuarios_941lp(bllUsuario_941lp.RetornarUsuarios_941lp());
                        break;
                    case ModoOperacion_941lp.Modificar:
                        ControlDeIngresoDeDatos_941lp(txtDni.Text, txtNombreUsuario.Text, txtApellidoUsuario.Text, comboBoxRoles.Text, txtEmailUsuario.Text);
                        bllUsuario_941lp.Modificar_941lp(txtDni.Text, txtNombreUsuario.Text, txtApellidoUsuario.Text,  comboBoxRoles.Text, txtEmailUsuario.Text);
                        MessageBox.Show("Usuario modificado exitosamente");
                        MostrarGrillaUsuarios_941lp(bllUsuario_941lp.RetornarUsuarios_941lp());
                        break;
                    case ModoOperacion_941lp.ActivarDesactivar:
                        bllUsuario_941lp.ActivarDesactivar_941lp(txtDni.Text);
                        MostrarGrillaUsuarios_941lp(bllUsuario_941lp.RetornarUsuarios_941lp());

                        break;
                    case ModoOperacion_941lp.Desbloquear:
                        bllUsuario_941lp.Desbloquear_941lp(txtDni.Text);
                        MostrarGrillaUsuarios_941lp(bllUsuario_941lp.RetornarUsuarios_941lp());
                        break;
                    default:
                        MessageBox.Show("Error en la operación");
                        break;
                }
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
                throw new Exception("Debe completar todos los campos obligatorios.");
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
            btnAplicar.Enabled = false;
            btnAltaUsuario.Enabled = true;
            btnActivarDesactivar.Enabled = true;
            btnModificarUsuario.Enabled = true;
            btnDesbloquearUsuario.Enabled = true;
            btnSalir.Enabled = true;
            HabilitarTxt_941lp(false);
            DefinirModoEnTxt_941lp();
            LimpiarTxt_941lp();
        }

        private void checkBoxActivosConsulta_CheckedChanged(object sender, EventArgs e)
        {    
            ActualizarCheckboxesConsulta_941lp(checkBoxTodosConsulta);
        }

        private void checkBoxTodosConsulta_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarCheckboxesConsulta_941lp(checkBoxActivosConsulta);
        }

        private void ActualizarCheckboxesConsulta_941lp(CheckBox checkbox2_941lp)
        {
            try
            {
                // Desmarcar todos los checkboxes
                checkbox2_941lp.Checked = false;

                // Establecer el modo de operación
                modo_941lp = ModoOperacion_941lp.Consulta;

                // Mostrar la grilla de usuarios
                MostrarGrillaUsuarios_941lp(bllUsuario_941lp.RetornarUsuarios_941lp());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

                // Limpiar los puntos del DNI (por ejemplo "12.345.678" se convierte en "12345678")
                dni_941lp = dni_941lp.Replace(".", "");

                // Validaciones
                if (!regexDni.IsMatch(dni_941lp))
                    throw new ArgumentException("El DNI ingresado es inválido. Debe contener exactamente 8 dígitos.");
                if (!regexTexto_941lp.IsMatch(nombre_941lp))
                    throw new ArgumentException("El nombre ingresado es inválido. Solo se permiten letras y espacios.");
                if (!regexTexto_941lp.IsMatch(apellido_941lp))
                    throw new ArgumentException("El apellido ingresado es inválido. Solo se permiten letras y espacios.");
                if (!regexTexto_941lp.IsMatch(rol_941lp))
                    throw new ArgumentException("El rol ingresado es inválido. Solo se permiten letras y espacios.");
                if (!regexGmail_941lp.IsMatch(email_941lp))
                    throw new ArgumentException("El email ingresado debe ser una dirección válida de Gmail.");
            }
            catch (ArgumentException ex)
            {
                throw new Exception($"Error de validación: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error inesperado durante la validación de datos.", ex);
            }
        }
    }
}
