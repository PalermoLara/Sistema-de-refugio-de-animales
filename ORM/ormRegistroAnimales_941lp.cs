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
    public class ormRegistroAnimales_941lp
    {
        dao_941lp dao_941lp;

        public ormRegistroAnimales_941lp()
        {
            dao_941lp = new dao_941lp();
        }

        public void Alta_941lp(Animal_941lp animal_941lp)
        {
            string query_941lp = "INSERT INTO Animal_941lp " +
                         "(codigoAnimal_941lp, especie_941lp, raza_941lp, nombre_941lp, tamaño_941lp, sexo_941lp, estadoAdopcion_941lp, vivo_941lp) " +
                         "VALUES (@codigoAnimal_941lp, @especie_941lp, @raza_941lp, @nombre_941lp, @tamaño_941lp,@sexo_941lp, @estadoAdopcion_941lp, @vivo_941lp)";
            EjecutarQueryConEntidad_941lp(animal_941lp, query_941lp);
        }

        public int GenerarCodigoAnimalUnico_941lp()
        {
            Random random_941lp = new Random();
            int codigo_941lp;
            bool existe_941lp;
            do
            {
                codigo_941lp = random_941lp.Next(10000, 99999); // 5 dígitos
                string query_941lp = "SELECT COUNT(*) FROM Animal_941lp WHERE codigoAnimal_941lp = @codigoAnimal_941lp";
                var parametros_941lp = new Dictionary<string, object> { { "@codigoAnimal_941lp", codigo_941lp } };
                object resultado_941lp = dao_941lp.EjecutarEscalar_941lp(query_941lp, parametros_941lp);
                existe_941lp = Convert.ToInt32(resultado_941lp) > 0;
            }
            while (existe_941lp);
            return codigo_941lp;
        }

        public void Modificar_941lp(Animal_941lp animal_941lp)
        {
            string query_941lp = "UPDATE Animal_941lp SET especie_941lp = @especie_941lp, raza_941lp = @raza_941lp,nombre_941lp = @nombre_941lp, tamaño_941lp = @tamaño_941lp, sexo_941lp = @sexo_941lp, estadoAdopcion_941lp = @estadoAdopcion_941lp, vivo_941lp = @vivo_941lp" +
                " WHERE codigoAnimal_941lp = @codigoAnimal_941lp";
            var propiedadesAIncluir = new List<string>
            {
                "especie_941lp",
                "raza_941lp",
                "nombre_941lp",
                "tamaño_941lp",
                "sexo_941lp",
                "estadoAdopcion_941lp",
                "vivo_941lp",
                "codigoAnimal_941lp"
            };
            EjecutarQueryConEntidad_941lp(animal_941lp, query_941lp, propiedadesAIncluir);
        }

        private void EjecutarQueryConEntidad_941lp(Animal_941lp animal_941lp, string query_941lp, List<string> propiedadesIncluir_941lp = null)
        {
            Dictionary<string, object> parametros_941lp = ParametroHelper_941lp.CrearParametros_941lp(animal_941lp, propiedadesIncluir_941lp);
            dao_941lp.Query_941lp(query_941lp, parametros_941lp);
        }

        public Animal_941lp ObtenerAnimalPorCodigo_941lp(string codigo_941lp)
        {
            string query_941lp = "SELECT * FROM Animal_941lp WHERE codigoAnimal_941lp = @codigoAnimal_941lp";
            var parametros_941lp = new Dictionary<string, object>
            {
                { "@codigoAnimal_941lp", codigo_941lp }
            };
            var animales_941lp = dao_941lp.RetornarLista_941lp(query_941lp, MapearAnimal, parametros_941lp);
            return animales_941lp.FirstOrDefault();
        }

        public List<Animal_941lp> RetornarAnimal_941lp()
        {
            List<Animal_941lp> animal_941lp = dao_941lp.RetornarLista_941lp("SELECT * FROM Animal_941lp", MapearAnimal);
            return animal_941lp;
        }

        private Animal_941lp MapearAnimal(SqlDataReader reader)
        {
            return new Animal_941lp(

                Convert.ToInt32(reader["codigoAnimal_941lp"]),
                reader["especie_941lp"].ToString(),
                reader["raza_941lp"].ToString(),
                reader["nombre_941lp"].ToString(),
                reader["tamaño_941lp"].ToString(),
                reader["sexo_941lp"].ToString(),
                reader["estadoAdopcion_941lp"].ToString(),
                Convert.ToBoolean(reader["vivo_941lp"])
            );
        }
    }
}
