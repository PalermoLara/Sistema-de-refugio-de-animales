using ORM;
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
        public bllBackUp_Restore_941lp()
        {
            orm_941lp = new ormBackUp_Restore_941lp();
        }

        public string Backup_941lp()
        {
            return orm_941lp.Backup_941lp();
        }

        public void RealizarRestore(string ruta_941lp)
        {
           orm_941lp.RealizarRestore_941lp(ruta_941lp);
        }
    }
}
