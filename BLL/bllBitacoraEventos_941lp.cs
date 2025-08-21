using BE;
using ORM;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BLL
{
    public class bllBitacoraEventos_941lp
    {
        ormBitacoraEventos_941lp orm_941lp;
        public bllBitacoraEventos_941lp()
        {
            orm_941lp = new ormBitacoraEventos_941lp();
        }

        public void Alta_941lp(string login_941lp, string modulo_941lp,string evento_941lp, int criticidad_941lp)
        {
            try
            {
                Evento_941lp nuevoEvento_941lp = new Evento_941lp(login_941lp,DateTime.Now.Date, DateTime.Now.TimeOfDay,modulo_941lp, evento_941lp, criticidad_941lp);
                orm_941lp.Alta_941lp(nuevoEvento_941lp);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public List<Evento_941lp> Filtros_941lp(Dictionary<string, string> filtros_941lp)
        {
            return orm_941lp.Filtros_941lp(filtros_941lp);
        }

        public List<Evento_941lp> RetornarEventos_941lp()
        {
            List<Evento_941lp> aux_941lp = new List<Evento_941lp>();
            foreach (Evento_941lp c_941lp in orm_941lp.RetornarEventos_941lp())
            {
                aux_941lp.Add(new Evento_941lp(c_941lp.codigo_941lp,c_941lp.login_941lp, c_941lp.fecha_941lp, c_941lp.hora_941lp, c_941lp.modulo_941lp, c_941lp.evento_941lp, c_941lp.criticidad_941lp));
            }
            return aux_941lp;
        }
    }
}
