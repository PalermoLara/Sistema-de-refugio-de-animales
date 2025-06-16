using ORM;
using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class bllPermisos_941lp
    {
        ormPermisos_941lp orm_941lp;

        public bllPermisos_941lp()
        {
            orm_941lp = new ormPermisos_941lp();
        }

        public List<Permiso_941lp> RetornarPermisos_941lp()
        {
            return orm_941lp.RetornarPermisos_941lp();
        }
    }
}
