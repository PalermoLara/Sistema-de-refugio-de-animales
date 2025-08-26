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
    public partial class formBitacoraEventos_941lp : Form
    {
        bllBitacoraEventos_941lp bllBitacora_941lp;
        bllUsuario_941lp bllUsuario_941lp;
        public formBitacoraEventos_941lp()
        {
            InitializeComponent();
            dataEventos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataEventos.MultiSelect = false;
            dataEventos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            bllBitacora_941lp = new bllBitacoraEventos_941lp();
            bllUsuario_941lp = new bllUsuario_941lp();
            MostrarEventos_941lp(bllBitacora_941lp.RetornarEventos_941lp());
            LlenarComboBox_941lp(bllBitacora_941lp.RetornarEventos_941lp(), comboBoxLogin, e=> e.login_941lp);
            LlenarComboBox_941lp(bllBitacora_941lp.RetornarEventos_941lp(), comboBoxEvento, e => e.evento_941lp);
            LlenarComboBox_941lp(bllBitacora_941lp.RetornarEventos_941lp(), comboBoxModulo, e => e.modulo_941lp);
            LlenarComboBox_941lp(bllBitacora_941lp.RetornarEventos_941lp(), comboBoxCriticidad, e => e.criticidad_941lp);
            if (!checkBoxFiltro.Checked)
            {
                dateTimePickerInicio.Enabled = false;
                dateTimePickerFin.Enabled = false;
            }
            else
            {
                dateTimePickerInicio.Enabled = true;
                dateTimePickerFin.Enabled = true;
            }
        }

        private void MostrarEventos_941lp(List<Evento_941lp> eventosLista_941lp)
        {
            dataEventos.Rows.Clear();
            if (eventosLista_941lp != null)
            {
                DateTime fechaLimite_941lp = DateTime.Today.AddDays(-3);
                foreach (Evento_941lp e_941lp in eventosLista_941lp)
                {
                    // Verificar si la fecha del evento es mayor o igual a la fecha límite
                    if (e_941lp.fecha_941lp >= fechaLimite_941lp)
                    {
                        dataEventos.Rows.Add(e_941lp.login_941lp,e_941lp.fecha_941lp.ToString("dd/MM/yyyy"),e_941lp.hora_941lp.ToString(@"hh\:mm\:ss"),e_941lp.modulo_941lp,e_941lp.evento_941lp,e_941lp.criticidad_941lp);
                    }
                }
            }
        }

        private void MostrarFiltros_941lp(List<Evento_941lp> eventosLista_941lp)
        {
            dataEventos.Rows.Clear();
            if (eventosLista_941lp != null)
            {
                foreach (Evento_941lp e_941lp in eventosLista_941lp)
                {
                    dataEventos.Rows.Add(e_941lp.login_941lp, e_941lp.fecha_941lp.ToString("dd/MM/yyyy"), e_941lp.hora_941lp.ToString(@"hh\:mm\:ss"), e_941lp.modulo_941lp, e_941lp.evento_941lp, e_941lp.criticidad_941lp);
                }
            }
        }

        private void LlenarComboBox_941lp<T>(List<Evento_941lp> valores_941lp,ComboBox combo_941lp, Func<Evento_941lp, T> selector)
        {
            combo_941lp.Items.Clear();
            //distinc quita duplicados
            var listaValores = valores_941lp.Select(selector).Distinct().ToList();
            foreach (var valor in listaValores)
            {
                combo_941lp.Items.Add(valor);
            }
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formBitacoraEventos_941lp_Load(object sender, EventArgs e)
        {
            MostrarEventos_941lp(bllBitacora_941lp.RetornarEventos_941lp());
            LlenarComboBox_941lp(bllBitacora_941lp.RetornarEventos_941lp(), comboBoxLogin, a => a.login_941lp);
            LlenarComboBox_941lp(bllBitacora_941lp.RetornarEventos_941lp(), comboBoxEvento, a => a.evento_941lp);
            LlenarComboBox_941lp(bllBitacora_941lp.RetornarEventos_941lp(), comboBoxModulo, a => a.modulo_941lp);
            LlenarComboBox_941lp(bllBitacora_941lp.RetornarEventos_941lp(), comboBoxCriticidad, a => a.criticidad_941lp);
        }

        private void dataEventos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Usuario_941lp u_941lp = bllUsuario_941lp.RetornarUsuarios_941lp().Find(x => x.nombreUsuario_941lp == dataEventos.SelectedRows[0].Cells[0].Value.ToString());
                txtNombre.Text = u_941lp.nombre_941lp;
                txtApellido.Text = u_941lp.apellido_941lp;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                Dictionary<string, string> filtros_941lp = new Dictionary<string, string>();
                if(comboBoxLogin.SelectedItem != null)
                {
                    filtros_941lp.Add("login_941lp", comboBoxLogin.SelectedItem.ToString());
                }
                if (comboBoxEvento.SelectedItem != null)
                {
                    filtros_941lp.Add("evento_941lp", comboBoxEvento.SelectedItem.ToString());
                }
                if (comboBoxModulo.SelectedItem != null)
                {
                    filtros_941lp.Add("modulo_941lp", comboBoxModulo.SelectedItem.ToString());
                }
                if (comboBoxCriticidad.SelectedItem != null)
                {
                    filtros_941lp.Add("criticidad_941lp", comboBoxCriticidad.SelectedItem.ToString());
                }
                if (checkBoxFiltro.Checked) 
                {
                    if (dateTimePickerInicio.Value.Date < dateTimePickerFin.Value.Date)
                    {
                        filtros_941lp.Add("fechaInicio_941lp", dateTimePickerInicio.Value.Date.ToString());
                        filtros_941lp.Add("fechaFin_941lp", dateTimePickerFin.Value.Date.ToString());
                    }
                    else
                    {
                        throw new Exception("La fecha de inicio no puede ser mayor a la de fin");
                    }
                }
                MostrarFiltros_941lp(bllBitacora_941lp.Filtros_941lp(filtros_941lp));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                foreach(var c_941lp in this.Controls)
                {
                    if(c_941lp is ComboBox combo_941lp)
                    {
                    combo_941lp.SelectedItem = null;
                    }
                }
                MostrarEventos_941lp(bllBitacora_941lp.RetornarEventos_941lp());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void rbFiltroFechas_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBoxFiltro_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxFiltro.Checked)
            {
                dateTimePickerInicio.Enabled = false;
                dateTimePickerFin.Enabled = false;
            }
            else
            {
                dateTimePickerInicio.Enabled = true;
                dateTimePickerFin.Enabled = true;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //string mensaje_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("formBitacoraEventos_941lp", "MSG_IMPRESO_EXITO", "La bitacora fue impresa con éxito");
            MessageBox.Show("La bitacora fue impresa con éxito");
        }
    }
}
