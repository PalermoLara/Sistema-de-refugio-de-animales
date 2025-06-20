using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public abstract class Perfil_941lp
    {
        public Perfil_941lp(string pNombrePermiso_941lp)
        {
            nombrePermiso_941lp = pNombrePermiso_941lp;
        }

        public string nombrePermiso_941lp { get; set; }
    }
}
