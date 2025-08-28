using BE;
using DAO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ORM
{
    public class ormEvaluacion_941lp
    {
        dao_941lp dao_941lp;

        public ormEvaluacion_941lp()
        {
            dao_941lp = new dao_941lp();
        }

        public void Alta_941lp(EvaluacionAdoptante_941lp evaluacion_941lp)
        {
            string query_941lp = "INSERT INTO EvaluacionAdoptante_941lp " +
                         "( dni_941lp, motivo_941lp, condicionesEconomicas_941lp,vivienda_941lp) " +
                         "VALUES (@dni_941lp, @motivo_941lp, @condicionesEconomicas_941lp, @vivienda_941lp)";
            EjecutarQueryConEntidad_941lp(evaluacion_941lp, query_941lp);
        }

        public void Modificar_941lp(EvaluacionAdoptante_941lp evaluacion_941lp)
        {
            string query_941lp = "UPDATE EvaluacionAdoptante_941lp SET dni_941lp = @dni_941lp,   motivo_941lp = @motivo_941lp,condicionesEconomicas_941lp = @condicionesEconomicas_941lp,vivienda_941lp = @vivienda_941lp WHERE codigoEv_941lp = @codigoEv_941lp";
            // Lista de propiedades usadas en la consulta
            var props = new List<string>
            {
                "dni_941lp",
                "motivo_941lp",
                "condicionesEconomicas_941lp",
                "vivienda_941lp",
                "codigoEv_941lp"
            };

            EjecutarQueryConEntidad_941lp(evaluacion_941lp, query_941lp, props);
        }

        private void EjecutarQueryConEntidad_941lp(EvaluacionAdoptante_941lp evaluacion_941lp, string query_941lp, List<string> propiedadesIncluir_941lp = null)
        {
            Dictionary<string, object> parametros_941lp = ParametroHelper_941lp.CrearParametros_941lp(evaluacion_941lp, propiedadesIncluir_941lp);
            dao_941lp.Query_941lp(query_941lp, parametros_941lp);
        }


        public List<EvaluacionAdoptante_941lp> RetornarEvaluaciones_941lp()
        {
            List<EvaluacionAdoptante_941lp> evaluacion_941lp = dao_941lp.RetornarLista_941lp("SELECT * FROM EvaluacionAdoptante_941lp", MapearEvaluacion_941lp);
            return evaluacion_941lp;
        }

        private EvaluacionAdoptante_941lp MapearEvaluacion_941lp(SqlDataReader reader)
        {

            return new EvaluacionAdoptante_941lp(
                Convert.ToInt32(reader["codigoEv_941lp"]),
                reader["dni_941lp"].ToString(),
                reader["motivo_941lp"].ToString(),
                reader["condicionesEconomicas_941lp"].ToString(),
                reader["vivienda_941lp"].ToString()
            );
        }
    }
}
