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
        
        public void Backup_941lp(string rutaBackUp_941lp)
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
        }

        public void RealizarRestore(string backupRuta_941lp)
        {
            try
            {
                string useMaster_941lp = "USE master;";
                dao_941lp.Query_941lp(useMaster_941lp);

                string setSingleUser_941lp = $@"ALTER DATABASE [{basededatos_941lp}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;";
                dao_941lp.Query_941lp(setSingleUser_941lp);

                string restoreQuery_941lp = $@" RESTORE DATABASE [{basededatos_941lp}] FROM DISK = @ruta  WITH REPLACE;";
                dao_941lp.Query_941lp(restoreQuery_941lp, new Dictionary<string, object>
                {
                    {"@ruta", backupRuta_941lp}
                });

                string setMultiUser_941lp = $@"ALTER DATABASE [{basededatos_941lp}] SET MULTI_USER;";
                dao_941lp.Query_941lp(setMultiUser_941lp);
            }
            catch (Exception ex){ MessageBox.Show( ex.Message);}
        }
    }
}
