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
    public class bllMedicamento_941lp
    {
        ormMedicamento_941lp orm_941Lp;
        bllBitacoraEventos_941lp bllBitacoraEvento_941lp;
        public bllMedicamento_941lp()
        {
            orm_941Lp = new ormMedicamento_941lp();
            bllBitacoraEvento_941lp = new bllBitacoraEventos_941lp();
        }

        public void Alta_941lp(string numero_941lp, string nombreComercial_941lp, string nombreGenerico_941lp, string forma_941lp,  DateTime caducidad_941lp)
        {
            DateTime soloFecha_941lp = caducidad_941lp.Date;
            Medicamento_941lp medicamento_941lp = new Medicamento_941lp(numero_941lp, nombreComercial_941lp, nombreGenerico_941lp, forma_941lp, soloFecha_941lp);
            orm_941Lp.Alta_941lp(medicamento_941lp);
            bllBitacoraEvento_941lp.Alta_941lp(sessionManager941lp.Gestor_941lp.RetornarUsuarioSession_941lp().dni_941lp, "Gestion medicamentos", "Alta medicamento", 5);
        }

        public void Modificar_941lp(string numero_941lp, string nombreComercial_941lp, string nombreGenerico_941lp, string forma_941lp,  DateTime caducidad_941lp)
        {
            Medicamento_941lp medicamento_941 = BuscarPorNumero_941lp(numero_941lp);
            medicamento_941.nombreComercial_941lp = nombreComercial_941lp;
            medicamento_941.nombreGenerico_941lp = nombreGenerico_941lp;
            medicamento_941.forma_941lp = forma_941lp;
            medicamento_941.caducidad_941lp = caducidad_941lp;
            orm_941Lp.Modificar_941lp(medicamento_941);
            bllBitacoraEvento_941lp.Alta_941lp(sessionManager941lp.Gestor_941lp.RetornarUsuarioSession_941lp().dni_941lp, "Gestion medicamentos", "Modificar medicamento", 5);
        }

        public bool VerificarExistenciaDeNumero_941lp(string numero_941lp)
        {
            return orm_941Lp.VerificarExistenciaDeNumero_941lp(numero_941lp);
        }

        public bool VencimientoDeProducto_941lp(DateTime caducidad_941lp)
        {
            return caducidad_941lp.Date < DateTime.Now.Date;
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
            bllBitacoraEvento_941lp.Alta_941lp(sessionManager941lp.Gestor_941lp.RetornarUsuarioSession_941lp().dni_941lp, "Gestion medicamentos", "Eliminar medicamento", 5);
        }

        private Medicamento_941lp BuscarPorNumero_941lp(string numero_941lp)
        {
            return orm_941Lp.RetornarMedicamento_941lp().Find(x => x.numeroOficial_941lp == numero_941lp);
        }

        public List<Medicamento_941lp> RetornarMedicamento_941lp()
        {
            return orm_941Lp.RetornarMedicamento_941lp();
        }
    }
}
