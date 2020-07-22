using Common;
using Domain.Bing;
using Services.Config;
using Services.Interface;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class EngineSearchBing:IEngineSearch
    {
        public string Name => "Bing";
        private HttpClient _client { get; }
        public EngineSearchBing()
        {
            _client = new HttpClient();      
        }
        public async Task<long> GetTotalResults(string query)
        {
            if (string.IsNullOrEmpty(query))
                throw new ArgumentException("Error en el parametro", nameof(query));

            string searchRequest = ConfigBing.BaseUrl.Replace("{Query}", query);
            searchRequest = searchRequest + "&customconfig="+ConfigBing.CustomKey;
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Ocp-Apim-Subscription-Key", "=" + ConfigBing.ApiKey);

            using (var response = await _client.GetAsync(searchRequest))
            {
                if (!response.IsSuccessStatusCode)
                    throw new Exception("No es posible realizar la consulta");

                ResponseBing results = JsonHelper.Deserialize<ResponseBing>(await response.Content.ReadAsStringAsync());
                return long.Parse(results.WebPages.TotalEstimatedMatches);
            }
        }
    }
}
