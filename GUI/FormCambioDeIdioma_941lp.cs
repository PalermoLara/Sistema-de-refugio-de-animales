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
    public partial class FormCambioDeIdioma_941lp : Form, IObserver_941lp
    {
        public FormCambioDeIdioma_941lp()
        {
            InitializeComponent();
            
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

        private void comboBoxIdiomas_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                string nuevoIdioma = comboBoxIdiomas.SelectedItem.ToString();
                sessionManager941lp.Gestor_941lp.Idioma_941lp = nuevoIdioma;
                TraductorSubject_941lp.Instancia_941lp.Notificar_941lp(nuevoIdioma);
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void FormCambioDeIdioma_941lp_Load(object sender, EventArgs e)
        {
            TraductorSubject_941lp.Instancia_941lp.Suscribir_941lp(this);
            AplicarTraduccion_941lp();
            comboBoxIdiomas.SelectedIndex = 0;
        }

        public void ActualizarTraduccion_941lp(string idioma_941lp)
        {
            AplicarTraduccion_941lp();
        }
    }
}
