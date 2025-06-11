using BE;
using ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BLL
{
    public class bllFichaMedica_941lp
    {
        ormFichaMedica_941lp orm_941lp;

        public bllFichaMedica_941lp()
        {
            orm_941lp = new ormFichaMedica_941lp();
        }

        public void Alta_941lp(int codigoAnimal_941lp, DateTime fecha_941lp, bool castrado_941lp, string dieta_941lp, string medicamento_941lp, string observaciones_941lp = null)
        {
            DateTime soloFecha_941lp = fecha_941lp.Date;
            FichaMedica_941lp ficha_941lp = new FichaMedica_941lp(codigoAnimal_941lp, soloFecha_941lp,castrado_941lp,  dieta_941lp, medicamento_941lp, observaciones_941lp);
            orm_941lp.Alta_941lp(ficha_941lp);
        }

        public void Modificar_941lp(int codigo_941lp, bool castrado_941lp, string dieta_941lp, string medicamento_941lp, string observaciones_941lp = null)
        {
            FichaMedica_941lp ficha_941lp = RetornarFichas_941lp().Find(x => x.codigo_941lp == codigo_941lp);
            ficha_941lp.castrado_941lp = castrado_941lp;
            ficha_941lp.dieta_941lp = dieta_941lp;
            ficha_941lp.medicamento_941lp = medicamento_941lp;
            ficha_941lp.observaciones_941lp = observaciones_941lp;
            orm_941lp.Modificar_941lp(ficha_941lp);
        }

        public List<FichaMedica_941lp> RetornarFichas_941lp()
        {
            return orm_941lp.RetornarFichaMedica_941lp();
        }
    }
}
