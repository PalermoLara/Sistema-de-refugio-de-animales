using BLL;
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
    public partial class FormBackUpRestore_941lp : Form
    {
        bllBackUp_Restore_941lp bllBackUpRestore_941lp;
        public FormBackUpRestore_941lp()
        {
            InitializeComponent();
            bllBackUpRestore_941lp = new bllBackUp_Restore_941lp();
        }

        private void buttonBackUpCarpeta_Click(object sender, EventArgs e)
        {

        }

        private void btnRealizarBackUp_941lp_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show($"Back up creado con éxito en la ruta {bllBackUpRestore_941lp.Backup_941lp()}");
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
                    MessageBox.Show("Restauración realizada con éxito.");
                    txtRestore_941lp.Text = "";
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un archivo primero");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
