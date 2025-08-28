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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormGestionAdoptantes_941lp : Form, IObserver_941lp
    {
        bllAdoptantes_941lp bllAdoptantes_941lp;

        ModoOperacion_941lp modo_941lp;
        public FormGestionAdoptantes_941lp()
        {
            InitializeComponent();
            bllAdoptantes_941lp = new bllAdoptantes_941lp();
            btnAplicar.Enabled = false;
            btnCancelar.Enabled = false;
            AplicarColorControles_941lp();
            modo_941lp = ModoOperacion_941lp.Consulta;
        }

        private void FormGestionAdoptantes_941lp_Load(object sender, EventArgs e)
        {
            dataAdoptantes.MultiSelect = false;
            dataAdoptantes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            modo_941lp = ModoOperacion_941lp.Consulta;
            MostrarGrillaAdoptantes_941lp(bllAdoptantes_941lp.RetornarAdoptantes_941lp());
            HabilitarTxt_941lp(true);
            TraductorSubject_941lp.Instancia_941lp.Suscribir_941lp(this);
            AplicarTraduccion_941lp();
        }


        enum ModoOperacion_941lp
        {
            Consulta,
            Alta,
            Modificar,
            ActivarDesactivar
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

        public void ActualizarTraduccion_941lp(string idioma_941lp)
        {
            AplicarTraduccion_941lp();
        }

        private void HabilitarTxt_941lp(bool habilitar_941lp)
        {
            if (modo_941lp == ModoOperacion_941lp.Alta)
            {
                txtDni.Enabled = habilitar_941lp;
                txtNombre.Enabled = habilitar_941lp;
                txtApellido.Enabled = habilitar_941lp;
                txtTelefono.Enabled = habilitar_941lp;
                txtEdad.Enabled = habilitar_941lp;
                txtDomicilio.Enabled = habilitar_941lp;
                comboBoxMascota.Enabled = habilitar_941lp;
                comboBoxActivo.Enabled = !habilitar_941lp;
            }
            else if (modo_941lp == ModoOperacion_941lp.Modificar)
            {
                txtDni.Enabled = !habilitar_941lp;
                txtNombre.Enabled = habilitar_941lp;
                txtApellido.Enabled = habilitar_941lp;
                txtEdad.Enabled = habilitar_941lp;
                txtTelefono.Enabled = habilitar_941lp;
                txtDomicilio.Enabled = habilitar_941lp;
                comboBoxMascota.Enabled = habilitar_941lp;
                comboBoxActivo.Enabled = !habilitar_941lp;
            }
            else
            {
                txtDni.Enabled = !habilitar_941lp;
                txtNombre.Enabled = !habilitar_941lp;
                txtApellido.Enabled = !habilitar_941lp;
                txtEdad.Enabled = !habilitar_941lp;
                txtTelefono.Enabled = !habilitar_941lp;
                txtDomicilio.Enabled = !habilitar_941lp;
                comboBoxMascota.Enabled = !habilitar_941lp;
                comboBoxActivo.Enabled = !habilitar_941lp;
            }
            AplicarColorControles_941lp();
        }

        private void MostrarGrillaAdoptantes_941lp(List<Adoptante_941lp> adoptantesLista_941lp)
        {
            dataAdoptantes.Rows.Clear();
            if (adoptantesLista_941lp != null)
            {
                foreach (Adoptante_941lp c_941lp in adoptantesLista_941lp)
                {
                    int intIndex_941lp = dataAdoptantes.Rows.Add(c_941lp.dni_941lp, c_941lp.nombre_941lp, c_941lp.apellido_941lp,  c_941lp.telefono_941lp, c_941lp.edad_941lp,c_941lp.domicilio_941lp, c_941lp.mascotas_941lp, c_941lp.activo_941lp);
                    if (c_941lp.activo_941lp == false)
                    {
                        dataAdoptantes.Rows[intIndex_941lp].DefaultCellStyle.BackColor = Color.Red;
                    }
                }
            }
        }

        private void VisibilidadDeBotones_941lp()
        {
            btnAlta.Enabled = false;
            btnModificar.Enabled = false;
            btnSalir.Enabled = false;
            btnActDesact.Enabled = false;
            btnCancelar.Enabled = true;
            btnAplicar.Enabled = true;
            AplicarColorControles_941lp();
        }

        private void ValidarCargaDeTxt_941lp()
        {
            if (string.IsNullOrWhiteSpace(txtDni.Text) ||
                        string.IsNullOrWhiteSpace(txtNombre.Text) ||
                        string.IsNullOrWhiteSpace(txtApellido.Text) ||
                        string.IsNullOrWhiteSpace(txtEdad.Text) ||
                        string.IsNullOrWhiteSpace(txtDomicilio.Text) ||
                        string.IsNullOrWhiteSpace(txtTelefono.Text) || 
                        comboBoxMascota.SelectedItem == null)
            {
                string exception_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGestionAdoptantes_941lp", "MSG_FALTA_COMPLETAR_CAMPOS", "Debe completar todos los campos obligatorios.");
                throw new Exception(exception_941lp);
            }
        }

        private void LimpiarTxt_941lp()
        {
            foreach (Control c_941lp in this.Controls)
            {
                if (c_941lp is TextBox t_941lp)
                {
                    t_941lp.Text = "";
                }
            }
        }

        private void ModoAceptarCancelar_941lp()
        {
            modo_941lp = ModoOperacion_941lp.Consulta;
            dataAdoptantes.MultiSelect = false;
            btnCancelar.Enabled = false;
            btnAplicar.Enabled = false;
            btnAlta.Enabled = true;
            btnActDesact.Enabled = true;
            btnModificar.Enabled = true;
            btnSalir.Enabled = true;
            AplicarColorControles_941lp();
            HabilitarTxt_941lp(true);
            LimpiarTxt_941lp();
        }

        private void AplicarColorControles_941lp()
        {
            var controles_941lp = new Control[]
            {
                btnActDesact, btnAlta, btnModificar, btnAplicar, btnCancelar, txtDni,
                txtNombre, txtApellido, txtEdad, txtTelefono, btnSalir, txtDomicilio, comboBoxActivo, comboBoxMascota
            };

            foreach (var control_941lp in controles_941lp)
            {
                if (control_941lp.Enabled == false)
                {

                    control_941lp.BackColor = Color.LightSteelBlue;
                }
                else
                {
                    control_941lp.BackColor = Color.White;
                }
            }
        }

        private void ControlDeIngresoDeDatos_941lp(string dni_941lp, string nombre_941lp, string apellido_941lp, string telefono_941lp, string edad_941lp)
        {
            try
            {
                var regexEdad_941lp = new Regex(@"^(?:[1-9]|[1-9][0-9])$");
                var regexTelefonoAR_941lp = new Regex(@"^(\+54|54)?\s?(9)?\s?(11|[2368]\d{2})\s?\d{3,4}[- ]?\d{4}$");
                var regexTexto_941lp = new Regex(@"^[A-Za-zÁÉÍÓÚáéíóúÑñÜü\s]+$");
                var regexDni = new Regex(@"^\d{8}$");
                // Validaciones
                if (!regexDni.IsMatch(dni_941lp))
                {
                    string exception_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGestionAdoptantes_941lp", "MSG_DNI_INVALIDO", "El DNI ingresado es inválido. Debe contener exactamente 8 dígitos y solo números.");
                    throw new ArgumentException(exception_941lp);
                }
                if (!regexTexto_941lp.IsMatch(nombre_941lp))
                {
                    string exception_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGestionAdoptantes_941lp", "MSG_NOMBRE_INVALIDO", "El nombre ingresado es inválido. Solo se permiten letras y espacios.");
                    throw new ArgumentException(exception_941lp);
                }
                if (!regexTexto_941lp.IsMatch(apellido_941lp))
                {
                    string exception_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGestionAdoptantes_941lp", "MSG_APELLIDO_INVALIDO", "El apellido ingresado es inválido. Solo se permiten letras y espacios.");
                    throw new ArgumentException(exception_941lp);
                }
                if (!regexTelefonoAR_941lp.IsMatch(telefono_941lp))
                {
                    string exception_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGestionAdoptantes_941lp", "MSG_TELEFONO_INVALIDO", "El telefono ingresado es inválido. Solo se permiten telefonos argentinos.");
                    throw new ArgumentException(exception_941lp);
                }
                if (!regexEdad_941lp.IsMatch(edad_941lp))
                {
                    string exception_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGestionAdoptantes_941lp", "MSG_EDAD_INVALIDA", "La edad ingresada es inválida. Debe ser un número entre 1 y 99 años.");
                    throw new ArgumentException(exception_941lp);
                }
            }
            catch (ArgumentException ex)
            {
                string exception_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGestionAdoptantes_941lp", "MSG_ERROR_VALIDACIÓN_UNO", $"Error de validación");
                throw new Exception($"{exception_941lp}: {ex.Message}");
            }
            catch (Exception ex)
            {
                string exception_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGestionAdoptantes_941lp", "MSG_ERROR_VALIDACIÓN", $"Ocurrió un error inesperado durante la validación de datos.");
                throw new Exception($"{exception_941lp}: {ex}");
            }
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            try
            {
                modo_941lp = ModoOperacion_941lp.Alta;
                VisibilidadDeBotones_941lp();
                HabilitarTxt_941lp(true);
                LimpiarTxt_941lp();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                modo_941lp = ModoOperacion_941lp.Modificar;
                CargarTxtConGrilla_941lp();
                VisibilidadDeBotones_941lp();
                HabilitarTxt_941lp(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargarTxtConGrilla_941lp()
        {
            if (modo_941lp != ModoOperacion_941lp.Alta)
            {
                txtDni.Text = dataAdoptantes.SelectedRows[0].Cells[0].Value.ToString();
                txtNombre.Text = dataAdoptantes.SelectedRows[0].Cells[1].Value.ToString();
                txtApellido.Text = dataAdoptantes.SelectedRows[0].Cells[2].Value.ToString();
                txtTelefono.Text = dataAdoptantes.SelectedRows[0].Cells[3].Value.ToString();
                txtEdad.Text = dataAdoptantes.SelectedRows[0].Cells[4].Value.ToString();
                txtDomicilio.Text = dataAdoptantes.SelectedRows[0].Cells[5].Value.ToString();
                comboBoxMascota.SelectedItem = dataAdoptantes.SelectedRows[0].Cells[6].Value.ToString() == "True" ? comboBoxMascota.SelectedIndex = 0 : comboBoxMascota.SelectedIndex = 1;
                comboBoxActivo.SelectedItem = dataAdoptantes.SelectedRows[0].Cells[7].Value.ToString() == "True" ? comboBoxActivo.SelectedIndex = 0 : comboBoxActivo.SelectedIndex = 1;
            }
        }

        private void btnActDesact_Click(object sender, EventArgs e)
        {
            try
            {
                modo_941lp = ModoOperacion_941lp.ActivarDesactivar;
                VisibilidadDeBotones_941lp();
                HabilitarTxt_941lp(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            modo_941lp = ModoOperacion_941lp.Consulta;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                ModoAceptarCancelar_941lp();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                switch (modo_941lp)
                {
                    case ModoOperacion_941lp.Consulta:
                        btnAplicar.Enabled = true;
                        break;
                    case ModoOperacion_941lp.Alta:
                        ValidarCargaDeTxt_941lp();
                        ControlDeIngresoDeDatos_941lp(txtDni.Text, txtNombre.Text, txtApellido.Text, txtTelefono.Text, txtEdad.Text);
                        string exception_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGestionAdoptantes_941lp", "MSG_DNI_REPETIDO", "DNI repetido");
                        if (bllAdoptantes_941lp.ValidarDNI_941lp(txtDni.Text)) { throw new Exception(exception_941lp); }
                        bllAdoptantes_941lp.Alta_941lp(txtDni.Text, txtNombre.Text, txtApellido.Text, txtTelefono.Text, Convert.ToInt32(txtEdad.Text),txtDomicilio.Text, comboBoxMascota.Text == "si" ? true : false);
                        string mensaje_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGestionAdoptantes_941lp", "MSG_ADOPTANTE_ALTA", "Adoptante dado de alta exitosamente");
                        MessageBox.Show(mensaje_941lp);
                        break;
                    case ModoOperacion_941lp.Modificar:
                        ValidarCargaDeTxt_941lp();
                        ControlDeIngresoDeDatos_941lp(txtDni.Text, txtNombre.Text, txtApellido.Text, txtTelefono.Text, txtEdad.Text);
                        bllAdoptantes_941lp.Modificar_941lp(txtDni.Text, txtNombre.Text, txtApellido.Text,  txtTelefono.Text, Convert.ToInt32(txtEdad.Text), txtDomicilio.Text, comboBoxMascota.Text == "si" ? true : false);
                        string mensaje1_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGestionAdoptantes_941lp", "MSG_ADOPTANTE_MODIFICADO", "Adoptante modificado exitosamente");
                        MessageBox.Show(mensaje1_941lp);
                        break;
                    case ModoOperacion_941lp.ActivarDesactivar:
                        bllAdoptantes_941lp.ActivarDesactivar_941lp(dataAdoptantes.SelectedRows[0].Cells[0].Value.ToString());
                        break;
                    default:
                        string error_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGestionAdoptantes_941lp", "MSG_ERROR", "Error en la operación");
                        MessageBox.Show(error_941lp);
                        break;
                }
                MostrarGrillaAdoptantes_941lp(bllAdoptantes_941lp.RetornarAdoptantes_941lp());
                ModoAceptarCancelar_941lp();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dataAdoptantes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CargarTxtConGrilla_941lp();
        }
    }
}
