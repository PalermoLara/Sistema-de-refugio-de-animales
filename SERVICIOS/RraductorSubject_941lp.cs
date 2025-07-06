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
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "traducciones.json");

            if (!File.Exists(path))
            {
                traducciones_941lp = new Dictionary<string, Dictionary<string, Dictionary<string, string>>>();
                GuardarJson_941lp();
            }
            else
            {
                string json = File.ReadAllText(path);
                traducciones_941lp = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, Dictionary<string, string>>>>(json);
            }
        }

        private void GuardarJson_941lp()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "traducciones.json");
            string json = JsonConvert.SerializeObject(traducciones_941lp, Formatting.Indented);
            File.WriteAllText(path, json);
        }

        public void Suscribir_941lp(IObserver_941lp observador)
        {
            if (!observadores_941lp.Contains(observador))
                observadores_941lp.Add(observador);
        }

        public void Desuscribir_941lp(IObserver_941lp observador)
        {
            observadores_941lp.Remove(observador);
        }

        public void Notificar_941lp(string idioma)
        {
            foreach (var obs in observadores_941lp)
                obs.ActualizarTraduccion_941lp(idioma);
        }

        public string Traducir_941lp(string formulario, string controlName, string idioma, string valorPorDefecto)
        {
            if (!traducciones_941lp.ContainsKey(idioma))
                traducciones_941lp[idioma] = new Dictionary<string, Dictionary<string, string>>();

            if (!traducciones_941lp[idioma].ContainsKey(formulario))
                traducciones_941lp[idioma][formulario] = new Dictionary<string, string>();

            var controles = traducciones_941lp[idioma][formulario];

            if (!controles.ContainsKey(controlName))
            {
                controles[controlName] = valorPorDefecto;
                GuardarJson_941lp();
            }

            return controles[controlName];
        }
    }
}
