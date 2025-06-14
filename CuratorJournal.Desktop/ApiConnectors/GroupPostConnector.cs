using System.Collections.Generic;
using System.Threading.Tasks;
using CuratorJournal.Desktop.Models; // Здесь должны быть Request/Response модели
using CuratorJournal.Desktop.ApiConnectors.Base;

namespace CuratorJournal.Desktop.ApiConnectors
{
    public class GroupPostConnector : BaseApiConnector
    {
        private const string Endpoint = "GroupPost";

        public async Task<IEnumerable<GroupPostResponse>> GetAllAsync()
        {
            return await GetAsync<IEnumerable<GroupPostResponse>>(Endpoint);
        }

        public async Task<GroupPostResponse> GetByIdAsync(int id)
        {
            return await GetAsync<GroupPostResponse>(Endpoint + $"/{id}");
        }

        public async Task AddAsync(GroupPostRequest entity)
        {
            await PostAsync(Endpoint + "/create", entity);
        }

        public async Task UpdateAsync(GroupPostRequest entity, int id)
        {
            await PutAsync(Endpoint + $"/{id}", entity);
        }

        public async Task DeleteAsync(int id)
        {
            await DeleteAsync(Endpoint + $"/{id}");
        }
    }
}
