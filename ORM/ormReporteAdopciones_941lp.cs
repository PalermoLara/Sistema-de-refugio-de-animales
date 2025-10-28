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
    public class ormReporteAdopciones_941lp
    {
        private readonly dao_941lp dao_941lp;

        public ormReporteAdopciones_941lp()
        {
            dao_941lp = new dao_941lp();
        }

        public List<ReporteMensualAdopciones_941lp> ObtenerReporteMensual_941lp()
        {
            string query_941lp = @"
                SELECT 
                    ISNULL(i.Año, a.Año) AS Año,
                    ISNULL(i.Mes, a.Mes) AS Mes,
                    ISNULL(i.CantidadIngresos, 0) AS Ingresos,
                    ISNULL(a.CantidadAdopciones, 0) AS Adopciones,
                    CASE 
                        WHEN ISNULL(i.CantidadIngresos, 0) = 0 THEN 0
                        ELSE ROUND((CAST(a.CantidadAdopciones AS FLOAT) / i.CantidadIngresos) * 100, 2)
                    END AS Porcentaje
                FROM
                    (SELECT YEAR(f.fecha_941lp) AS Año, MONTH(f.fecha_941lp) AS Mes, COUNT(*) AS CantidadIngresos
                     FROM FichaDeIngreso_941lp f
                     GROUP BY YEAR(f.fecha_941lp), MONTH(f.fecha_941lp)) i
                FULL JOIN
                    (SELECT YEAR(c.fecha_941lp) AS Año, MONTH(c.fecha_941lp) AS Mes, COUNT(*) AS CantidadAdopciones
                     FROM CertificadoAdopcion_941lp c
                     GROUP BY YEAR(c.fecha_941lp), MONTH(c.fecha_941lp)) a
                ON i.Año = a.Año AND i.Mes = a.Mes
                ORDER BY Año, Mes;";

            return dao_941lp.RetornarLista_941lp(query_941lp, Mapear_941lp);
        }

        public List<(string Especie, int Cantidad)> ObtenerAdopcionesPorEspecie_941lp()
        {
            string query_941lp = @"
            SELECT especie_941lp AS Especie, COUNT(*) AS Cantidad
            FROM CertificadoAdopcion_941lp
            GROUP BY especie_941lp
            ORDER BY Cantidad DESC";

            return dao_941lp.RetornarLista_941lp(query_941lp, reader_941lp =>
                (reader_941lp["Especie"].ToString(),
                 Convert.ToInt32(reader_941lp["Cantidad"]))
            );
        }


        private ReporteMensualAdopciones_941lp Mapear_941lp(SqlDataReader reader_941lp)
        {
            return new ReporteMensualAdopciones_941lp
            {
                Año_941lp = reader_941lp["Año"] != DBNull.Value ? Convert.ToInt32(reader_941lp["Año"]) : 0,
                Mes_941lp = reader_941lp["Mes"] != DBNull.Value ? Convert.ToInt32(reader_941lp["Mes"]) : 0,
                Ingresos_941lp = reader_941lp["Ingresos"] != DBNull.Value ? Convert.ToInt32(reader_941lp["Ingresos"]) : 0,
                Adopciones_941lp = reader_941lp["Adopciones"] != DBNull.Value ? Convert.ToInt32(reader_941lp["Adopciones"]) : 0,
                Porcentaje_941lp = reader_941lp["Porcentaje"] != DBNull.Value ? Convert.ToDouble(reader_941lp["Porcentaje"]) : 0
            };
        }

    }
}
