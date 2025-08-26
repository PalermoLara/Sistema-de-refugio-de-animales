using ORM;
using SERVICIOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class bllBackUp_Restore_941lp
    {
        ormBackUp_Restore_941lp orm_941lp;
        bllBitacoraEventos_941lp bllBitacoraEventos_941lp;
        public bllBackUp_Restore_941lp()
        {
            orm_941lp = new ormBackUp_Restore_941lp();
            bllBitacoraEventos_941lp = new bllBitacoraEventos_941lp();
        }

        public string Backup_941lp()
        {
            bllBitacoraEventos_941lp.Alta_941lp(sessionManager941lp.Gestor_941lp.RetornarUsuarioSession_941lp().nombreUsuario_941lp, "Backup", "Backup realizado", 1);
            return orm_941lp.Backup_941lp();
        }

        public void RealizarRestore(string ruta_941lp)
        {
            bllBitacoraEventos_941lp.Alta_941lp(sessionManager941lp.Gestor_941lp.RetornarUsuarioSession_941lp().nombreUsuario_941lp, "Restore", "Restore Realizado", 1);
            orm_941lp.RealizarRestore_941lp(ruta_941lp);
        }
    }
}
