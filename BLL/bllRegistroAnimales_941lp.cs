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

        public void AltaAnimal_941lp(string especie_941lp, string raza_941lp, string nombre_941lp, string tañamo_941lp, string sexo_941lp, string estadoDeAdopcion_941lp )
        {
            Animal_941lp animal_941lp = new Animal_941lp(especie_941lp, raza_941lp, nombre_941lp, tañamo_941lp, sexo_941lp, estadoDeAdopcion_941lp);
            orm_941lp.Alta_941lp(animal_941lp);
        }

        public void Modificar_941lp(string codigo_941lp ,string especie_941lp, string raza_941lp, string nombre_941lp, string tañamo_941lp, string sexo_941lp, string estadoDeAdopcion_941lp)
        {
            Animal_941lp animal_941lp = BuscarAnimalPorCodigo_941lp(codigo_941lp);
            animal_941lp.especie_941lp = especie_941lp;
            animal_941lp.raza_941lp = raza_941lp;
            animal_941lp.nombre_941lp= nombre_941lp;
            animal_941lp.tamaño_941lp = tañamo_941lp;
            animal_941lp.sexo_941lp = sexo_941lp;
            animal_941lp.estadoAdopcion_941lp = estadoDeAdopcion_941lp;
            orm_941lp.Modificar_941lp(animal_941lp);
        }

        public Animal_941lp BuscarAnimalPorCodigo_941lp(string codigo_941lp)
        {
            return orm_941lp.ObtenerAnimalPorCodigo_941lp(codigo_941lp);
        }

        public List<Animal_941lp> RetornarAnimales()
        {
            return orm_941lp.RetornarAnimal_941lp();
        }
    }
}
