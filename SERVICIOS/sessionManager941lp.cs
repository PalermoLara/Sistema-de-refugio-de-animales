using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS
{
    public class sessionManager941lp
    {
        public Usuario_941lp usuarioSession_941lp;
        private static sessionManager941lp instance_941lp;

        private string idioma_941lp = "es"; // idioma por defecto

        public string Idioma_941lp
        {
            get => idioma_941lp;
            set => idioma_941lp = value;
        }

        public static sessionManager941lp Gestor_941lp
        {
            get 
            { 
                if (instance_941lp == null)
                { 
                    instance_941lp = new sessionManager941lp(); 
                } 
                return instance_941lp;
            }
        }

        private HashSet<string> permisosUsuario_941lp;

        public void SetPermisosUsuario_941lp(HashSet<string> permisos_941lp)
        {
            permisosUsuario_941lp = permisos_941lp;
        }

        public HashSet<string> RetornarPermisosUsuario_941lp()
        {
            return permisosUsuario_941lp;
        }

        public Usuario_941lp RetornarUsuarioSession_941lp()
        {
            return usuarioSession_941lp;
        }

        public bool Session_941lp()
        {
            return usuarioSession_941lp != null ? true : false;
        }

        public void SetUsuario_941lp(Usuario_941lp usuario_941lp)
        {
            usuarioSession_941lp = usuario_941lp;
        }

        public void UnsetUsuario_941lp()
        {
            Gestor_941lp.usuarioSession_941lp = null;
        }
    }
}
