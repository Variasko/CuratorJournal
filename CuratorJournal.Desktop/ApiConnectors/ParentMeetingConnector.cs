using System.Collections.Generic;
using System.Threading.Tasks;
using CuratorJournal.Desktop.Models; // Здесь должны быть Request/Response модели
using CuratorJournal.Desktop.ApiConnectors.Base;

namespace CuratorJournal.Desktop.ApiConnectors
{
    public class ParentMeetingConnector : BaseApiConnector
    {
        private const string Endpoint = "ParentMeeting";

        public async Task<IEnumerable<ParentMeetingResponse>> GetAllAsync()
        {
            return await GetAsync<IEnumerable<ParentMeetingResponse>>(Endpoint);
        }

        public async Task<ParentMeetingResponse> GetByIdAsync(int id)
        {
            return await GetAsync<ParentMeetingResponse>(Endpoint + $"/{id}");
        }

        public async Task AddAsync(ParentMeetingRequest entity)
        {
            await PostAsync(Endpoint + "/create", entity);
        }

        public async Task UpdateAsync(ParentMeetingRequest entity, int id)
        {
            await PutAsync(Endpoint + $"/{id}", entity);
        }

        public async Task DeleteAsync(int id)
        {
            await DeleteAsync(Endpoint + $"/{id}");
        }
    }
}
