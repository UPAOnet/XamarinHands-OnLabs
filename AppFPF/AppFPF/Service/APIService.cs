using AppFPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static Newtonsoft.Json.JsonConvert;

namespace AppFPF.Service
{
    public class APIService
    {
        const string baseUri = "http://servicexamarin.azurewebsites.net/api/{0}";

        #region SpecificMethods

        public async static Task<Equipo> GetTeam()
        {
            var relativeUri = "seleccion";
            return await GetApi<Equipo>(relativeUri);
        }

        public async static Task<Jugador> GetPlayer(int id)
        {
            var relativeUri = $"seleccion/{id}";
            return await GetApi<Jugador>(relativeUri);
        }

        #endregion SpecificMethods

        #region GenericMethod

        private static async Task<TResult> GetApi<TResult>(string relativeUri)
        {
            using (var client = new HttpClient())
            {
                var url = String.Format(baseUri, relativeUri);
                var json = await client.GetStringAsync(url);

                if (String.IsNullOrEmpty(json))
                    return default(TResult);

                return DeserializeObject<TResult>(json);
            }
        }

        #endregion GenericMethod
    }
}
