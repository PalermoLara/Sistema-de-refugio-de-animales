using BE;
using ORM;
using SERVICIOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class bllRegistroAnimales_941lp
    {
        ormRegistroAnimales_941lp orm_941lp;
        bllBitacoraEventos_941lp bllBitacoraEvento_941lp;

        public bllRegistroAnimales_941lp()
        {
            orm_941lp = new ormRegistroAnimales_941lp();
            bllBitacoraEvento_941lp = new bllBitacoraEventos_941lp();
        }

        public void AltaAnimal_941lp(string especie_941lp, string raza_941lp, string nombre_941lp, string tañamo_941lp, string sexo_941lp, string estadoDeAdopcion_941lp, bool vivo_941lp )
        {
            int codigoAnimal_941lp = orm_941lp.GenerarCodigoAnimalUnico_941lp();
            Animal_941lp animal_941lp = new Animal_941lp(codigoAnimal_941lp,especie_941lp, raza_941lp, nombre_941lp, tañamo_941lp, sexo_941lp, estadoDeAdopcion_941lp, vivo_941lp);
            orm_941lp.Alta_941lp(animal_941lp);
            bllBitacoraEvento_941lp.Alta_941lp(sessionManager941lp.Gestor_941lp.RetornarUsuarioSession_941lp().dni_941lp, "Gestion animales", "Animal dado de alta", 2);
        }

        public void Modificar_941lp(string codigo_941lp ,string especie_941lp = null, string raza_941lp = null, string nombre_941lp = null, string tamaño_941lp = null, string sexo_941lp = null, string estadoDeAdopcion_941lp = null, bool? vivo_941lp = null)
        {
            Animal_941lp animal_941lp = BuscarAnimalPorCodigo_941lp(codigo_941lp);
            if (animal_941lp == null)
            {
                string excepcion_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormRegistroAnimales_941lp", "MSG_ANIMAL_NO_ENCONTRADO", "No se encontró un animal con el código proporcionado.");
                throw new Exception(excepcion_941lp);
            }

            if (especie_941lp != null) animal_941lp.especie_941lp = especie_941lp;
            if (raza_941lp != null) animal_941lp.raza_941lp = raza_941lp;
            if (nombre_941lp != null) animal_941lp.nombre_941lp = nombre_941lp;
            if (tamaño_941lp != null) animal_941lp.tamaño_941lp = tamaño_941lp;
            if (sexo_941lp != null) animal_941lp.sexo_941lp = sexo_941lp;
            if (estadoDeAdopcion_941lp != null) animal_941lp.estadoAdopcion_941lp = estadoDeAdopcion_941lp;
            if (vivo_941lp != null)
            {  
                animal_941lp.vivo_941lp = vivo_941lp.Value;
                bllBitacoraEvento_941lp.Alta_941lp(sessionManager941lp.Gestor_941lp.RetornarUsuarioSession_941lp().dni_941lp, "Gestion animales", "Animal dado de baja", 2);
            }
            else
            {
                bllBitacoraEvento_941lp.Alta_941lp(sessionManager941lp.Gestor_941lp.RetornarUsuarioSession_941lp().dni_941lp, "Gestion animales", "Animal modificado", 2);
            }

                orm_941lp.Modificar_941lp(animal_941lp);
        }

        public bool ValidarExistenciaAnimal_941lp(string codigo_941lp)
        {
            return BuscarAnimalPorCodigo_941lp(codigo_941lp) != null;
        }

        public bool VerificarAnimalAdoptado_941lp(string codigo_941lp)
        {
            return BuscarAnimalPorCodigo_941lp(codigo_941lp).estadoAdopcion_941lp == "Adoptado";
        }

        public string RetornarEstadoDelAnimal_941lp(string codigo_941lp)
        {
            return BuscarAnimalPorCodigo_941lp(codigo_941lp).estadoAdopcion_941lp;
        }

        public bool VerificarAnimalVivo_941lp(string codigo_941lp)
        {
            return BuscarAnimalPorCodigo_941lp(codigo_941lp).vivo_941lp;
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
