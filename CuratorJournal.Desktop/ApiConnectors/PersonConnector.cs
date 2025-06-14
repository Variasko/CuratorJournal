using System.Collections.Generic;
using System.Threading.Tasks;
using CuratorJournal.Desktop.Models; // Здесь должны быть Request/Response модели
using CuratorJournal.Desktop.ApiConnectors.Base;

namespace CuratorJournal.Desktop.ApiConnectors
{
    public class PersonConnector : BaseApiConnector
    {
        private const string Endpoint = "Person";

        public async Task<IEnumerable<PersonResponse>> GetAllAsync()
        {
            return await GetAsync<IEnumerable<PersonResponse>>(Endpoint);
        }

        public async Task<PersonResponse> GetByIdAsync(int id)
        {
            return await GetAsync<PersonResponse>(Endpoint + $"/{id}");
        }

        public async Task AddAsync(PersonRequest entity)
        {
            await PostAsync(Endpoint + "/create", entity);
        }

        public async Task UpdateAsync(PersonRequest entity, int id)
        {
            await PutAsync(Endpoint + $"/{id}", entity);
        }

        public async Task DeleteAsync(int id)
        {
            await DeleteAsync(Endpoint + $"/{id}");
        }
    }
}
