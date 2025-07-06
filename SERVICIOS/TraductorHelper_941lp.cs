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
        public static string TraducirMensaje_941lp(string formulario, string clave, string textoPorDefecto)
        {
            string idioma = sessionManager941lp.Gestor_941lp.Idioma_941lp;
            return TraductorSubject_941lp.Instancia_941lp.Traducir_941lp(formulario, clave, idioma, textoPorDefecto);
        }

        public static void TraducirControles_941lp(Control control, string nombreFormulario, string idioma)
        {
            foreach (Control c in control.Controls)
            {
                if (c is Label || c is Button || c is CheckBox || c is GroupBox || c is RadioButton)
                {
                    string textoTraducido = TraductorSubject_941lp.Instancia_941lp
                        .Traducir_941lp(nombreFormulario, c.Name, idioma, c.Text);
                    c.Text = textoTraducido;
                }
                else if (c is DataGridView dgv)
                {
                    foreach (DataGridViewColumn col in dgv.Columns)
                    {
                        string headerTraducido = TraductorSubject_941lp.Instancia_941lp
                            .Traducir_941lp(nombreFormulario, col.Name, idioma, col.HeaderText);
                        col.HeaderText = headerTraducido;
                    }
                }

                if (c.HasChildren)
                    TraducirControles_941lp(c, nombreFormulario, idioma);
            }
        }
    }
}
