using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Usuario_941lp
    {

        public Usuario_941lp(string pDni_941lp, string pNombreUsuario_941lp, string pContraseñaUsuario_941lp, string pNombre_941lp, string pApellido_941lp, string pRol_941lp,string pEmailUsuario_941lp, bool pBloqueo_941lp, int pIntentos_941lp, string pLenguaje_941lp, bool pActivado_941lp, DateTime? pHoraDesbloqueo_941lp)
        {
            dni_941lp = pDni_941lp;
            nombreUsuario_941lp = pNombreUsuario_941lp;
            contraseña_941lp = pContraseñaUsuario_941lp;
            nombre_941lp = pNombre_941lp;
            apellido_941lp = pApellido_941lp;
            rol_941lp = pRol_941lp;
            email_941lp = pEmailUsuario_941lp;
            bloqueo_941lp = pBloqueo_941lp;
            intentos_941lp = pIntentos_941lp;
            lenguaje_941lp = pLenguaje_941lp;
            activo_941lp = pActivado_941lp;
            horaDesbloquear_941lp = pHoraDesbloqueo_941lp;
        }

        public string dni_941lp { get; set; }
        public string nombreUsuario_941lp { get; set; }
        public string contraseña_941lp { get; set; }
        public string nombre_941lp { get; set; }
        public string apellido_941lp { get; set; }
        public string rol_941lp { get; set; }
        public string email_941lp { get; set; }
        public bool bloqueo_941lp  { get; set; }
        public int intentos_941lp { get; set; }
        public string lenguaje_941lp { get; set; }
        public bool activo_941lp { get; set; }
        public DateTime? horaDesbloquear_941lp { get; set; }
    }
}
