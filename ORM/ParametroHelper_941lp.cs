using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    internal class ParametroHelper_941lp
    {
        // Método estático que recibe cualquier entidad y devuelve un diccionario con los parámetros para una consulta SQL.
        public static Dictionary<string, object> CrearParametros_941lp(object entity_941lp)
        {
            // Se crea un diccionario para almacenar los parámetros, donde la clave será el nombre del parámetro
            // (ej. @nombre, @email) y el valor será el valor de la propiedad correspondiente del objeto.
            var parametros_941lp = new Dictionary<string, object>();

            // Recorre todas las propiedades del objeto recibido como parámetro.
            foreach (var prop_941lp in entity_941lp.GetType().GetProperties())
            {
                // Crea el nombre del parámetro SQL, que será @propName (por ejemplo, @nombre, @email, etc.)
                var propName_941lp = "@" + prop_941lp.Name.ToLower();

                // Obtiene el valor de la propiedad en el objeto actual.
                var propValue_941lp = prop_941lp.GetValue(entity_941lp);

                // Se agrega al diccionario el nombre del parámetro y su valor, o DBNull.Value si el valor es null.
                // Esto es útil para evitar problemas con valores null en las consultas SQL.
                parametros_941lp.Add(propName_941lp, propValue_941lp ?? DBNull.Value);
            }

            // Devuelve el diccionario con todos los parámetros de la entidad.
            return parametros_941lp;
        }
    }
}
