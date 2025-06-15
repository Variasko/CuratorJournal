using System.Collections.Generic;
using System.Threading.Tasks;
using CuratorJournal.Desktop.Models; // Здесь должны быть Request/Response модели
using CuratorJournal.Desktop.ApiConnectors.Base;

namespace CuratorJournal.Desktop.ApiConnectors
{
    public class StudentClassHourConnector : BaseApiConnector
    {
        private const string Endpoint = "StudentClassHour";

        public async Task<IEnumerable<StudentClassHourResponse>> GetAllAsync()
        {
            return await GetAsync<IEnumerable<StudentClassHourResponse>>(Endpoint);
        }

        public async Task<StudentClassHourResponse> GetByIdAsync(int id)
        {
            return await GetAsync<StudentClassHourResponse>(Endpoint + $"/{id}");
        }

        public async Task AddAsync(StudentClassHourRequest entity)
        {
            await PostAsync(Endpoint + "/create", entity);
        }

        public async Task UpdateAsync(StudentClassHourRequest entity, int id)
        {
            await PutAsync(Endpoint + $"/{id}", entity);
        }

        public async Task DeleteAsync(int id)
        {
            await DeleteAsync(Endpoint + $"/{id}");
        }
    }
}
