using BE;
using DAO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class ormBitacoraFichaMedica_941lp
    {
        dao_941lp dao_941lp;

        public ormBitacoraFichaMedica_941lp()
        {
            dao_941lp = new dao_941lp();
        }

        public void Alta_941lp(BitacoraFichaMedica_941lp ficha_941lp)
        {
            string query_941lp = "INSERT INTO BitacoraFichaMedica_941lp " +
                         "(codigoFicha_941lp, fecha_941lp, operacion_941lp, campoModificado_941lp, valorPrevio_941lp, valorNuevo_941lp) " +
                         "VALUES ( @codigoFicha_941lp,@fecha_941lp, @operacion_941lp, @campoModificado_941lp, @valorPrevio_941lp, @valorNuevo_941lp)";
            var propiedadesIncluir_941lp = new List<string>
            {
                 "codigoFicha_941lp","fecha_941lp", "operacion_941lp", "campoModificado_941lp", "valorPrevio_941lp", "valorNuevo_941lp", "codigo_941lp"
            };
            EjecutarQueryConEntidad_941lp(ficha_941lp, query_941lp, propiedadesIncluir_941lp);
        }

        public BitacoraFichaMedica_941lp ObtenerBitacoraPorCodigo_941lp(int codigo_941lp)
        {
            string query_941lp = "SELECT * FROM BitacoraFichaMedica_941lp WHERE codigo_941lp = @codigo_941lp";
            var parametros_941lp = new Dictionary<string, object>
            {
                { "@codigo_941lp", codigo_941lp }
            };
            var bitacora_941lp = dao_941lp.RetornarLista_941lp(query_941lp, MapearBitacora_941lp, parametros_941lp);
            return bitacora_941lp.FirstOrDefault();
        }

        public List<BitacoraFichaMedica_941lp> RetornarFichaIngreso_941lp()
        {
            List<BitacoraFichaMedica_941lp> ficha_941lp = dao_941lp.RetornarLista_941lp("SELECT * FROM BitacoraFichaMedica_941lp", MapearBitacora_941lp);
            return ficha_941lp;
        }

        private void EjecutarQueryConEntidad_941lp(BitacoraFichaMedica_941lp bitacora_941lp, string query_941lp, List<string> propiedadesIncluir_941lp = null)
        {
            Dictionary<string, object> parametros_941lp = ParametroHelper_941lp.CrearParametros_941lp(bitacora_941lp, propiedadesIncluir_941lp);
            dao_941lp.Query_941lp(query_941lp, parametros_941lp);
        }

        private BitacoraFichaMedica_941lp MapearBitacora_941lp(SqlDataReader reader)
        {

            return new BitacoraFichaMedica_941lp(
                Convert.ToInt32(reader["codigo_941lp"]),
                Convert.ToInt32(reader["codigoFicha_941lp"]),
                Convert.ToDateTime(reader["fecha_941lp"]),
                reader["operacion_941lp"].ToString(),
                reader["campoModificado_941lp"].ToString(),
                reader["valorPrevio_941lp"].ToString(),
                reader["valorNuevo_941lp"].ToString()
            );
        }
    }
}
