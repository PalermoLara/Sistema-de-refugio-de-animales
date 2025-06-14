using BE;
using ORM;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BLL
{
    public class bllBitacoraFichaMedica_941lp
    {
        ormBitacoraFichaMedica_941lp orm_941lp;
        ormFichaMedica_941lp ormFichaMedica_941Lp;
        public bllBitacoraFichaMedica_941lp()
        {
            orm_941lp = new ormBitacoraFichaMedica_941lp();
            ormFichaMedica_941Lp = new ormFichaMedica_941lp();
        }

        public void Alta_941lp(int codigoFicha_941lp, DateTime fecha_941lp, string operacion_941lp, string campoModificado_941lp = null, string valorPrevio_941lp = null, string valorNuevo_941lp = null)
        {
            BitacoraFichaMedica_941lp ficha_941lp = new BitacoraFichaMedica_941lp(codigoFicha_941lp, fecha_941lp, operacion_941lp, campoModificado_941lp, valorPrevio_941lp, valorNuevo_941lp);
            orm_941lp.Alta_941lp(ficha_941lp);
        }

        private FichaMedica_941lp ObtenerFicha_941lp(int codigo_941lp)
        {
            return ormFichaMedica_941Lp.RetornarFichaMedica_941lp().Find(x=>x.codigo_941lp == codigo_941lp);
        }

        public bool VerificarCambioValor_941lp(int codigo_941lp, string campo_941lp, string valorNuevo_941lp)
        {
            bool cambio_941lp = false;
            switch(campo_941lp)
            {
                case "Medicamento":
                    if (ObtenerFicha_941lp(codigo_941lp).medicamento_941lp != valorNuevo_941lp) { cambio_941lp = true; } 
                    break;
                case "Dieta":
                    if (ObtenerFicha_941lp(codigo_941lp).dieta_941lp != valorNuevo_941lp) { cambio_941lp = true; }
                    break;
                case "Observaciones":
                    if (ObtenerFicha_941lp(codigo_941lp).observaciones_941lp != valorNuevo_941lp) { cambio_941lp = true; }
                    break;
                case "Castrado":
                    if (ObtenerFicha_941lp(codigo_941lp).castrado_941lp != (valorNuevo_941lp == "SI")) { cambio_941lp = true; }
                    break;
                default:
                    MessageBox.Show("Error");
                    break;
            }
            return cambio_941lp;
        }



        public List<BitacoraFichaMedica_941lp> RetornarBitacora_941lp()
        {
            return orm_941lp.RetornarFichaIngreso_941lp();
        }
    }
}
