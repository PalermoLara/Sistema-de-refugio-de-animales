using SERVICIOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    internal class EstadoLogIn941lp : IEstado941lp
    {
        FormularioLogIn941lp login_941lp;

        public void CerrarEstado_941lp()
        {
            login_941lp?.Dispose();
        }

        public void EjecutarEstado_941lp()
        {
            login_941lp = new FormularioLogIn941lp();
            login_941lp.ShowDialog();
        }
    }
}
