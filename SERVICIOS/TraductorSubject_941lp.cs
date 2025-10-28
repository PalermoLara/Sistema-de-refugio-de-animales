using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace SERVICIOS
{
    public class TraductorSubject_941lp
    {
        private static TraductorSubject_941lp instancia_941lp;
        private readonly List<IObserver_941lp> observadores_941lp = new List<IObserver_941lp>();
        private Dictionary<string, Dictionary<string, Dictionary<string, string>>> traducciones_941lp;

        private TraductorSubject_941lp()
        {
            CargarTraduccionesDesdeJson_941lp();
        }

        public static TraductorSubject_941lp Instancia_941lp
        {
            get
            {
                if (instancia_941lp == null)
                    instancia_941lp = new TraductorSubject_941lp();
                return instancia_941lp;
            }
        }

        private void CargarTraduccionesDesdeJson_941lp()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string appPath = Path.Combine(appDataPath, "WiskerWare");
            Directory.CreateDirectory(appPath); // Aseguramos que la carpeta exista
            string path_941lp = Path.Combine(appPath, "traducciones.json");

            // 2. 🔹 LÓGICA DE PRIMER ARRANQUE
            // Si el archivo no existe en AppData, lo copiamos desde la carpeta de instalación.
            if (!File.Exists(path_941lp))
            {
                string sourcePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "traducciones.json");
                if (File.Exists(sourcePath))
                {
                    File.Copy(sourcePath, path_941lp);
                }
            }

            // 3. 🔹 AHORA LEEMOS DESDE APPDATA
            if (File.Exists(path_941lp))
            {
                string json_941lp = File.ReadAllText(path_941lp);
                traducciones_941lp = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, Dictionary<string, string>>>>(json_941lp);
            }
            else
            {
                // Si no existe en ningún lado, empezamos con un diccionario vacío.
                traducciones_941lp = new Dictionary<string, Dictionary<string, Dictionary<string, string>>>();
                GuardarJson_941lp(); // Esto lo creará en la carpeta AppData gracias al cambio que ya hicimos en Guardar.
            }
        }

        private void GuardarJson_941lp()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string appPath = Path.Combine(appDataPath, "WiskerWare");
            Directory.CreateDirectory(appPath); // Nos aseguramos de que la carpeta exista

            string path_941lp = Path.Combine(appPath, "traducciones.json");

            // El resto de tu código no cambia.
            string json_941lp = JsonConvert.SerializeObject(traducciones_941lp, Formatting.Indented);
            File.WriteAllText(path_941lp, json_941lp);
        }

        public void Suscribir_941lp(IObserver_941lp observador_941lp)
        {
            if (!observadores_941lp.Contains(observador_941lp))
                observadores_941lp.Add(observador_941lp);
        }

        public void Desuscribir_941lp(IObserver_941lp observador_941lp)
        {
            observadores_941lp.Remove(observador_941lp);
        }

        public void Notificar_941lp(string idioma_941lp)
        {
            foreach (var obs in observadores_941lp)
                obs.ActualizarTraduccion_941lp(idioma_941lp);
        }

        public string Traducir_941lp(string formulario, string control, string idioma, string valorPorDefecto)
        {
            // 1. Verificar si existe el idioma
            if (!traducciones_941lp.ContainsKey(idioma))
            {
                traducciones_941lp[idioma] = new Dictionary<string, Dictionary<string, string>>();
            }

            // 2. Verificar si existe el formulario en este idioma
            if (!traducciones_941lp[idioma].ContainsKey(formulario))
            {
                // Si no existe el formulario, crear estructura completa
                traducciones_941lp[idioma][formulario] = new Dictionary<string, string>();
                traducciones_941lp[idioma][formulario][control] = valorPorDefecto;
                GuardarJson_941lp();
                return valorPorDefecto;
            }

            // 3. Si el formulario existe pero no el control específico
            if (!traducciones_941lp[idioma][formulario].ContainsKey(control))
            {
                // Agregar el control con valor por defecto solo para este formulario
                traducciones_941lp[idioma][formulario][control] = valorPorDefecto;
                GuardarJson_941lp();
                return valorPorDefecto;
            }

            // 4. Si existe tanto formulario como control, devolver la traducción existente
            return traducciones_941lp[idioma][formulario][control];
        }
    }
}
