using System.Collections.Generic;
using System.Threading.Tasks;
using CuratorJournal.Desktop.Models; // Здесь должны быть Request/Response модели
using CuratorJournal.Desktop.ApiConnectors.Base;

namespace CuratorJournal.Desktop.ApiConnectors
{
    public class UserConnector : BaseApiConnector
    {
        private const string Endpoint = "User";

        public async Task<IEnumerable<UserResponse>> GetAllAsync()
        {
            return await GetAsync<IEnumerable<UserResponse>>(Endpoint);
        }

        public async Task<UserResponse> GetByIdAsync(int id)
        {
            return await GetAsync<UserResponse>(Endpoint + $"/{id}");
        }

        public async Task AddAsync(UserRequest entity)
        {
            await PostAsync(Endpoint + "/create", entity);
        }

        public async Task UpdateAsync(UserRequest entity, int id)
        {
            await PutAsync(Endpoint + $"/{id}", entity);
        }

        public async Task DeleteAsync(int id)
        {
            await DeleteAsync(Endpoint + $"/{id}");
        }
        public async Task<UserResponse> LoginAsync(string login, string password)
        {
            var endpoint = $"{Endpoint}/Auth?login={login}&password={password}";
            return await PostAsync<object, UserResponse>(endpoint, null);
        }
    }
}
