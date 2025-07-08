using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS
{
    public class TraductorHelper_941lp
    {
        public static string TraducirMensaje_941lp(string formulario_941lp, string clave_941lp, string textoPorDefecto_941lp)
        {
            string idioma_941lp = sessionManager941lp.Gestor_941lp.Idioma_941lp;
            return TraductorSubject_941lp.Instancia_941lp.Traducir_941lp(formulario_941lp, clave_941lp, idioma_941lp, textoPorDefecto_941lp);
        }
    }
}
