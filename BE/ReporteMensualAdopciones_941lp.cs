using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ReporteMensualAdopciones_941lp
    {
        public int Año_941lp { get; set; }
        public int Mes_941lp { get; set; }
        public int Ingresos_941lp { get; set; }
        public int Adopciones_941lp { get; set; }
        public double Porcentaje_941lp { get; set; }

        public string MesNombre_941lp
        {
            get
            {
                return new DateTime(Año_941lp, Mes_941lp, 1).ToString("MMMM");
            }
        }
    }
}
