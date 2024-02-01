using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_Series_Bureau.Models;

namespace TP2_Series_Bureau.Services
{
    public class WSSerieService : ISerieService
    {
        private const string UriOfApi = "https://apiseriescordellp.azurewebsites.net/api/";
        private HttpClient _httpClient;

        public WSSerieService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(UriOfApi);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<Serie>?> GetSeriesAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Serie>>("series");
            }
            catch (Exception)
            {
                return default;
            }
        }

        public Task<Serie?> GetSerieAsync()
        {
            throw new NotImplementedException();
        }

        public Task PutSerieAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Serie?> PostSerieAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteSerieAsync()
        {
            throw new NotImplementedException();
        }
    }
}
