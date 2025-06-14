using System.Collections.Generic;
using System.Threading.Tasks;
using CuratorJournal.Desktop.Models; // Здесь должны быть Request/Response модели
using CuratorJournal.Desktop.ApiConnectors.Base;

namespace CuratorJournal.Desktop.ApiConnectors
{
    public class CuratorConnector : BaseApiConnector
    {
        private const string Endpoint = "Curator";

        public async Task<IEnumerable<CuratorResponse>> GetAllAsync()
        {
            return await GetAsync<IEnumerable<CuratorResponse>>(Endpoint);
        }

        public async Task<CuratorResponse> GetByIdAsync(int id)
        {
            return await GetAsync<CuratorResponse>(Endpoint + $"/{id}");
        }

        public async Task AddAsync(CuratorRequest entity)
        {
            await PostAsync(Endpoint + "/create", entity);
        }

        public async Task UpdateAsync(CuratorRequest entity, int id)
        {
            await PutAsync(Endpoint + $"/{id}", entity);
        }

        public async Task DeleteAsync(int id)
        {
            await DeleteAsync(Endpoint + $"/{id}");
        }
    }
}
