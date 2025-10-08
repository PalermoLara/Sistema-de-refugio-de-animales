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
    public class ormBitacoraCambios_941lp
    {
        dao_941lp dao_941lp;

        public ormBitacoraCambios_941lp()
        {
            dao_941lp = new dao_941lp();
        }

        public List<BitacoraCambio_941lp> Filtros_941lp(Dictionary<string, object> filtros_941lp)
        {
            string query_941lp = "SELECT * FROM BitacoraCambios_941lp";
            Dictionary<string, object> parametros_941lp = new Dictionary<string, object>();
            List<string> condiciones_941lp = new List<string>();

            foreach (var filtro_941lp in filtros_941lp)
            {
                string nombreParametro_941lp = "@" + filtro_941lp.Key;

                switch (filtro_941lp.Key)
                {
                    case "codMedicamento_941lp":
                        condiciones_941lp.Add($"{filtro_941lp.Key} = {nombreParametro_941lp}");
                        parametros_941lp.Add(nombreParametro_941lp, filtro_941lp.Value);
                        break;

                    case "nombreComercial_941lp":
                        condiciones_941lp.Add($"{filtro_941lp.Key} = {nombreParametro_941lp}");
                        parametros_941lp.Add(nombreParametro_941lp, filtro_941lp.Value);
                        break;

                    case "fechaInicio_941lp":
                        condiciones_941lp.Add("fechaHora_941lp >= @fechaInicio_941lp");
                        parametros_941lp.Add("@fechaInicio_941lp", Convert.ToDateTime(filtro_941lp.Value));
                        break;

                    case "fechaFin_941lp":
                        condiciones_941lp.Add("fechaHora_941lp <= @fechaFin_941lp");
                        DateTime fechaFin = Convert.ToDateTime(filtro_941lp.Value).AddDays(1).AddSeconds(-1);
                        parametros_941lp.Add("@fechaFin_941lp", fechaFin);
                        break;

                    default:
                        condiciones_941lp.Add($"{filtro_941lp.Key} = {nombreParametro_941lp}");
                        parametros_941lp.Add(nombreParametro_941lp, filtro_941lp.Value);
                        break;
                }
            }

            if (condiciones_941lp.Count > 0)
            {
                query_941lp += " WHERE " + string.Join(" AND ", condiciones_941lp);
            }

            return dao_941lp.RetornarLista_941lp(query_941lp, MapearCambio_941lp, parametros_941lp);
        }

        
        public void RollbackMedicamento_941lp(string codigoMedicamento, DateTime fechaElegida)
        {
            string sql = @"
                BEGIN TRANSACTION;
            
                -- 1️⃣ Buscar fecha exacta (manejo más flexible de fechas)
                DECLARE @fechaExacta DATETIME;
                SELECT TOP 1 @fechaExacta = fechaHora_941lp
                FROM BitacoraCambios_941lp
                WHERE codMedicamento_941lp = @codigo
                    AND CAST(fechaHora_941lp AS DATE) = CAST(@fecha AS DATE)
                ORDER BY ABS(DATEDIFF(SECOND, fechaHora_941lp, @fecha)) ASC;

                IF @fechaExacta IS NOT NULL
                BEGIN
                    -- 2️⃣ Desactivar TODOS los registros de este medicamento
                    UPDATE BitacoraCambios_941lp
                    SET activo_941lp = 0
                    WHERE codMedicamento_941lp = @codigo;

                    -- 3️⃣ Activar la versión histórica seleccionada
                    UPDATE BitacoraCambios_941lp
                    SET activo_941lp = 1
                    WHERE codMedicamento_941lp = @codigo 
                        AND fechaHora_941lp = @fechaExacta;

                    -- 4️⃣ Forzar un UPDATE en Medicamento_941lp para que el trigger 
                    --    (con CONTEXT_INFO) sincronice los datos SIN crear nuevo registro
                    UPDATE Medicamento_941lp 
                    SET nombreComercial_941lp = nombreComercial_941lp
                    WHERE numeroOficial_941lp = @codigo;
                END
            
                COMMIT TRANSACTION;
            ";

            // ✅ Este método YA configura el CONTEXT_INFO automáticamente
            dao_941lp.EjecutarRollBack_941lp(sql, new Dictionary<string, object>
            {
                { "@codigo", codigoMedicamento },
                { "@fecha", fechaElegida }
            });
        }

        

        public List<BitacoraCambio_941lp> RetornarCambios_941lp()
        {
            List<BitacoraCambio_941lp> cambio_941lp = dao_941lp.RetornarLista_941lp("SELECT * FROM BitacoraCambios_941lp", MapearCambio_941lp);
            return cambio_941lp;
        }

        private BitacoraCambio_941lp MapearCambio_941lp(SqlDataReader reader)
        {
            return new BitacoraCambio_941lp(
                reader["codMedicamento_941lp"].ToString(),
                Convert.ToDateTime(reader["fechaHora_941lp"]),
                reader["nombreComercial_941lp"].ToString(),
                reader["nombreGenerico_941lp"].ToString(),
                reader["forma_941lp"].ToString(),
                Convert.ToDateTime(reader["caducidad_941lp"]),
                 Convert.ToBoolean(reader["activoMedicamento_941lp"]),
                Convert.ToBoolean(reader["activo_941lp"])
            );
        }
    }
}
