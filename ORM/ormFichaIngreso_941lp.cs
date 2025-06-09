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
    public class ormFichaIngreso_941lp
    {
        dao_941lp dao_941lp;

        public ormFichaIngreso_941lp()
        {
            dao_941lp = new dao_941lp();
        }

        public void Alta_941lp(FichaDeIngreso_941lp ficha_941lp)
        {
            string query_941lp = "INSERT INTO FichaDeIngreso_941lp " +
                         "(codigoAnimal_941lp,dni_941lp, especie_941lp, fecha_941lp, hora_941lp, razon_941lp, zona_941lp) " +
                         "VALUES ( @codigoAnimal_941lp,@dni_941lp, @especie_941lp, @fecha_941lp, @hora_941lp, @razon_941lp, @zona_941lp)";
            var propiedadesIncluir_941lp = new List<string>
            {
                "codigoAnimal_941lp","dni_941lp", "especie_941lp", "fecha_941lp", "hora_941lp", "razon_941lp", "zona_941lp", "codigo_941lp"
            };
            EjecutarQueryConEntidad_941lp(ficha_941lp, query_941lp, propiedadesIncluir_941lp);
        }

        public void Modificar_941lp(FichaDeIngreso_941lp ficha_941lp)
        {
            string query_941lp = "UPDATE FichaDeIngreso_941lp SET razon_941lp = @razon_941lp, zona_941lp = @zona_941lp WHERE codigo_941lp = @codigo_941lp";
            // Lista de propiedades usadas en la consulta
            var props = new List<string>
            {
                "razon_941lp", "zona_941lp", "codigo_941lp"
            };
            EjecutarQueryConEntidad_941lp(ficha_941lp, query_941lp, props);
        }

        private void EjecutarQueryConEntidad_941lp(FichaDeIngreso_941lp ficha_941lp, string query_941lp, List<string> propiedadesIncluir_941lp = null)
        {
            Dictionary<string, object> parametros_941lp = ParametroHelper_941lp.CrearParametros_941lp(ficha_941lp, propiedadesIncluir_941lp);
            dao_941lp.Query_941lp(query_941lp, parametros_941lp);
        }

        public List<FichaDeIngreso_941lp> RetornarFichaIngreso_941lp()
        {
            List<FichaDeIngreso_941lp> ficha_941lp = dao_941lp.RetornarLista_941lp("SELECT * FROM FichaDeIngreso_941lp", MapearFicha_941lp);
            return ficha_941lp;
        }

        private FichaDeIngreso_941lp MapearFicha_941lp(SqlDataReader reader)
        {

            return new FichaDeIngreso_941lp(
                Convert.ToInt32(reader["codigo_941lp"]),
                Convert.ToInt32(reader["codigoAnimal_941lp"]),
                reader["dni_941lp"].ToString(),
                reader["especie_941lp"].ToString(),
                Convert.ToDateTime(reader["fecha_941lp"]),
                TimeSpan.Parse(reader["hora_941lp"].ToString()),
                reader["razon_941lp"].ToString(),
                reader["zona_941lp"].ToString()
            );
        }
    }
}
