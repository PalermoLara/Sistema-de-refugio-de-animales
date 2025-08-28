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
    public class ormCertificado_941lp
    {
        dao_941lp dao_941lp;

        public ormCertificado_941lp()
        {
            dao_941lp = new dao_941lp();
        }

        public void Alta_941lp(CertificadoAdopcion_941lp certificado_941lp)
        {
            string query_941lp = "INSERT INTO CertificadoAdopcion_941lp " +
                         "(codigo_941lp,dni_941lp,codigoAnimal_941lp, especie_941lp,raza_941lp, nombreAnimal_941lp, nombreAdoptante_941lp, apellidoAdoptante_941lp,fecha_941lp) " +
                         "VALUES ( @codigo_941lp,@dni_941lp,@codigoAnimal_941lp, @especie_941lp,@raza_941lp, @nombreAnimal_941lp, @nombreAdoptante_941lp, @apellidoAdoptante_941lp, @fecha_941lp)";
            
            EjecutarQueryConEntidad_941lp(certificado_941lp, query_941lp);
        }

        public void Modificar_941lp(CertificadoAdopcion_941lp certificado_941lp)
        {
            string query_941lp = "UPDATE CertificadoAdopcion_941lp SET dni_941lp = @dni_941lp ,codigoAnimal_941lp = @codigoAnimal_941lp, especie_941lp = @especie_941lp ,raza_941lp = @raza_941lp, nombreAnimal_941lp = @nombreAnimal_941lp, nombreAdoptante_941lp = @nombreAdoptante_941lp, apellidoAdoptante_941lp = @apellidoAdoptante_941lp WHERE codigo_941lp = @codigo_941lp";
            // Lista de propiedades usadas en la consulta
            var props = new List<string>
            {
                "dni_941lp","codigoAnimal_941lp", "especie_941lp","raza_941lp", "nombreAnimal_941lp", "nombreAdoptante_941lp", "apellidoAdoptante_941lp", "codigo_941lp"
            };
            EjecutarQueryConEntidad_941lp(certificado_941lp, query_941lp, props);
        }

        private void EjecutarQueryConEntidad_941lp(CertificadoAdopcion_941lp certificado_941lp, string query_941lp, List<string> propiedadesIncluir_941lp = null)
        {
            Dictionary<string, object> parametros_941lp = ParametroHelper_941lp.CrearParametros_941lp(certificado_941lp, propiedadesIncluir_941lp);
            dao_941lp.Query_941lp(query_941lp, parametros_941lp);
        }

        public List<CertificadoAdopcion_941lp> RetornarCertificados_941lp()
        {
            List<CertificadoAdopcion_941lp> certificado_941lp = dao_941lp.RetornarLista_941lp("SELECT * FROM CertificadoAdopcion_941lp", MapearCertificado_941lp);
            return certificado_941lp;
        }

        private CertificadoAdopcion_941lp MapearCertificado_941lp(SqlDataReader reader)
        {

            return new CertificadoAdopcion_941lp(
                reader["codigo_941lp"].ToString(),
                reader["dni_941lp"].ToString(),
                Convert.ToInt32(reader["codigoAnimal_941lp"]),
                reader["especie_941lp"].ToString(),
                reader["raza_941lp"].ToString(),
                reader["nombreAnimal_941lp"].ToString(),
                reader["nombreAdoptante_941lp"].ToString(),
                reader["apellidoAdoptante_941lp"].ToString(),
                Convert.ToDateTime(reader["fecha_941lp"])
            );
        }
    }
}
