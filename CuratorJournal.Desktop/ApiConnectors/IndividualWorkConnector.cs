using System.Collections.Generic;
using System.Threading.Tasks;
using CuratorJournal.Desktop.Models; // Здесь должны быть Request/Response модели
using CuratorJournal.Desktop.ApiConnectors.Base;

namespace CuratorJournal.Desktop.ApiConnectors
{
    public class IndividualWorkConnector : BaseApiConnector
    {
        private const string Endpoint = "IndividualWork";

        public async Task<IEnumerable<IndividualWorkResponse>> GetAllAsync()
        {
            return await GetAsync<IEnumerable<IndividualWorkResponse>>(Endpoint);
        }

        public async Task<IndividualWorkResponse> GetByIdAsync(int id)
        {
            return await GetAsync<IndividualWorkResponse>(Endpoint + $"/{id}");
        }

        public async Task AddAsync(IndividualWorkRequest entity)
        {
            await PostAsync(Endpoint + "/create", entity);
        }

        public async Task UpdateAsync(IndividualWorkRequest entity, int id)
        {
            await PutAsync(Endpoint + $"/{id}", entity);
        }

        public async Task DeleteAsync(int id)
        {
            await DeleteAsync(Endpoint + $"/{id}");
        }
    }
}
