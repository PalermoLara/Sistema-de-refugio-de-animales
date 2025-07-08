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
            string path_941lp = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "traducciones.json");

            if (!File.Exists(path_941lp))
            {
                traducciones_941lp = new Dictionary<string, Dictionary<string, Dictionary<string, string>>>();
                GuardarJson_941lp();
            }
            else
            {
                string json_941lp = File.ReadAllText(path_941lp);
                traducciones_941lp = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, Dictionary<string, string>>>>(json_941lp);
            }
        }

        private void GuardarJson_941lp()
        {
            string path_941lp = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "traducciones.json");
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

        public string Traducir_941lp(string formulario_941lp, string controlName_941lp, string idioma_941lp, string valorPorDefecto_941lp)
        {
            if (!traducciones_941lp.ContainsKey(idioma_941lp))
                traducciones_941lp[idioma_941lp] = new Dictionary<string, Dictionary<string, string>>();

            if (!traducciones_941lp[idioma_941lp].ContainsKey(formulario_941lp))
                traducciones_941lp[idioma_941lp][formulario_941lp] = new Dictionary<string, string>();

            var controles_941lp = traducciones_941lp[idioma_941lp][formulario_941lp];

            if (!controles_941lp.ContainsKey(controlName_941lp))
            {
                controles_941lp[controlName_941lp] = valorPorDefecto_941lp;
                GuardarJson_941lp();
            }

            return controles_941lp[controlName_941lp];
        }
    }
}
