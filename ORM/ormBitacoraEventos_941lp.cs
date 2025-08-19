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
    public class ormBitacoraEventos_941lp
    {
        dao_941lp dao_941lp;

        public ormBitacoraEventos_941lp()
        {
            dao_941lp = new dao_941lp();
        }

        public string GenerarCodigoBitacora_941lp(DateTime fecha_941lp)
        {
            string fechaFormateada_941lp = fecha_941lp.ToString("ddMMyy");

            string query_941lp = "SELECT ISNULL(MAX(CAST(SUBSTRING(codigo_941lp, 7, 4) AS INT)), 0) FROM BitacoraEventos_941lp " +
                             "WHERE fecha_941lp = @fecha_941lp";

            Dictionary<string, object> parametros = new Dictionary<string, object>
            {
                { "@fecha_941lp", fecha_941lp.Date }
            };

            object resultado_941lp = dao_941lp.EjecutarEscalar_941lp(query_941lp, parametros);

            int ultimoConsecutivo_941lp = resultado_941lp != null && resultado_941lp != DBNull.Value ?
                                  Convert.ToInt32(resultado_941lp) : 0;

            int nuevoConsecutivo_941lp = ultimoConsecutivo_941lp + 1;

            return fechaFormateada_941lp + nuevoConsecutivo_941lp.ToString("D4");
        }

        public void Alta_941lp(Evento_941lp evento_941lp)
        {
            evento_941lp.codigo_941lp = GenerarCodigoBitacora_941lp(evento_941lp.fecha_941lp);
            string query_941lp = "INSERT INTO BitacoraEventos_941lp " +
                         "(codigo_941lp, dni_941lp, fecha_941lp, hora_941lp, modulo_941lp, evento_941lp, criticidad_941lp) " +
                         "VALUES (@codigo_941lp, @dni_941lp, @fecha_941lp, @hora_941lp, @modulo_941lp, @evento_941lp, @criticidad_941lp)";
            EjecutarQueryConEntidad_941lp(evento_941lp, query_941lp);
        }

        private void EjecutarQueryConEntidad_941lp(Evento_941lp evento_941lp, string query_941lp, List<string> propiedadesIncluir_941lp = null)
        {
            Dictionary<string, object> parametros_941lp = ParametroHelper_941lp.CrearParametros_941lp(evento_941lp, propiedadesIncluir_941lp);
            dao_941lp.Query_941lp(query_941lp, parametros_941lp);
        }

        public List<Evento_941lp> RetornarEventos_941lp()
        {
            List<Evento_941lp> evento_941lp = dao_941lp.RetornarLista_941lp("SELECT * FROM BitacoraEventos_941lp", MapearEvento_941lp);
            return evento_941lp;
        }

        private Evento_941lp MapearEvento_941lp(SqlDataReader reader)
        {
            TimeSpan hora;
            object horaValue = reader["hora_941lp"];
            if (horaValue is TimeSpan)
            {
                hora = (TimeSpan)horaValue;
            }
            else if (horaValue is DateTime)
            {
                hora = ((DateTime)horaValue).TimeOfDay;
            }
            else
            {
                hora = TimeSpan.Parse(horaValue.ToString());
            }
            return new Evento_941lp(
                reader["codigo_941lp"].ToString(),
                reader["dni_941lp"].ToString(),
                Convert.ToDateTime(reader["fecha_941lp"]),
                hora,
                reader["modulo_941lp"].ToString(),
                reader["evento_941lp"].ToString(),
                Convert.ToInt32(reader["criticidad_941lp"])
            );
        }
    }
}
