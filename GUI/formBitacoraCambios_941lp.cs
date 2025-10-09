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
    public partial class formBitacoraCambios_941lp : Form, IObserver_941lp
    {
        bllBitacoraCambios_941lp bllBitacoraCambios_941lp;
        bllDigitoVerificador_941lp bllDigitoVerificador_941Lp;

        public formBitacoraCambios_941lp()
        {
            InitializeComponent();
            bllBitacoraCambios_941lp = new bllBitacoraCambios_941lp();
            bllDigitoVerificador_941Lp = new bllDigitoVerificador_941lp();
            dataCambios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataCambios.MultiSelect = false;
            dataCambios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            MostrarCambios_941lp(bllBitacoraCambios_941lp.RetornarCambios_941lp());
            LlenarComboBox_941lp(bllBitacoraCambios_941lp.RetornarCambios_941lp(), comboBoxCodigo, e => e.codMedicamento_941lp);
            LlenarComboBox_941lp(bllBitacoraCambios_941lp.RetornarCambios_941lp(), comboBoxComercial, e => e.nombreComercial_941lp);
        }

        private void LlenarComboBox_941lp<T>(List<BitacoraCambio_941lp> valores_941lp, ComboBox combo_941lp, Func<BitacoraCambio_941lp, T> selector)
        {
            combo_941lp.Items.Clear();
            //distinc quita duplicados
            var listaValores = valores_941lp.Select(selector).Distinct().ToList();
            foreach (var valor in listaValores)
            {
                combo_941lp.Items.Add(valor);
            }
        }

        private void MostrarCambios_941lp(List<BitacoraCambio_941lp> cambios_941lp)
        {
            dataCambios.Rows.Clear();
            if (cambios_941lp != null)
            {
                foreach (BitacoraCambio_941lp e_941lp in cambios_941lp)
                {
                    dataCambios.Rows.Add(e_941lp.codMedicamento_941lp,e_941lp.fechaHora_941lp.ToString("dd/MM/yyyy"), e_941lp.fechaHora_941lp.ToString("HH:mm:ss"), e_941lp.nombreComercial_941lp, e_941lp.nombreGenerico_941lp, e_941lp.forma_941lp, e_941lp.caducidad_941lp.ToString("dd/MM/yyyy"),e_941lp.activoMedicamento_941lp, e_941lp.activo_941lp);
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BitacoraCambios_941lp_Load(object sender, EventArgs e)
        {
            TraductorSubject_941lp.Instancia_941lp.Suscribir_941lp(this);
            AplicarTraduccion_941lp();
            MostrarCambios_941lp(bllBitacoraCambios_941lp.RetornarCambios_941lp());
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataCambios.SelectedRows.Count == 0)
                {
                    string mensaje4_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("formBitacoraCambios_941lp", "MSG_NADA_SELECCIONADO", "Seleccione una versión a restaurar.");
                    MessageBox.Show(mensaje4_941lp);
                    return;
                }

                string codigo = dataCambios.SelectedRows[0].Cells[0].Value.ToString();
                DateTime fecha = Convert.ToDateTime(dataCambios.SelectedRows[0].Cells[1].Value);
                DateTime hora = Convert.ToDateTime(dataCambios.SelectedRows[0].Cells[2].Value);

                DateTime fechaSeleccionada = fecha.Date.Add(hora.TimeOfDay);

                bllBitacoraCambios_941lp.RollbackMedicamento_941lp(codigo, fechaSeleccionada);
                bllDigitoVerificador_941Lp.CalcularDVMedicamentos_941lp();
                MostrarCambios_941lp(bllBitacoraCambios_941lp.RetornarCambios_941lp());
            }
            catch (Exception ex)
            {
                string mensaje4_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("formBitacoraCambios_941lp", "MSG_ERROR_ROLLBACK", "Error al realizar rollback: ");
                MessageBox.Show(mensaje4_941lp + ex.Message);
            }
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                Dictionary<string, object> filtros_941lp = new Dictionary<string, object>();

                if (comboBoxCodigo.SelectedItem != null)
                    filtros_941lp.Add("codMedicamento_941lp", comboBoxCodigo.SelectedItem.ToString());

                if (comboBoxComercial.SelectedItem != null)
                    filtros_941lp.Add("nombreComercial_941lp", comboBoxComercial.SelectedItem.ToString());

                if (dateTimePickerInicio.Value.Date <= dateTimePickerFin.Value.Date)
                {
                    filtros_941lp.Add("fechaInicio_941lp", dateTimePickerInicio.Value.Date);
                    filtros_941lp.Add("fechaFin_941lp", dateTimePickerFin.Value.Date);
                }
                else
                {
                    dateTimePickerInicio.Value = DateTime.Today;
                    dateTimePickerFin.Value = DateTime.Today;
                    MostrarCambios_941lp(bllBitacoraCambios_941lp.RetornarCambios_941lp());
                    btnLimpiar_Click(null, null);
                    string mensaje4_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("formBitacoraCambios_941lp", "MSG_FECHA_ERROR", "La fecha de inicio no puede ser mayor a la de fin");
                    throw new Exception(mensaje4_941lp);
                }
                MostrarCambios_941lp(bllBitacoraCambios_941lp.Filtros_941lp(filtros_941lp));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var c_941lp in this.Controls)
                {
                    if (c_941lp is ComboBox combo_941lp)
                    {
                        combo_941lp.SelectedItem = null;
                    }
                }
                dateTimePickerInicio.Value = DateTime.Today;
                dateTimePickerFin.Value = DateTime.Today;
                MostrarCambios_941lp(bllBitacoraCambios_941lp.RetornarCambios_941lp());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public void ActualizarTraduccion_941lp(string idioma_941lp)
        {
            AplicarTraduccion_941lp();
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
    }
}
