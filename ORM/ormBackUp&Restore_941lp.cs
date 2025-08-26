using DAO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ORM
{
    public class ormBackUp_Restore_941lp
    {
        dao_941lp dao_941lp;

        public ormBackUp_Restore_941lp()
        {
            dao_941lp = new dao_941lp();
        }

        string basededatos_941lp = "sistAdopcion941lp";
        
        public string Backup_941lp()
        {
            string backupPath = @"C:\BackUp"; 
            Directory.CreateDirectory(backupPath);
            string fileName = $"backUp_sistAdopcion941lp_{DateTime.Now:ddMMyy-HHmm}.WW.bak";
            string rutaCompleta = Path.Combine(backupPath, fileName);

            string query = $@"
            BACKUP DATABASE [sistAdopcion941lp]
            TO DISK = '{rutaCompleta}'
            WITH FORMAT, INIT, NAME = 'Backup_{fileName}';
            ";
            dao_941lp.Query_941lp(query);
            return rutaCompleta;
        }

        public void RealizarRestore_941lp(string ruta_941lp)
        {
            try
            {
                dao_941lp.RestaurarBaseDatos_941lp(basededatos_941lp, ruta_941lp);
            }
            catch (Exception ex){ MessageBox.Show( ex.Message);}
        }
    }
}
