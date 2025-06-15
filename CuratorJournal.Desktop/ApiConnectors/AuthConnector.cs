using CuratorJournal.Desktop.ApiConnectors.Base;
using CuratorJournal.Desktop.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace CuratorJournal.Desktop.ApiConnectors
{
    public class AuthConnector : BaseApiConnector
    {
        private const string AuthEndpoint = "Auth";

        public async Task<bool> IsServerAvailableAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(_baseUrl + "HealthCheck");
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<CuratorResponse> LoginAsync(LoginRequest request)
        {
            return await PostAsync<CuratorResponse>(AuthEndpoint + "/Login", request);
        }
    }
}