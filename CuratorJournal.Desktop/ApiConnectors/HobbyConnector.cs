using System.Collections.Generic;
using System.Threading.Tasks;
using CuratorJournal.Desktop.Models; // Здесь должны быть Request/Response модели
using CuratorJournal.Desktop.ApiConnectors.Base;

namespace CuratorJournal.Desktop.ApiConnectors
{
    public class HobbyConnector : BaseApiConnector
    {
        private const string Endpoint = "Hobby";

        public async Task<IEnumerable<HobbyResponse>> GetAllAsync()
        {
            return await GetAsync<IEnumerable<HobbyResponse>>(Endpoint);
        }

        public async Task<HobbyResponse> GetByIdAsync(int id)
        {
            return await GetAsync<HobbyResponse>(Endpoint + $"/{id}");
        }

        public async Task AddAsync(HobbyRequest entity)
        {
            await PostAsync(Endpoint + "/create", entity);
        }

        public async Task UpdateAsync(HobbyRequest entity, int id)
        {
            await PutAsync(Endpoint + $"/{id}", entity);
        }

        public async Task DeleteAsync(int id)
        {
            await DeleteAsync(Endpoint + $"/{id}");
        }
    }
}
