using AppFPF.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using static Newtonsoft.Json.JsonConvert;

namespace AppFPF.Service
{
    public class APIService
    {
        private const string baseUri = "http://servicexamarin.azurewebsites.net/api/{0}";

        #region SpecificMethods

        public async static Task<Team> GetTeam()
        {
            var relativeUri = "seleccion";
            return await GetApi<Team>(relativeUri);
        }

        public async static Task<Player> GetPlayer(int id)
        {
            var relativeUri = $"seleccion/{id}";
            return await GetApi<Player>(relativeUri);
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