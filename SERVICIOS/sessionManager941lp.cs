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

        public Usuario_941lp RetornarUsuarioSession_941lp()
        {
            return usuarioSession_941lp;
        }

        public bool Session_941lp()
        {
            bool iniciada_941lp = false;
            if(usuarioSession_941lp!=null)
            {
                iniciada_941lp = true;
            }
            return iniciada_941lp;
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
