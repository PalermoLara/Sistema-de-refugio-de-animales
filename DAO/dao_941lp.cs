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
        private readonly string connectionString_941lp;

        public dao_941lp()
        {
            connectionString_941lp = "Data Source=.;Initial Catalog=sistAdopcion941lp;Integrated Security=True;";
        }

        public List<T> RetornarLista_941lp<T>(string query_941lp, Func<SqlDataReader, T> mapFunc, Dictionary<string, object> parametros_941lp = null)
        {
            List<T> lista = new List<T>();
            using (SqlConnection connection = new SqlConnection(connectionString_941lp))
            using (SqlCommand cmd = new SqlCommand(query_941lp, connection))
            {
                AsignarParametros_941lp(cmd, parametros_941lp);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(mapFunc(reader));
                    }
                }
            }
            return lista;
        }

        public void Query_941lp(string query_941lp, Dictionary<string, object> parametros_941lp = null)
        {
            using (SqlConnection connection = new SqlConnection(connectionString_941lp))
            using (SqlCommand cmd = new SqlCommand(query_941lp, connection))
            {
                AsignarParametros_941lp(cmd, parametros_941lp);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public object EjecutarEscalar_941lp(string query_941lp, Dictionary<string, object> parametros_941lp = null)
        {
            using (SqlConnection connection = new SqlConnection(connectionString_941lp))
            using (SqlCommand cmd = new SqlCommand(query_941lp, connection))
            {
                AsignarParametros_941lp(cmd, parametros_941lp);
                connection.Open();
                return cmd.ExecuteScalar();
            }
        }

        private void AsignarParametros_941lp(SqlCommand cmd, Dictionary<string, object> parametros_941lp)
        {
            cmd.Parameters.Clear();
            if (parametros_941lp != null)
            {
                foreach (var parametro in parametros_941lp)
                {
                    cmd.Parameters.AddWithValue(parametro.Key, parametro.Value ?? DBNull.Value);
                }
            }
        }

        public void RestaurarBaseDatos_941lp(string rutaBackup_941lp)
        {
            const string miBase = "sistAdopcion941lp";

            string connectionStringMaster_941lp = "Data Source=.;Initial Catalog=master;Integrated Security=True;";

            using (SqlConnection connection_941lp = new SqlConnection(connectionStringMaster_941lp))
            {
                connection_941lp.Open();

                // 1. Verificar metadata del backup
                using (SqlCommand checkCmd = new SqlCommand("RESTORE HEADERONLY FROM DISK = @ruta", connection_941lp))
                {
                    checkCmd.Parameters.AddWithValue("@ruta", rutaBackup_941lp);

                    using (SqlDataReader reader = checkCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string dbName = reader["DatabaseName"].ToString();

                            if (!string.Equals(dbName, miBase, StringComparison.OrdinalIgnoreCase))
                            {
                                throw new InvalidOperationException(
                                    $"El backup corresponde a la base '{dbName}', pero solo se permite restaurar '{miBase}'.");
                            }
                        }
                        else
                        {
                            throw new InvalidOperationException("No se pudo leer la cabecera del backup.");
                        }
                    }
                }

                using (SqlCommand cmd_941lp = connection_941lp.CreateCommand())
                {
                    // 2. Matar conexiones abiertas
                    cmd_941lp.CommandText = $@"
                DECLARE @kill varchar(8000) = '';
                SELECT @kill = @kill + 'KILL ' + CONVERT(varchar(5), session_id) + ';'
                FROM sys.dm_exec_sessions
                WHERE database_id = DB_ID('{miBase}') AND session_id <> @@SPID;
                EXEC(@kill);";
                    cmd_941lp.ExecuteNonQuery();

                    // 3. Single user
                    cmd_941lp.CommandText = $@"ALTER DATABASE [{miBase}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;";
                    cmd_941lp.ExecuteNonQuery();

                    // 4. Restaurar
                    cmd_941lp.CommandText = $@"RESTORE DATABASE [{miBase}] 
                                       FROM DISK = @ruta 
                                       WITH REPLACE;";
                    cmd_941lp.Parameters.AddWithValue("@ruta", rutaBackup_941lp);
                    cmd_941lp.ExecuteNonQuery();

                    // 5. Multi user
                    cmd_941lp.Parameters.Clear();
                    cmd_941lp.CommandText = $@"ALTER DATABASE [{miBase}] SET MULTI_USER;";
                    cmd_941lp.ExecuteNonQuery();
                }
            }
        }


        public void EjecutarRollBack_941lp(string query_941lp, Dictionary<string, object> parametros_941lp = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString_941lp))
            {
                conn.Open();

                // 🔹 Configurar CONTEXT_INFO = 'ROLLBACK_LOGICO'
                using (SqlCommand ctx = new SqlCommand("SET CONTEXT_INFO 0x524F4C4C4241434B5F4C4F4749434F", conn))
                {
                    ctx.ExecuteNonQuery();
                }

                using (SqlCommand cmd = new SqlCommand(query_941lp, conn))
                {
                    if (parametros_941lp != null)
                    {
                        foreach (var p in parametros_941lp)
                            cmd.Parameters.AddWithValue(p.Key, p.Value ?? DBNull.Value);
                    }
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}