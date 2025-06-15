using System.Collections.Generic;
using System.Threading.Tasks;
using CuratorJournal.Desktop.Models; // Здесь должны быть Request/Response модели
using CuratorJournal.Desktop.ApiConnectors.Base;

namespace CuratorJournal.Desktop.ApiConnectors
{
    public class SpecificationConnector : BaseApiConnector
    {
        private const string Endpoint = "Specification";

        public async Task<IEnumerable<SpecificationResponse>> GetAllAsync()
        {
            return await GetAsync<IEnumerable<SpecificationResponse>>(Endpoint);
        }

        public async Task<SpecificationResponse> GetByIdAsync(int id)
        {
            return await GetAsync<SpecificationResponse>(Endpoint + $"/{id}");
        }

        public async Task AddAsync(SpecificationRequest entity)
        {
            await PostAsync(Endpoint + "/create", entity);
        }

        public async Task UpdateAsync(SpecificationRequest entity, int id)
        {
            await PutAsync(Endpoint + $"/{id}", entity);
        }

        public async Task DeleteAsync(int id)
        {
            await DeleteAsync(Endpoint + $"/{id}");
        }
    }
}
