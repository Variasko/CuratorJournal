using System.Collections.Generic;
using System.Threading.Tasks;
using CuratorJournal.Desktop.Models; // Здесь должны быть Request/Response модели
using CuratorJournal.Desktop.ApiConnectors.Base;

namespace CuratorJournal.Desktop.ApiConnectors
{
    public class QualificationConnector : BaseApiConnector
    {
        private const string Endpoint = "Qualification";

        public async Task<IEnumerable<QualificationResponse>> GetAllAsync()
        {
            return await GetAsync<IEnumerable<QualificationResponse>>(Endpoint);
        }

        public async Task<QualificationResponse> GetByIdAsync(int id)
        {
            return await GetAsync<QualificationResponse>(Endpoint + $"/{id}");
        }

        public async Task AddAsync(QualificationRequest entity)
        {
            await PostAsync(Endpoint + "/create", entity);
        }

        public async Task UpdateAsync(QualificationRequest entity, int id)
        {
            await PutAsync(Endpoint + $"/{id}", entity);
        }

        public async Task DeleteAsync(int id)
        {
            await DeleteAsync(Endpoint + $"/{id}");
        }
    }
}
