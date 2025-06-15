using System.Collections.Generic;
using System.Threading.Tasks;
using CuratorJournal.Desktop.Models; // Здесь должны быть Request/Response модели
using CuratorJournal.Desktop.ApiConnectors.Base;

namespace CuratorJournal.Desktop.ApiConnectors
{
    public class StudentStudyGroupConnector : BaseApiConnector
    {
        private const string Endpoint = "StudentStudyGroup";

        public async Task<IEnumerable<StudentStudyGroupResponse>> GetAllAsync()
        {
            return await GetAsync<IEnumerable<StudentStudyGroupResponse>>(Endpoint);
        }

        public async Task<StudentStudyGroupResponse> GetByIdAsync(int id)
        {
            return await GetAsync<StudentStudyGroupResponse>(Endpoint + $"/{id}");
        }

        public async Task AddAsync(StudentStudyGroupRequest entity)
        {
            await PostAsync(Endpoint + "/create", entity);
        }

        public async Task UpdateAsync(StudentStudyGroupRequest entity, int id)
        {
            await PutAsync(Endpoint + $"/{id}", entity);
        }

        public async Task DeleteAsync(int id)
        {
            await DeleteAsync(Endpoint + $"/{id}");
        }
    }
}
