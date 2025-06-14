using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CuratorJournal.Desktop.ApiConnectors.Base
{
    public class BaseApiConnector
    {
        protected readonly HttpClient _httpClient;
        protected readonly string _baseUrl = "https://localhost:5001/api/";

        public BaseApiConnector()
        {
            _httpClient = new HttpClient();
        }

        protected async Task<T> GetAsync<T>(string endpoint)
        {
            var response = await _httpClient.GetAsync(_baseUrl + endpoint);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }

        protected async Task PostAsync<T>(string endpoint, T data)
        {
            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            await _httpClient.PostAsync(_baseUrl + endpoint, content);
        }

        protected async Task PutAsync<T>(string endpoint, T data)
        {
            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            await _httpClient.PutAsync(_baseUrl + endpoint, content);
        }

        protected async Task DeleteAsync(string endpoint)
        {
            await _httpClient.DeleteAsync(_baseUrl + endpoint);
        }
    }
}
