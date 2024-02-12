using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_Series_Bureau.Models;
using Windows.Web.Http.Diagnostics;
using System.Net;
using Windows.Services.Maps;

namespace TP2_Series_Bureau.Services
{
    public class WSSerieService : ISerieService
    {
        private const string UriOfApi = "https://apiseriescordellp.azurewebsites.net/api/series";
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
                return await _httpClient.GetFromJsonAsync<List<Serie>>(UriOfApi);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Serie?> GetSerieAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Serie>(UriOfApi + "/" + id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task PutSerieAsync(int id, Serie serie)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync(UriOfApi + "/" + id, serie);
            response.EnsureSuccessStatusCode();
        }
        
        public async Task PostSerieAsync(Serie serie)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(UriOfApi, serie);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteSerieAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync(UriOfApi + "/" + id);

            if (response.StatusCode == HttpStatusCode.NotFound)
                throw new Exception("L'identifiant ID n'appartient à aucune série.");

            response.EnsureSuccessStatusCode();
        }
    }
}
