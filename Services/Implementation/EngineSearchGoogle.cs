using Common;
using Domain.Google;
using Services.Config;
using Services.Interface;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class EngineSearchGoogle : IEngineSearch
    {
        public string Name => "Bing";
        private HttpClient _client { get; }
        public EngineSearchGoogle()
        {
            _client = new HttpClient();
        }
        public async Task<long> GetTotalResults(string query)
        {
            if (string.IsNullOrEmpty(query))
                throw new ArgumentException("Error en el parametro", nameof(query));

            string searchRequest = ConfigGoogle.BaseUrl.Replace("{Key}", ConfigGoogle.ApiKey)
                .Replace("{Context}", ConfigGoogle.ContextId)
                .Replace("{Query}", query);

            using (var response = await _client.GetAsync(searchRequest))
            {
                if (!response.IsSuccessStatusCode)
                    throw new Exception("No es posible realizar la consulta");

                ResponseGoogle results = JsonHelper.Deserialize<ResponseGoogle>(await response.Content.ReadAsStringAsync());
                return long.Parse(results.SearchInformation.TotalResults);
            }
        }
    }
}
