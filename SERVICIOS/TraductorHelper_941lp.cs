using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SERVICIOS
{
    public class TraductorHelper_941lp
    {
        public static string TraducirMensaje_941lp(string formulario_941lp, string clave_941lp, string textoPorDefecto_941lp)
        {
            string idioma_941lp = sessionManager941lp.Gestor_941lp.Idioma_941lp;
            return TraductorSubject_941lp.Instancia_941lp.Traducir_941lp(formulario_941lp, clave_941lp, idioma_941lp, textoPorDefecto_941lp);
        }

        public static void TraducirControles_941lp(Control control_941lp, string nombreFormulario_941lp, string idioma_941lp)
        {
            foreach (Control c_941lp in control_941lp.Controls)
            {
                if (c_941lp is Label || c_941lp is Button || c_941lp is CheckBox || c_941lp is GroupBox || c_941lp is RadioButton)
                {
                    string textoTraducido_941lp = TraductorSubject_941lp.Instancia_941lp
                        .Traducir_941lp(nombreFormulario_941lp, c_941lp.Name, idioma_941lp, c_941lp.Text);
                    c_941lp.Text = textoTraducido_941lp;
                }
                else if (c_941lp is DataGridView dgv_941lp)
                {
                    foreach (DataGridViewColumn col_941lp in dgv_941lp.Columns)
                    {
                        string headerTraducido_941lp = TraductorSubject_941lp.Instancia_941lp
                            .Traducir_941lp(nombreFormulario_941lp, col_941lp.Name, idioma_941lp, col_941lp.HeaderText);
                        col_941lp.HeaderText = headerTraducido_941lp;
                    }
                }

                if (c_941lp.HasChildren)
                    TraducirControles_941lp(c_941lp, nombreFormulario_941lp, idioma_941lp);
            }
        }
    }
}
