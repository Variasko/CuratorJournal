using System.Collections.Generic;
using System.Threading.Tasks;
using CuratorJournal.Desktop.Models; // Здесь должны быть Request/Response модели
using CuratorJournal.Desktop.ApiConnectors.Base;

namespace CuratorJournal.Desktop.ApiConnectors
{
    public class ClassHourConnector : BaseApiConnector
    {
        private const string Endpoint = "ClassHour";

        public async Task<IEnumerable<ClassHourResponse>> GetAllAsync()
        {
            return await GetAsync<IEnumerable<ClassHourResponse>>(Endpoint);
        }

        public async Task<ClassHourResponse> GetByIdAsync(int id)
        {
            return await GetAsync<ClassHourResponse>(Endpoint + $"/{id}");
        }

        public async Task AddAsync(ClassHourRequest entity)
        {
            await PostAsync(Endpoint + "/create", entity);
        }

        public async Task UpdateAsync(ClassHourRequest entity, int id)
        {
            await PutAsync(Endpoint + $"/{id}", entity);
        }

        public async Task DeleteAsync(int id)
        {
            await DeleteAsync(Endpoint + $"/{id}");
        }
    }
}
