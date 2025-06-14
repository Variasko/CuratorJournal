using System.Collections.Generic;
using System.Threading.Tasks;
using CuratorJournal.Desktop.Models; // Здесь должны быть Request/Response модели
using CuratorJournal.Desktop.ApiConnectors.Base;

namespace CuratorJournal.Desktop.ApiConnectors
{
    public class StudentInDormitoryConnector : BaseApiConnector
    {
        private const string Endpoint = "StudentInDormitory";

        public async Task<IEnumerable<StudentInDormitoryResponse>> GetAllAsync()
        {
            return await GetAsync<IEnumerable<StudentInDormitoryResponse>>(Endpoint);
        }

        public async Task<StudentInDormitoryResponse> GetByIdAsync(int id)
        {
            return await GetAsync<StudentInDormitoryResponse>(Endpoint + $"/{id}");
        }

        public async Task AddAsync(StudentInDormitoryRequest entity)
        {
            await PostAsync(Endpoint + "/create", entity);
        }

        public async Task UpdateAsync(StudentInDormitoryRequest entity, int id)
        {
            await PutAsync(Endpoint + $"/{id}", entity);
        }

        public async Task DeleteAsync(int id)
        {
            await DeleteAsync(Endpoint + $"/{id}");
        }
    }
}
