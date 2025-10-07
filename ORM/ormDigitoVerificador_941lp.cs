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
    public class ormDigitoVerificador_941lp
    {
        dao_941lp dao_941lp;

        public ormDigitoVerificador_941lp()
        {
            dao_941lp = new dao_941lp();
        }

        public void Update_941lp(DigitoVerificador_941lp d_941lp)
        {
            string query_941lp = "UPDATE DigitoVerificador_941lp SET horizontal_941lp = @horizontal_941lp, vertical_941lp = @vertical_941lp WHERE nombreTabla_941lp = @nombreTabla_941lp";

            var parametros_941lp = new Dictionary<string, object>
            {
                { "@nombreTabla_941lp", d_941lp.nombreTabla_941lp },
                { "@horizontal_941lp", d_941lp.horizontal_941lp },
                { "@vertical_941lp", d_941lp.vertical_941lp }
            };

            dao_941lp.Query_941lp(query_941lp, parametros_941lp);
        }

        public bool CompararDigitos_941lp(List<DigitoVerificador_941lp> listaCalculados_941lp)
        {
            // Si se detecta cualquier diferencia, devolvemos true
            bool error = false;

            foreach (var dvCalculado in listaCalculados_941lp)
            {
                string query = @"SELECT nombreTabla_941lp,horizontal_941lp, vertical_941lp 
                         FROM DigitoVerificador_941lp 
                         WHERE nombreTabla_941lp = @nombreTabla_941lp";

                var parametros = new Dictionary<string, object>
                {
                    { "@nombreTabla_941lp", dvCalculado.nombreTabla_941lp }
                };

                List<DigitoVerificador_941lp> resultado = dao_941lp.RetornarLista_941lp(query, MapearDigito_941lp, parametros);

                if (resultado.Count == 0)
                {
                    // No existe el registro en BD → error
                    error = true;
                    break;
                }

                var almacenado = resultado[0];

                //Comparamos los valores
                if (almacenado.horizontal_941lp != dvCalculado.horizontal_941lp ||
                    almacenado.vertical_941lp != dvCalculado.vertical_941lp)
                {
                    error = true;
                    break;
                }
            }

            return error;
        }

        public List<DigitoVerificador_941lp> RetornarDigitos_941lp()
        {
            List<DigitoVerificador_941lp> digito_941lp = dao_941lp.RetornarLista_941lp("SELECT * FROM DigitoVerificador_941lp", MapearDigito_941lp);
            return digito_941lp;
        }

        private DigitoVerificador_941lp MapearDigito_941lp(SqlDataReader reader)
        {
            return new DigitoVerificador_941lp(
                reader["nombreTabla_941lp"].ToString(),
                reader["horizontal_941lp"].ToString(),
                reader["vertical_941lp"].ToString()
            );
        }
    }
}
