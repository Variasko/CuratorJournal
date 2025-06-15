using System.Collections.Generic;
using System.Threading.Tasks;
using CuratorJournal.Desktop.Models; // Здесь должны быть Request/Response модели
using CuratorJournal.Desktop.ApiConnectors.Base;

namespace CuratorJournal.Desktop.ApiConnectors
{
    public class StudyGroupConnector : BaseApiConnector
    {
        private const string Endpoint = "StudyGroup";

        public async Task<IEnumerable<StudyGroupResponse>> GetAllAsync()
        {
            return await GetAsync<IEnumerable<StudyGroupResponse>>(Endpoint);
        }

        public async Task<StudyGroupResponse> GetByIdAsync(int id)
        {
            return await GetAsync<StudyGroupResponse>(Endpoint + $"/{id}");
        }

        public async Task AddAsync(StudyGroupRequest entity)
        {
            await PostAsync(Endpoint + "/create", entity);
        }

        public async Task UpdateAsync(StudyGroupRequest entity, int id)
        {
            await PutAsync(Endpoint + $"/{id}", entity);
        }

        public async Task DeleteAsync(int id)
        {
            await DeleteAsync(Endpoint + $"/{id}");
        }
    }
}
