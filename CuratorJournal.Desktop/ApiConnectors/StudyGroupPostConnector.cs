using System.Collections.Generic;
using System.Threading.Tasks;
using CuratorJournal.Desktop.Models; // Здесь должны быть Request/Response модели
using CuratorJournal.Desktop.ApiConnectors.Base;

namespace CuratorJournal.Desktop.ApiConnectors
{
    public class StudyGroupPostConnector : BaseApiConnector
    {
        private const string Endpoint = "StudyGroupPost";

        public async Task<IEnumerable<StudyGroupPostResponse>> GetAllAsync()
        {
            return await GetAsync<IEnumerable<StudyGroupPostResponse>>(Endpoint);
        }

        public async Task<StudyGroupPostResponse> GetByIdAsync(int id)
        {
            return await GetAsync<StudyGroupPostResponse>(Endpoint + $"/{id}");
        }

        public async Task AddAsync(StudyGroupPostRequest entity)
        {
            await PostAsync(Endpoint + "/create", entity);
        }

        public async Task UpdateAsync(StudyGroupPostRequest entity, int id)
        {
            await PutAsync(Endpoint + $"/{id}", entity);
        }

        public async Task DeleteAsync(int id)
        {
            await DeleteAsync(Endpoint + $"/{id}");
        }
    }
}
