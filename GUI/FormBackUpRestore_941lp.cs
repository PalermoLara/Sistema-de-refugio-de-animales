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
    public partial class FormBackUpRestore_941lp : Form, IObserver_941lp
    {
        bllBackUp_Restore_941lp bllBackUpRestore_941lp;
        public FormBackUpRestore_941lp()
        {
            InitializeComponent();
            bllBackUpRestore_941lp = new bllBackUp_Restore_941lp();
        }

        private void FormBackUpRestore_941lp_Load(object sender, EventArgs e)
        {
            TraductorSubject_941lp.Instancia_941lp.Suscribir_941lp(this);
            AplicarTraduccion_941lp();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            TraductorSubject_941lp.Instancia_941lp.Desuscribir_941lp(this);
            base.OnFormClosed(e);
        }

        private void AplicarTraduccion_941lp()
        {
            string idioma_941LP = sessionManager941lp.Gestor_941lp.Idioma_941lp;
            RecorrerControlesParaTraducir_941lp.TraducirControles_941lp(this, this.Name, idioma_941LP);
        }

        private void btnRealizarBackUp_941lp_Click(object sender, EventArgs e)
        {
            try
            {
                string mensaje_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormBackUpRestore_941lp", "MSG_BACKUP_EXITOSO", "Back up creado con éxito en la ruta");
                MessageBox.Show($"{mensaje_941lp}: { bllBackUpRestore_941lp.Backup_941lp()}");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void buttonRestoreCarpeta_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog fd_941lp = new OpenFileDialog())
                {
                    fd_941lp.Filter = "SQL Backup Files (*.bak)|*.bak";
                    fd_941lp.InitialDirectory = @"C:\BackUp";

                    if (fd_941lp.ShowDialog() == DialogResult.OK)
                    {
                        txtRestore_941lp.Text = fd_941lp.FileName;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnRealizarRestore_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtRestore_941lp.Text))
                {
                    bllBackUpRestore_941lp.RealizarRestore(txtRestore_941lp.Text);
                    string mensaje_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormBackUpRestore_941lp", "MSG_RESTORE_EXITOSO", "Restauración realizada con éxito.");
                    MessageBox.Show(mensaje_941lp);
                    txtRestore_941lp.Text = "";
                }
                else
                {
                    string mensaje_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormBackUpRestore_941lp", "MSG_ERROR", "Debe seleccionar un archivo primero");
                    MessageBox.Show(mensaje_941lp);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ActualizarTraduccion_941lp(string idioma_941lp)
        {
            AplicarTraduccion_941lp();
        }

        
    }
}
