using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class dao_941lp 
    {
        DataTable dt_941lp;
        SqlConnection connection_941lp;
        SqlCommand cmd_941lp;

        public dao_941lp()
        {
            connection_941lp = new SqlConnection("Data Source=.;Initial Catalog=sistAdopcion941lp;Integrated Security=True;");
            connection_941lp.Open();
            cmd_941lp = new SqlCommand("", connection_941lp);
        }

        public DataTable RetornarTabla_941lp(string tabla_941lp, string query_941lp, Dictionary<string, object> parametros_941lp = null)
        {
            dt_941lp = new DataTable(tabla_941lp);
            AsignarParametros_941lp(query_941lp, parametros_941lp);
            using (SqlDataReader dr_941lp = cmd_941lp.ExecuteReader())
            {
                dt_941lp.Load(dr_941lp);
            }
            dt_941lp.PrimaryKey = new DataColumn[] { dt_941lp.Columns[0] };
            return dt_941lp;
        }

        public void Query_941lp(string query_941lp, Dictionary<string, object> parametros_941lp = null)
        {
            AsignarParametros_941lp(query_941lp, parametros_941lp);
            cmd_941lp.ExecuteNonQuery();
        }

        private void AsignarParametros_941lp(string query_941lp, Dictionary<string, object> parametros_941lp)
        {
            cmd_941lp.CommandText = query_941lp;
            cmd_941lp.Parameters.Clear();
            if (parametros_941lp != null)
            {
                foreach (KeyValuePair<string, object> parametro in parametros_941lp)
                {
                    cmd_941lp.Parameters.AddWithValue(parametro.Key, parametro.Value);
                }
            }
        }

        public void Abrir_941lp()
        {
            connection_941lp.Open();
        }

        public void Cerrar_941lp()
        {
            connection_941lp.Close();
        }

        public bool Estados_941lp()
        {
            bool abierto_941lp = false;
            if (connection_941lp.State == ConnectionState.Open)
            {
                abierto_941lp = true;
            }
            return abierto_941lp;
        }
    }
}
