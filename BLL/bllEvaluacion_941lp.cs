using BE;
using ORM;
using SERVICIOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class bllEvaluacion_941lp
    {
        ormEvaluacion_941lp orm_941lp;
        bllBitacoraEventos_941lp bllBitacoraEvento_941lp;

        public bllEvaluacion_941lp()
        {
            orm_941lp = new ormEvaluacion_941lp();
            bllBitacoraEvento_941lp = new bllBitacoraEventos_941lp();
        }

        public void Alta_941lp(string dni_941lp, string motivo_941lp, string condicionesEconomicas_941lp, string vivienda_941lp)
        {
            EvaluacionAdoptante_941lp evaluacion_941lp = new EvaluacionAdoptante_941lp(dni_941lp, motivo_941lp, condicionesEconomicas_941lp, vivienda_941lp);
            orm_941lp.Alta_941lp(evaluacion_941lp);
            bllBitacoraEvento_941lp.Alta_941lp(sessionManager941lp.Gestor_941lp.RetornarUsuarioSession_941lp().nombreUsuario_941lp, "Gestion evaluación del adoptante", "Evaluación dada de alta", 4);
        }

        public void Modificar_941lp(int codigo_941lp, string dni_941lp,  string motivo_941lp, string condicionesEconomicas_941lp, string vivienda_941lp)
        {
            EvaluacionAdoptante_941lp evaluacion_941lp = RetornarEvaluaciones_941lp().Find(x => x.codigoEv_941lp == codigo_941lp);
            evaluacion_941lp.dni_941lp = dni_941lp;
            evaluacion_941lp.motivo_941lp = motivo_941lp;
            evaluacion_941lp.condicionesEconomicas_941lp = condicionesEconomicas_941lp;
            evaluacion_941lp.vivienda_941lp  = vivienda_941lp;
            orm_941lp.Modificar_941lp(evaluacion_941lp);
            bllBitacoraEvento_941lp.Alta_941lp(sessionManager941lp.Gestor_941lp.RetornarUsuarioSession_941lp().nombreUsuario_941lp, "Gestion evaluación del adoptante", "Evaluación modificada", 4);
        }


        public List<EvaluacionAdoptante_941lp> RetornarEvaluaciones_941lp()
        {
            return orm_941lp.RetornarEvaluaciones_941lp();
        }
    }
}
