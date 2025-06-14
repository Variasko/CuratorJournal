using System.Collections.Generic;
using System.Threading.Tasks;
using CuratorJournal.Desktop.Models; // Здесь должны быть Request/Response модели
using CuratorJournal.Desktop.ApiConnectors.Base;

namespace CuratorJournal.Desktop.ApiConnectors
{
    public class StudentSocialStatusConnector : BaseApiConnector
    {
        private const string Endpoint = "StudentSocialStatus";

        public async Task<IEnumerable<StudentSocialStatusResponse>> GetAllAsync()
        {
            return await GetAsync<IEnumerable<StudentSocialStatusResponse>>(Endpoint);
        }

        public async Task<StudentSocialStatusResponse> GetByIdAsync(int id)
        {
            return await GetAsync<StudentSocialStatusResponse>(Endpoint + $"/{id}");
        }

        public async Task AddAsync(StudentSocialStatusRequest entity)
        {
            await PostAsync(Endpoint + "/create", entity);
        }

        public async Task UpdateAsync(StudentSocialStatusRequest entity, int id)
        {
            await PutAsync(Endpoint + $"/{id}", entity);
        }

        public async Task DeleteAsync(int id)
        {
            await DeleteAsync(Endpoint + $"/{id}");
        }
    }
}
