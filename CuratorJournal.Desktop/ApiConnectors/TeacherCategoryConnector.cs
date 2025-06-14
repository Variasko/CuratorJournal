using System.Collections.Generic;
using System.Threading.Tasks;
using CuratorJournal.Desktop.Models; // Здесь должны быть Request/Response модели
using CuratorJournal.Desktop.ApiConnectors.Base;

namespace CuratorJournal.Desktop.ApiConnectors
{
    public class TeacherCategoryConnector : BaseApiConnector
    {
        private const string Endpoint = "TeacherCategory";

        public async Task<IEnumerable<TeacherCategoryResponse>> GetAllAsync()
        {
            return await GetAsync<IEnumerable<TeacherCategoryResponse>>(Endpoint);
        }

        public async Task<TeacherCategoryResponse> GetByIdAsync(int id)
        {
            return await GetAsync<TeacherCategoryResponse>(Endpoint + $"/{id}");
        }

        public async Task AddAsync(TeacherCategoryRequest entity)
        {
            await PostAsync(Endpoint + "/create", entity);
        }

        public async Task UpdateAsync(TeacherCategoryRequest entity, int id)
        {
            await PutAsync(Endpoint + $"/{id}", entity);
        }

        public async Task DeleteAsync(int id)
        {
            await DeleteAsync(Endpoint + $"/{id}");
        }
    }
}
