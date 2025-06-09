using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class FichaDeIngreso_941lp
    {
        public FichaDeIngreso_941lp(int pCodigo_941lp, int pCodigoAnimal_941lp, string pDni_941lp, string pEspecie_941lp, DateTime pFecha_941lp, TimeSpan pHora_941lp, string pRazon_941lp, string pZona_941lp)
        : this(pCodigoAnimal_941lp, pDni_941lp, pEspecie_941lp, pFecha_941lp, pHora_941lp, pRazon_941lp, pZona_941lp)
        {
            codigo_941lp = pCodigo_941lp;
        }


        public FichaDeIngreso_941lp( int pCodigoAnimal_941lp,string pDni_941lp, string pEspecie_941lp, DateTime pFecha_941lp, TimeSpan pHora_941lp, string pRazon_941lp, string pZona_941lp)
        {
            codigoAnimal_941lp = pCodigoAnimal_941lp;
            dni_941lp = pDni_941lp;
            especie_941lp  = pEspecie_941lp;
            fecha_941lp = pFecha_941lp;
            hora_941lp = pHora_941lp;
            razon_941lp = pRazon_941lp;
            zona_941lp = pZona_941lp;
        }


        public int codigo_941lp { get; set; }
        public int codigoAnimal_941lp { get; set; }
        public string dni_941lp { get; set; }
        public string especie_941lp { get; set; }
        public DateTime fecha_941lp { get; set; }
        public TimeSpan hora_941lp { get; set; }
        public string razon_941lp { get; set; }
        public string zona_941lp { get; set; }

        public override string ToString()
        {
            return $"Ficha #{codigo_941lp} - Animal: {codigoAnimal_941lp} - Cedente: {dni_941lp} - Fecha: {fecha_941lp:dd/MM/yyyy} - Hora: {hora_941lp} - razón: {razon_941lp} - zona: {zona_941lp}";
        }
    }
}
