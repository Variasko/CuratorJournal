using System.Collections.Generic;
using System.Threading.Tasks;
using CuratorJournal.Desktop.Models; // Здесь должны быть Request/Response модели
using CuratorJournal.Desktop.ApiConnectors.Base;

namespace CuratorJournal.Desktop.ApiConnectors
{
    public class StudentParentConnector : BaseApiConnector
    {
        private const string Endpoint = "StudentParent";

        public async Task<IEnumerable<StudentParentResponse>> GetAllAsync()
        {
            return await GetAsync<IEnumerable<StudentParentResponse>>(Endpoint);
        }

        public async Task<StudentParentResponse> GetByIdAsync(int id)
        {
            return await GetAsync<StudentParentResponse>(Endpoint + $"/{id}");
        }

        public async Task AddAsync(StudentParentRequest entity)
        {
            await PostAsync(Endpoint + "/create", entity);
        }

        public async Task UpdateAsync(StudentParentRequest entity, int id)
        {
            await PutAsync(Endpoint + $"/{id}", entity);
        }

        public async Task DeleteAsync(int id)
        {
            await DeleteAsync(Endpoint + $"/{id}");
        }
    }
}
