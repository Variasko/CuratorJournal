using System.Collections.Generic;
using System.Threading.Tasks;
using CuratorJournal.Desktop.Models; // Здесь должны быть Request/Response модели
using CuratorJournal.Desktop.ApiConnectors.Base;

namespace CuratorJournal.Desktop.ApiConnectors
{
    public class ParentConnector : BaseApiConnector
    {
        private const string Endpoint = "Parent";

        public async Task<IEnumerable<ParentResponse>> GetAllAsync()
        {
            return await GetAsync<IEnumerable<ParentResponse>>(Endpoint);
        }

        public async Task<ParentResponse> GetByIdAsync(int id)
        {
            return await GetAsync<ParentResponse>(Endpoint + $"/{id}");
        }

        public async Task AddAsync(ParentRequest entity)
        {
            await PostAsync(Endpoint + "/create", entity);
        }

        public async Task UpdateAsync(ParentRequest entity, int id)
        {
            await PutAsync(Endpoint + $"/{id}", entity);
        }

        public async Task DeleteAsync(int id)
        {
            await DeleteAsync(Endpoint + $"/{id}");
        }
    }
}
