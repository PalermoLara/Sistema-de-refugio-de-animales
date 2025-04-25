using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    internal class GestorFormulario941lp
    {
        private static GestorFormulario941lp instance_941lp;
        private IEstado941lp estadoActual_941lp;
        public static GestorFormulario941lp gestorFormSG_941lp
        {
            get
            {
                if (instance_941lp == null)
                {
                    instance_941lp = new GestorFormulario941lp();
                }
                return instance_941lp;
            }
        }

        public void DefinirEstado_941lp(IEstado941lp estadoNuevo)
        {
            estadoActual_941lp?.CerrarEstado_941lp();
            estadoActual_941lp = estadoNuevo;
            estadoActual_941lp.EjecutarEstado_941lp();
        }
    }
}
