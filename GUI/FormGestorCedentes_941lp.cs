using BE;
using BLL;
using SERVICIOS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace GUI
{
    public partial class FormGestorCedentes_941lp : Form, IObserver_941lp
    {

        bllCedente_941lp bllCedente_941lp;
        ModoOperacion_941lp modo_941lp;
        bllSerializacion_941lp bllSerializacion_941lp;
        public FormGestorCedentes_941lp()
        {
            InitializeComponent();
            bllCedente_941lp = new bllCedente_941lp();
            btnAplicar.Enabled = false;
            btnCancelar.Enabled = false;
            AplicarColorControles_941lp();
            modo_941lp = ModoOperacion_941lp.Consulta;
            bllSerializacion_941lp = new bllSerializacion_941lp();
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

        private void FormGestorCedentes_941lp_Load(object sender, EventArgs e)
        {
            dataCedentes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataCedentes.MultiSelect = false;
            dataCedentes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            modo_941lp = ModoOperacion_941lp.Consulta;
            MostrarGrillaCedentes_941lp(bllCedente_941lp.RetornarCedentes_941lp());
            HabilitarTxt_941lp(true);
            TraductorSubject_941lp.Instancia_941lp.Suscribir_941lp(this);
            AplicarTraduccion_941lp();
        }


        enum ModoOperacion_941lp
        {
            Consulta,
            Alta,
            Modificar,
            ActivarDesactivar,
            Serializar,
            Deserealizar
        }

        private void HabilitarTxt_941lp(bool habilitar_941lp)
        {
            if (modo_941lp == ModoOperacion_941lp.Alta)
            {
                txtDni.Enabled = habilitar_941lp;
                txtNOmbreCedente.Enabled = habilitar_941lp;
                txtApellido.Enabled = habilitar_941lp;
                txtDireccion.Enabled = habilitar_941lp;
                txtTelefono.Enabled = habilitar_941lp;
            }
            else if (modo_941lp == ModoOperacion_941lp.Modificar)
            {
                txtDni.Enabled = !habilitar_941lp;
                txtNOmbreCedente.Enabled = habilitar_941lp;
                txtApellido.Enabled = habilitar_941lp;
                txtDireccion.Enabled = habilitar_941lp;
                txtTelefono.Enabled = habilitar_941lp;
            }
            else
            {
                txtDni.Enabled = !habilitar_941lp;
                txtNOmbreCedente.Enabled = !habilitar_941lp;
                txtApellido.Enabled = !habilitar_941lp;
                txtDireccion.Enabled = !habilitar_941lp;
                txtTelefono.Enabled = !habilitar_941lp;
            }
            AplicarColorControles_941lp();
        }

        private void MostrarGrillaCedentes_941lp(List<Cedente_941lp> cedentesLista_941lp)
        {
            dataCedentes.Rows.Clear();
            if(cedentesLista_941lp!=null)
            {
                foreach (Cedente_941lp c_941lp in cedentesLista_941lp)
                {
                    int intIndex_941lp = dataCedentes.Rows.Add(c_941lp.dni_941lp, c_941lp.nombre_941lp, c_941lp.apellido_941lp,  c_941lp.direccion_941lp, c_941lp.telefono_941lp, c_941lp.activo_941lp);
                    if(c_941lp.activo_941lp==false)
                    {
                        dataCedentes.Rows[intIndex_941lp].DefaultCellStyle.BackColor = Color.Red;
                    }
                }
            }
        }

        private void VisibilidadDeBotones_941lp()
        {
            btnAltaCedente.Enabled = false;
            btnModificarCedente.Enabled = false;
            btnSalir.Enabled = false;
            btnActDesact.Enabled = false;
            btnSerializar.Enabled = false;
            btnDesarializar.Enabled = false;
            btnCancelar.Enabled = true;
            btnAplicar.Enabled = true;
            AplicarColorControles_941lp();
        }

        private void ValidarCargaDeTxt_941lp()
        {
            if (string.IsNullOrWhiteSpace(txtDni.Text) ||
                        string.IsNullOrWhiteSpace(txtNOmbreCedente.Text) ||
                        string.IsNullOrWhiteSpace(txtApellido.Text) ||
                        string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                        string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                string exception_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGestorCedentes_941lp", "MSG_FALTA_COMPLETAR_CAMPOS", "Debe completar todos los campos obligatorios.");
                throw new Exception(exception_941lp);
            }
        }

        private void LimpiarTxt_941lp()
        {
            foreach (Control c_941lp in this.Controls)
            {
                if (c_941lp is TextBox t_941lp && c_941lp.Name != "txtSerializar")
                {
                    t_941lp.Text = "";
                }
            }
        }

        private void ModoAceptarCancelar_941lp()
        {
            modo_941lp = ModoOperacion_941lp.Consulta;
            dataCedentes.MultiSelect = false;
            btnCancelar.Enabled = false;
            btnAplicar.Enabled = false;
            btnAltaCedente.Enabled = true;
            btnActDesact.Enabled = true;
            btnModificarCedente.Enabled = true;
            btnSalir.Enabled = true;
            btnSerializar.Enabled = true;
            btnDesarializar.Enabled = true;
            AplicarColorControles_941lp();
            HabilitarTxt_941lp(true);
            LimpiarTxt_941lp();
        }

        private void AplicarColorControles_941lp()
        {
            var controles_941lp = new Control[]
            {
                btnActDesact, btnAltaCedente, btnModificarCedente, btnAplicar, btnCancelar, txtDni,
                txtNOmbreCedente, txtApellido, txtDireccion, txtTelefono, btnSalir, btnSerializar, btnDesarializar
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

        private void ControlDeIngresoDeDatos_941lp(string dni_941lp, string nombre_941lp, string apellido_941lp, string direccion_941lp, string telefono_941lp)
        {
            try
            {
                var regexDireccion_941lp = new Regex(@"^[\p{L}\d\s\.,°#\-]+$");
                
                var regexTelefonoAR_941lp = new Regex(@"^(\+54|54)?\s?(9)?\s?(11|[2368]\d{2})\s?\d{3,4}[- ]?\d{4}$");
                var regexTexto_941lp = new Regex(@"^[A-Za-zÁÉÍÓÚáéíóúÑñÜü\s]+$");
                var regexDni = new Regex(@"^\d{8}$");
                // Validaciones
                if (!regexDni.IsMatch(dni_941lp))
                {
                    string exception_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGestorCedentes_941lp", "MSG_DNI_INVALIDO", "El DNI ingresado es inválido. Debe contener exactamente 8 dígitos y solo números.");
                    throw new ArgumentException(exception_941lp);
                }
                if (!regexTexto_941lp.IsMatch(nombre_941lp))
                {
                    string exception_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGestorCedentes_941lp", "MSG_NOMBRE_INVALIDO", "El nombre ingresado es inválido. Solo se permiten letras y espacios.");
                    throw new ArgumentException(exception_941lp);
                }
                if (!regexTexto_941lp.IsMatch(apellido_941lp))
                {
                    string exception_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGestorCedentes_941lp", "MSG_APELLIDO_INVALIDO", "El apellido ingresado es inválido. Solo se permiten letras y espacios.");
                    throw new ArgumentException(exception_941lp);
                }
                if (!regexDireccion_941lp.IsMatch(direccion_941lp))
                {
                    string exception_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGestorCedentes_941lp", "MSG_DIRECCION_INVALIDA", "La dirección ingresada es inválida.");
                    throw new ArgumentException(exception_941lp);
                }
                if (!regexTelefonoAR_941lp.IsMatch(telefono_941lp))
                {
                    string exception_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGestorCedentes_941lp", "MSG_TELEFONO_INVALIDO", "El telefono ingresado es inválido. Solo se permiten telefonos argentinos.");
                    throw new ArgumentException(exception_941lp);
                }
            }
            catch (ArgumentException ex)
            {
                string exception_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGestorCedentes_941lp", "MSG_ERROR_VALIDACIÓN_UNO", $"Error de validación");
                throw new Exception($"{ exception_941lp}: {ex.Message}");
            }
            catch (Exception ex)
            {
                string exception_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGestorCedentes_941lp", "MSG_ERROR_VALIDACIÓN", $"Ocurrió un error inesperado durante la validación de datos.");
                throw new Exception($"{exception_941lp}: {ex}");
            }
        }

        private void btnAltaCedente_Click(object sender, EventArgs e)
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

        private void btnModificarCedente_Click(object sender, EventArgs e)
        {
            try
            {
                if(dataCedentes.Rows.Count > 0)
                {
                    modo_941lp = ModoOperacion_941lp.Modificar;
                    CargarTxtConGrilla_941lp();
                    VisibilidadDeBotones_941lp();
                    HabilitarTxt_941lp(true);
                }
                else
                {
                    throw new Exception("No hay cedentes");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnActDesact_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataCedentes.Rows.Count > 0)
                {
                    modo_941lp = ModoOperacion_941lp.ActivarDesactivar;
                    VisibilidadDeBotones_941lp();
                    HabilitarTxt_941lp(true);
                }
                else
                {
                    throw new Exception("No hay cedentes");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
                modo_941lp = ModoOperacion_941lp.Consulta;
                this.Close();
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            try
            {
                ModoAceptarCancelar_941lp();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnAplicar_Click_1(object sender, EventArgs e)
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
                        ControlDeIngresoDeDatos_941lp(txtDni.Text, txtNOmbreCedente.Text, txtApellido.Text, txtDireccion.Text, txtTelefono.Text);
                        string exception_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGestorCedentes_941lp", "MSG_DNI_REPETIDO", "DNI repetido");
                        if (bllCedente_941lp.ValidarDNI_941lp(txtDni.Text)) { throw new Exception(exception_941lp); }
                        bllCedente_941lp.Alta_941lp(txtDni.Text, txtNOmbreCedente.Text, txtApellido.Text, txtDireccion.Text, txtTelefono.Text);
                        string mensaje_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGestorCedentes_941lp", "MSG_CEDENTE_ALTA", "Cedente dado de alta exitosamente");
                        MessageBox.Show(mensaje_941lp);
                        break;
                    case ModoOperacion_941lp.Modificar:
                        ValidarCargaDeTxt_941lp();
                        ControlDeIngresoDeDatos_941lp(txtDni.Text, txtNOmbreCedente.Text, txtApellido.Text, txtDireccion.Text, txtTelefono.Text);
                        bllCedente_941lp.Modificar_941lp(txtDni.Text, txtNOmbreCedente.Text, txtApellido.Text, txtDireccion.Text, txtTelefono.Text);
                        string mensaje1_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGestorCedentes_941lp", "MSG_CEDENTE_MODIFICADO", "Cedente modificado exitosamente");
                        MessageBox.Show(mensaje1_941lp);
                        break;
                    case ModoOperacion_941lp.ActivarDesactivar:
                        bllCedente_941lp.ActivarDesactivar_941lp(dataCedentes.SelectedRows[0].Cells[0].Value.ToString());
                        break;
                    case ModoOperacion_941lp.Serializar:
                        if (dataCedentes.SelectedRows.Count == 0) throw new Exception("No hay ningun usuario seleccionado");
                        Serializar_941lp();
                        break;
                    default:
                        string error_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGestorCedentes_941lp", "MSG_ERROR", "Error en la operación");
                        MessageBox.Show(error_941lp);
                        break;
                }
                MostrarGrillaCedentes_941lp(bllCedente_941lp.RetornarCedentes_941lp());
                ModoAceptarCancelar_941lp();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void CargarTxtConGrilla_941lp()
        {
             if (modo_941lp != ModoOperacion_941lp.Alta && dataCedentes.SelectedRows.Count > 0)
             {
                txtDni.Text = dataCedentes.SelectedRows[0].Cells[0].Value.ToString();
                txtNOmbreCedente.Text = dataCedentes.SelectedRows[0].Cells[1].Value.ToString();
                txtApellido.Text = dataCedentes.SelectedRows[0].Cells[2].Value.ToString();
                Desencriptar_941lp();
                txtTelefono.Text = dataCedentes.SelectedRows[0].Cells[4].Value.ToString();
             }
        }

        private void checkBoxDesencriptar_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if(modo_941lp != ModoOperacion_941lp.Alta)
                {
                    Desencriptar_941lp();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Desencriptar_941lp()
        {
            if (checkBoxDesencriptar.Checked)
            {
                txtDireccion.Text = bllCedente_941lp.DireccionDesencriptada(dataCedentes.SelectedRows[0].Cells[3].Value.ToString());
            }
            else
            {
                txtDireccion.Text = dataCedentes.SelectedRows[0].Cells[3].Value.ToString();
            }
        }

        public void ActualizarTraduccion_941lp(string idioma_941lp)
        {
            AplicarTraduccion_941lp();
        }

        private void btnSerializar_Click(object sender, EventArgs e)
        {
            try
            {
                modo_941lp = ModoOperacion_941lp.Serializar;
                dataCedentes.MultiSelect = true;
                dataCedentes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                VisibilidadDeBotones_941lp();
                HabilitarTxt_941lp(true);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Serializar_941lp()
        {
            try
            {
                saveFileDialogSerializacion.Filter = "XML Files|*.xml";
                if (saveFileDialogSerializacion.ShowDialog() == DialogResult.OK)
                {
                    List<Cedente_941lp> cedentesSeleccionados_941lp = new List<Cedente_941lp>();

                    foreach (DataGridViewRow row_941lp in dataCedentes.SelectedRows)
                    {
                        Cedente_941lp cedente_941lp = new Cedente_941lp()
                        {
                            dni_941lp = row_941lp.Cells[0].Value.ToString(),
                            nombre_941lp = row_941lp.Cells[1].Value.ToString(),
                            apellido_941lp = row_941lp.Cells[2].Value.ToString(),
                            direccion_941lp = row_941lp.Cells[3].Value.ToString(),
                            telefono_941lp = row_941lp.Cells[4].Value.ToString(),
                            activo_941lp = Convert.ToBoolean(row_941lp.Cells[5].Value)
                        };
                        cedentesSeleccionados_941lp.Add(cedente_941lp);
                    }

                    if (!saveFileDialogSerializacion.FileName.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
                    {
                        saveFileDialogSerializacion.FileName += ".xml";
                    }

                    bllSerializacion_941lp.SerializarCedentes_941lp(cedentesSeleccionados_941lp, saveFileDialogSerializacion.FileName);

                    string mensaje_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGestorCedentes_941lp", "MSG_CEDENTES_SERIALIZADOS", "Cedentes serializados correctamente.");
                    MessageBox.Show(mensaje_941lp);

                    txtSerializar.Text = bllSerializacion_941lp.ObtenerXmlCrudo_941lp(saveFileDialogSerializacion.FileName);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dataCedentes_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                CargarTxtConGrilla_941lp();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnDesarializar_Click(object sender, EventArgs e)
        {
            try
            {
                modo_941lp = ModoOperacion_941lp.Deserealizar;
                btnAltaCedente.Enabled = false;
                btnModificarCedente.Enabled = false;
                btnSalir.Enabled = false;
                btnActDesact.Enabled = false;
                btnSerializar.Enabled = false;
                btnDesarializar.Enabled = false;
                btnCancelar.Enabled = false;
                btnAplicar.Enabled = false;
                HabilitarTxt_941lp(true);
                LimpiarTxt_941lp();
                AplicarColorControles_941lp();
                using (OpenFileDialog ofd_941lp = new OpenFileDialog())
                {
                    ofd_941lp.Filter = "Archivos XML (*.xml)|*.xml|Todos los archivos (*.*)|*.*";
                    string titulo_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGestorCedentes_941lp", "MSG_TITULO", "Seleccione un archivo de Cedentes");
                    ofd_941lp.Title = titulo_941lp;

                    if (ofd_941lp.ShowDialog() == DialogResult.OK)
                    {
                        string ruta_941lp = ofd_941lp.FileName;

                        // Intento de deserialización
                        MostrarGrillaCedentes_941lp(bllSerializacion_941lp.MostrarCedentesDeserealizados_941lp(ruta_941lp));
                        string mensaje_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGestorCedentes_941lp", "MSG_ARCHIVO_SERIALIZADO", "Archivo cargado correctamente");
                        string mensaje1_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGestorCedentes_941lp", "MSG_ARCHIVO_SERIALIZADO_EXITO", "Éxito");
                        MessageBox.Show(mensaje_941lp, mensaje1_941lp, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                txtSerializar.Clear();
            }
            catch (Exception ex)
            {
                string mensaje_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGestorCedentes_941lp", "MSG_ARCHIVO_SERIALIZADO_ERROR", "No se pudo deserializar el archivo. Detalles");
                string mensaje1_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGestorCedentes_941lp", "MSG_ERROR1", "Error");
                MessageBox.Show($"{mensaje_941lp}: {ex.Message}",
                                mensaje1_941lp, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            MostrarGrillaCedentes_941lp(bllCedente_941lp.RetornarCedentes_941lp());
            modo_941lp = ModoOperacion_941lp.Consulta;
            ModoAceptarCancelar_941lp();
        }
    }
}
