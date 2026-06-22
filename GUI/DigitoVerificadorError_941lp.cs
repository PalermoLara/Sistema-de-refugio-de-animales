using BLL;
using SERVICIOS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class formDigitoVerificadorError_941lp : Form
    {
        bllDigitoVerificador_941lp bllDigitoVerificador_941Lp;
        bllBackUp_Restore_941lp bllBackUpRestore_941lp;

        public formDigitoVerificadorError_941lp()
        {
            InitializeComponent();
            bllDigitoVerificador_941Lp = new bllDigitoVerificador_941lp();
            bllBackUpRestore_941lp = new bllBackUp_Restore_941lp();
            
        }

        private void btnRecalcular_Click(object sender, EventArgs e)
        {
            try
            {
                bllDigitoVerificador_941Lp.CalcularDVFichaMedica_941lp();
                bllDigitoVerificador_941Lp.CalcularDVFichaIngreso_941lp();
                bllDigitoVerificador_941Lp.CalcularDVEvaluaciones_941lp();
                bllDigitoVerificador_941Lp.CalcularDVCertificadoAdopcion_941lp();
                bllDigitoVerificador_941Lp.CalcularDVCedente_941lp();
                bllDigitoVerificador_941Lp.CalcularDVAnimales_941lp();
                bllDigitoVerificador_941Lp.CalcularDVAdoptante_941lp();
                bllDigitoVerificador_941Lp.CalcularDVMedicamentos_941lp();
                sessionManager941lp.Gestor_941lp.UnsetUsuario_941lp();
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnSalir_941lp_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnRestore_941lp_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog fd_941lp = new OpenFileDialog())
                {
                    fd_941lp.Filter = "SQL Backup Files (*.bak)|*.bak";
                    fd_941lp.InitialDirectory = @"C:\BackUp";

                    if (fd_941lp.ShowDialog() == DialogResult.OK)
                    {
                        // Realizar el restore directamente con el archivo seleccionado
                        bllBackUpRestore_941lp.RealizarRestore(fd_941lp.FileName);
                    }
                    else
                    {
                        // El usuario canceló la selección
                        string mensajeCancel_941lp = TraductorHelper_941lp.TraducirMensaje_941lp(
                            "FormBackUpRestore_941lp", "MSG_CANCEL", "Operación cancelada por el usuario");
                        MessageBox.Show(mensajeCancel_941lp);
                    }
                }
                sessionManager941lp.Gestor_941lp.UnsetUsuario_941lp();
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void formDigitoVerificadorError_941lp_Load(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            foreach(var s_941lp in bllDigitoVerificador_941Lp.MostrarInconsistencias_941lp())
            {
                richTextBox1.Text += $"{s_941lp}\n";
            }
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            string url = "https://docs.google.com/document/d/1j5AR3nS1CD2I-xyaW_7rPCf6-4WdFzHvhaq5q_U_rDQ/edit?tab=t.0#heading=h.8vhwz41thdg7";
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }
    }
}
