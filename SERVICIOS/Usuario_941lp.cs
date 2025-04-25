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
        public Usuario_941lp() { }

        public Usuario_941lp(string pDni_941lp, string pNombreUsuario_941lp, string pContraseñaUsuario_941lp, string pNombre_941lp, string pApellido_941lp, string pRol_941lp,string pEmailUsuario_941lp, bool pBloqueo_941lp, int pIntentos_941lp, string pLenguaje_941lp, bool pActivado_941lp)
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
        }

        public Usuario_941lp(object[] datos_941lp)
        {
            dni_941lp = datos_941lp[0].ToString();
            nombreUsuario_941lp = datos_941lp[1].ToString();
            contraseña_941lp = datos_941lp[2].ToString();
            nombre_941lp = datos_941lp[3].ToString();
            apellido_941lp = datos_941lp[4].ToString();
            rol_941lp = datos_941lp[5].ToString();
            email_941lp = datos_941lp[6].ToString();
            bloqueo_941lp = Convert.ToBoolean(datos_941lp[7]);
            intentos_941lp = Convert.ToInt32(datos_941lp[8]);
            lenguaje_941lp = datos_941lp[9].ToString();
            activo_941lp = Convert.ToBoolean(datos_941lp[10]);
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
    }
}
