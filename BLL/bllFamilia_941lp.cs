using BE;
using ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class bllFamilia_941lp
    {
        ormFamilia_941lp orm_941lp;

        public bllFamilia_941lp()
        {
            orm_941lp = new ormFamilia_941lp();
        }

        public void AltaFamilia_941lp(string nombreFamilia_941lp, List<string> listaAñadidos_941lp)
        {
            Perfil_941lp p_941lp;
            Familia_941lp familia_941lp = (Familia_941lp)RetornarFamilias_941lp().Find(x => x.nombrePermiso_941lp == nombreFamilia_941lp);
            foreach (string s_941lp in listaAñadidos_941lp)
            {
                p_941lp = RetornarFamilias_941lp().Find(x => x.nombrePermiso_941lp == s_941lp);
                if(p_941lp !=null)
                {
                    familia_941lp.AgregarPermiso(p_941lp);
                    orm_941lp.AltaFamilia_941lp(nombreFamilia_941lp);
                    if(p_941lp.GetType() == typeof(PermisoSimple_941lp))
                    {

                    }
                }
            }
        }

        public bool VerificarNombreDeFamilia_941lp(string nombreFamilia_941lp)
        {
            return orm_941lp.VerificarNombreDeFamilia_941lp(nombreFamilia_941lp);
        }

        public List<Perfil_941lp> RetornarFamilias_941lp()
        {
            return orm_941lp.ObtenerCompositeFamilias_941lp().Values.ToList();
        }
    }
}
