using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class DigitoVerificador_941lp
    {
        public string nombreTabla_941lp { get; set; }
        public string horizontal_941lp { get; set; }
        public string vertical_941lp { get; set; }
        
        public DigitoVerificador_941lp(string pNombre_941lp, string pHorizontal_941lp, string pVertical_94lp )
        {
            nombreTabla_941lp = pNombre_941lp;
            horizontal_941lp = pHorizontal_941lp;
            vertical_941lp = pVertical_94lp;
        }
    }
}
