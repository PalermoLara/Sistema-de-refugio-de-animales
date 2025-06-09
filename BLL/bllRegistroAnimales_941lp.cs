using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ORM;
using System.Threading.Tasks;
using BE;

namespace BLL
{
    public class bllRegistroAnimales_941lp
    {
        ormRegistroAnimales_941lp orm_941lp;

        public bllRegistroAnimales_941lp()
        {
            orm_941lp = new ormRegistroAnimales_941lp();
        }

        public void AltaAnimal_941lp(string especie_941lp, string raza_941lp, string nombre_941lp, string tañamo_941lp, string sexo_941lp, string estadoDeAdopcion_941lp, bool vivo_941lp )
        {
            int codigoAnimal_941lp = orm_941lp.GenerarCodigoAnimalUnico_941lp();
            Animal_941lp animal_941lp = new Animal_941lp(codigoAnimal_941lp,especie_941lp, raza_941lp, nombre_941lp, tañamo_941lp, sexo_941lp, estadoDeAdopcion_941lp, vivo_941lp);
            orm_941lp.Alta_941lp(animal_941lp);
        }

        public void Modificar_941lp(string codigo_941lp ,string especie_941lp = null, string raza_941lp = null, string nombre_941lp = null, string tamaño_941lp = null, string sexo_941lp = null, string estadoDeAdopcion_941lp = null, bool? vivo_941lp = null)
        {
            Animal_941lp animal_941lp = BuscarAnimalPorCodigo_941lp(codigo_941lp);
            if (animal_941lp == null)
                throw new Exception("No se encontró un animal con el código proporcionado.");

            if (especie_941lp != null) animal_941lp.especie_941lp = especie_941lp;
            if (raza_941lp != null) animal_941lp.raza_941lp = raza_941lp;
            if (nombre_941lp != null) animal_941lp.nombre_941lp = nombre_941lp;
            if (tamaño_941lp != null) animal_941lp.tamaño_941lp = tamaño_941lp;
            if (sexo_941lp != null) animal_941lp.sexo_941lp = sexo_941lp;
            if (estadoDeAdopcion_941lp != null) animal_941lp.estadoAdopcion_941lp = estadoDeAdopcion_941lp;
            if(vivo_941lp != null) animal_941lp.vivo_941lp = vivo_941lp.Value;

            orm_941lp.Modificar_941lp(animal_941lp);
        }

        public bool ValidarExistenciaAnimal_941lp(string codigo_941lp)
        {
            return BuscarAnimalPorCodigo_941lp(codigo_941lp) != null;
        }

        public Animal_941lp BuscarAnimalPorCodigo_941lp(string codigo_941lp)
        {
            return orm_941lp.ObtenerAnimalPorCodigo_941lp(codigo_941lp);
        }

        public List<Animal_941lp> RetornarAnimales_941lp()
        {
            return orm_941lp.RetornarAnimal_941lp();
        }
    }
}
