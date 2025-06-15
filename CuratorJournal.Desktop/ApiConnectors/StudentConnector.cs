using System.Collections.Generic;
using System.Threading.Tasks;
using CuratorJournal.Desktop.Models; // Здесь должны быть Request/Response модели
using CuratorJournal.Desktop.ApiConnectors.Base;

namespace CuratorJournal.Desktop.ApiConnectors
{
    public class StudentConnector : BaseApiConnector
    {
        private const string Endpoint = "Student";

        public async Task<IEnumerable<StudentResponse>> GetAllAsync()
        {
            return await GetAsync<IEnumerable<StudentResponse>>(Endpoint);
        }

        public async Task<StudentResponse> GetByIdAsync(int id)
        {
            return await GetAsync<StudentResponse>(Endpoint + $"/{id}");
        }

        public async Task AddAsync(StudentRequest entity)
        {
            await PostAsync(Endpoint + "/create", entity);
        }

        public async Task UpdateAsync(StudentRequest entity, int id)
        {
            await PutAsync(Endpoint + $"/{id}", entity);
        }

        public async Task DeleteAsync(int id)
        {
            await DeleteAsync(Endpoint + $"/{id}");
        }
    }
}
