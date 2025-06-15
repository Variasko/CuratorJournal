using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CuratorJournal.Desktop.ApiConnectors.Base
{
    public class BaseApiConnector
    {
        protected readonly HttpClient _httpClient;
        protected readonly string _baseUrl = File.ReadAllText("ApiIP.cjprop").Trim();

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
        protected async Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, TRequest data)
        {
            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(_baseUrl + endpoint, content);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponse>(responseBody);
        }
    }
}
