using ORM;
using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SERVICIOS;
using System.Threading.Tasks;

namespace BLL
{
    public class bllPermisos_941lp
    {
        ormPermiso_941lp orm_941lp;

        public bllPermisos_941lp()
        {
            orm_941lp = new ormPermiso_941lp();
        }

        public bool VerificarNombreDePatente_941lp(string nombrePatente_941lp)
        {
            return orm_941lp.VerificarNombreDePatente_941lp(nombrePatente_941lp);
        }

        public List<PermisoSimple_941lp> RetornarPermisos_941lp()
        {
            return orm_941lp.RetornarPermisos_941lp();
        }
    }
}
