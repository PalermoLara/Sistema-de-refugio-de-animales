using BE;
using iTextSharp.text;
using iTextSharp.text.pdf;
using ORM;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class bllBitacoraCambios_941lp
    {
        ormBitacoraCambios_941lp orm_941lp;

        public bllBitacoraCambios_941lp()
        {
            orm_941lp = new ormBitacoraCambios_941lp();
        }

        public List<BitacoraCambio_941lp> Filtros_941lp(Dictionary<string, object> filtros_941lp)
        {
            return orm_941lp.Filtros_941lp(filtros_941lp);
        }

        public List<BitacoraCambio_941lp> RetornarCambios_941lp()
        {
            List<BitacoraCambio_941lp> aux_941lp = new List<BitacoraCambio_941lp>();
            foreach (BitacoraCambio_941lp c_941lp in orm_941lp.RetornarCambios_941lp())
            {
                aux_941lp.Add(new BitacoraCambio_941lp(c_941lp.codMedicamento_941lp, c_941lp.fechaHora_941lp, c_941lp.nombreComercial_941lp, c_941lp.nombreGenerico_941lp, c_941lp.forma_941lp, c_941lp.caducidad_941lp, c_941lp.activoMedicamento_941lp, c_941lp.activo_941lp));
            }
            return aux_941lp;
        }
    }
}
