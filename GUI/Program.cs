using SERVICIOS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string appPath = Path.Combine(appDataPath, "WiskerWare");
            Directory.CreateDirectory(appPath); // Asegura que la carpeta exista

            AppDomain.CurrentDomain.SetData("DataDirectory", appPath);
            // === FIN DEL CÓDIGO NUEVO ===


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            GestorFormulario941lp.gestorFormSG_941lp.DefinirEstado_941lp(new EstadoLogIn941lp());
        }
    }
}
