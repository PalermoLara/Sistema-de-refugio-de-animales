using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    internal class ParametroHelper_941lp
    {
        /// <summary>
        /// Crea un diccionario de parámetros a partir de las propiedades de una entidad.
        /// Si se especifica una lista de nombres de propiedades, solo esas se incluyen.
        /// </summary>
        /// <param name="entity_941lp">La entidad de la cual extraer propiedades.</param>
        /// <param name="propiedadesIncluir_941lp">Lista opcional de nombres de propiedades a incluir (en minúscula).</param>
        public static Dictionary<string, object> CrearParametros_941lp(object entity_941lp, List<string> propiedadesIncluir_941lp = null)
        {
            var parametros_941lp = new Dictionary<string, object>();

            foreach (var prop_941lp in entity_941lp.GetType().GetProperties())
            {
                string propName = prop_941lp.Name;

                // Si se pasó una lista de propiedades a incluir, y esta propiedad no está en la lista, la salteamos
                if (propiedadesIncluir_941lp != null && !propiedadesIncluir_941lp.Contains(propName))
                    continue;

                var nombreParametro = "@" + propName;
                var valor = prop_941lp.GetValue(entity_941lp) ?? DBNull.Value;

                parametros_941lp[nombreParametro] = valor;
            }

            return parametros_941lp;
            
        }

    }
}
