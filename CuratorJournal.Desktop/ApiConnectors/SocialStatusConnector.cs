using System.Collections.Generic;
using System.Threading.Tasks;
using CuratorJournal.Desktop.Models; // Здесь должны быть Request/Response модели
using CuratorJournal.Desktop.ApiConnectors.Base;

namespace CuratorJournal.Desktop.ApiConnectors
{
    public class SocialStatusConnector : BaseApiConnector
    {
        private const string Endpoint = "SocialStatus";

        public async Task<IEnumerable<SocialStatusResponse>> GetAllAsync()
        {
            return await GetAsync<IEnumerable<SocialStatusResponse>>(Endpoint);
        }

        public async Task<SocialStatusResponse> GetByIdAsync(int id)
        {
            return await GetAsync<SocialStatusResponse>(Endpoint + $"/{id}");
        }

        public async Task AddAsync(SocialStatusRequest entity)
        {
            await PostAsync(Endpoint + "/create", entity);
        }

        public async Task UpdateAsync(SocialStatusRequest entity, int id)
        {
            await PutAsync(Endpoint + $"/{id}", entity);
        }

        public async Task DeleteAsync(int id)
        {
            await DeleteAsync(Endpoint + $"/{id}");
        }
    }
}
