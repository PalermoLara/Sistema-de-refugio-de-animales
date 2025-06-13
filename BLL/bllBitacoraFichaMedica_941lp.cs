using BE;
using ORM;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class bllBitacoraFichaMedica_941lp
    {
        ormBitacoraFichaMedica_941lp orm_941lp;

        public bllBitacoraFichaMedica_941lp()
        {
            orm_941lp = new ormBitacoraFichaMedica_941lp();
        }

        public void Alta_941lp(int codigoFicha_941lp, DateTime fecha_941lp, string operacion_941lp, string campoModificado_941lp = null, string valorPrevio_941lp = null, string valorNuevo_941lp = null)
        {
            BitacoraFichaMedica_941lp ficha_941lp = new BitacoraFichaMedica_941lp(codigoFicha_941lp, fecha_941lp, operacion_941lp, campoModificado_941lp, valorPrevio_941lp, valorNuevo_941lp);
            orm_941lp.Alta_941lp(ficha_941lp);
        }

        private BitacoraFichaMedica_941lp ObtenerBiracora_941lp(int codigo_941lp)
        {
            return orm_941lp.ObtenerBitacoraPorCodigo_941lp(codigo_941lp);
        }

        public bool VerificarCambioValor_941lp(int codigo_941lp,string valorNuevo_941lp)
        {
            return ObtenerBiracora_941lp(codigo_941lp).valorPrevio_941lp == valorNuevo_941lp;
        }



        public List<BitacoraFichaMedica_941lp> RetornarBitacora_941lp()
        {
            return orm_941lp.RetornarFichaIngreso_941lp();
        }
    }
}
