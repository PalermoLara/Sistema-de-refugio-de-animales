using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class PermisoSimple_941lp : Permiso_941lp
    {
        public PermisoSimple_941lp(string pNombrePermiso_941lp) : base(pNombrePermiso_941lp, false, false)
        {
        }
    }
}
