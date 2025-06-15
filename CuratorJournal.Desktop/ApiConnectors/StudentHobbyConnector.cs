using System.Collections.Generic;
using System.Threading.Tasks;
using CuratorJournal.Desktop.Models; // Здесь должны быть Request/Response модели
using CuratorJournal.Desktop.ApiConnectors.Base;

namespace CuratorJournal.Desktop.ApiConnectors
{
    public class StudentHobbyConnector : BaseApiConnector
    {
        private const string Endpoint = "StudentHobby";

        public async Task<IEnumerable<StudentHobbyResponse>> GetAllAsync()
        {
            return await GetAsync<IEnumerable<StudentHobbyResponse>>(Endpoint);
        }

        public async Task<StudentHobbyResponse> GetByIdAsync(int id)
        {
            return await GetAsync<StudentHobbyResponse>(Endpoint + $"/{id}");
        }

        public async Task AddAsync(StudentHobbyRequest entity)
        {
            await PostAsync(Endpoint + "/create", entity);
        }

        public async Task UpdateAsync(StudentHobbyRequest entity, int id)
        {
            await PutAsync(Endpoint + $"/{id}", entity);
        }

        public async Task DeleteAsync(int id)
        {
            await DeleteAsync(Endpoint + $"/{id}");
        }
    }
}
