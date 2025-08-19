using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Evento_941lp
    {
        public Evento_941lp(string cod_941lp, string pDni_941lp, DateTime f_941lp, TimeSpan h_941lp, string mod_941lp, string ev_941lp, int crit_941lp)
        : this(pDni_941lp,  f_941lp,  h_941lp,  mod_941lp,  ev_941lp,  crit_941lp)
        {
            codigo_941lp = cod_941lp;
        }

        public Evento_941lp(string pDni_941lp, DateTime f_941lp, TimeSpan h_941lp, string mod_941lp, string ev_941lp, int crit_941lp)
        {
            dni_941lp = pDni_941lp;
            fecha_941lp = f_941lp;
            hora_941lp = h_941lp;
            modulo_941lp = mod_941lp;
            evento_941lp = ev_941lp;
            criticidad_941lp = crit_941lp;
        }

        public string codigo_941lp { get; set; } 
        public string dni_941lp { get; set; }
        public DateTime fecha_941lp { get; set; }
        public TimeSpan hora_941lp { get; set; }
        public string modulo_941lp { get; set; }
        public string evento_941lp { get; set; }
        public int criticidad_941lp { get; set; }
    }
}
