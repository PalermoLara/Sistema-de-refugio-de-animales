using BE;
using ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class bllMedicamento_941lp
    {
        ormMedicamento_941lp orm_941Lp;

        public bllMedicamento_941lp()
        {
            orm_941Lp = new ormMedicamento_941lp();
        }

        public void Alta_941lp(string numero_941lp, string nombreComercial_941lp, string nombreGenerico_941lp, string forma_941lp, string amnimalDestina_941llp, DateTime caducidad_941lp)
        {
            DateTime soloFecha_941lp = caducidad_941lp.Date;
            Medicamento_941lp medicamento_941lp = new Medicamento_941lp(numero_941lp, nombreComercial_941lp, nombreGenerico_941lp, forma_941lp, amnimalDestina_941llp, soloFecha_941lp);
            orm_941Lp.Alta_941lp(medicamento_941lp);
        }

        public void Modificar_941lp(string numero_941lp, string nombreComercial_941lp, string nombreGenerico_941lp, string forma_941lp, string amnimalDestina_941llp, DateTime caducidad_941lp)
        {
            Medicamento_941lp medicamento_941 = BuscarPorNumero(numero_941lp);
            medicamento_941.nombreComercial_941lp = nombreComercial_941lp;
            medicamento_941.nombreGenerico_941lp = nombreGenerico_941lp;
            medicamento_941.forma_941lp = forma_941lp;
            medicamento_941.animalDestinado_941lp = amnimalDestina_941llp;
            medicamento_941.caducidad_941lp = caducidad_941lp;
            orm_941Lp.Modificar_941lp(medicamento_941);
        }

        public List<Medicamento_941lp> Ordenar_941lp(string tipo_941lp)
        {
            List<Medicamento_941lp> listaOrdenada_941lp = RetornarMedicamento_941lp();
            if(tipo_941lp == "Ascendente")
            {
                listaOrdenada_941lp = listaOrdenada_941lp.OrderBy(x => x.nombreGenerico_941lp).ToList();
            }
            else
            {
                listaOrdenada_941lp = listaOrdenada_941lp.OrderByDescending(x => x.nombreGenerico_941lp).ToList();
            }
            return listaOrdenada_941lp;
        }

        public void Baja_941lp(string numero_941lp)
        {
            orm_941Lp.Eliminar_941lp(numero_941lp);
        }

        private Medicamento_941lp BuscarPorNumero(string numero_941lp)
        {
            return orm_941Lp.RetornarMedicamento_941lp().Find(x => x.numeroOficial_941lp == numero_941lp);
        }

        public List<Medicamento_941lp> RetornarMedicamento_941lp()
        {
            return orm_941Lp.RetornarMedicamento_941lp();
        }
    }
}
