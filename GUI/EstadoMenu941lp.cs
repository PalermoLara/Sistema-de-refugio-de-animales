using SERVICIOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    internal class EstadoMenu941lp : IEstado941lp
    {
        FormularioMenuPrincipal941lp menu_941lp;

        public void CerrarEstado_941lp()
        {
            menu_941lp?.Dispose();
        }

        public void EjecutarEstado_941lp()
        {
            menu_941lp = new FormularioMenuPrincipal941lp();
            menu_941lp.ShowDialog();
        }
    }
}
