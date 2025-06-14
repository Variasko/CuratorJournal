using System.Collections.Generic;
using System.Threading.Tasks;
using CuratorJournal.Desktop.Models; // Здесь должны быть Request/Response модели
using CuratorJournal.Desktop.ApiConnectors.Base;

namespace CuratorJournal.Desktop.ApiConnectors
{
    public class CuratorCharacteristicConnector : BaseApiConnector
    {
        private const string Endpoint = "CuratorCharacteristic";

        public async Task<IEnumerable<CuratorCharacteristicResponse>> GetAllAsync()
        {
            return await GetAsync<IEnumerable<CuratorCharacteristicResponse>>(Endpoint);
        }

        public async Task<CuratorCharacteristicResponse> GetByIdAsync(int id)
        {
            return await GetAsync<CuratorCharacteristicResponse>(Endpoint + $"/{id}");
        }

        public async Task AddAsync(CuratorCharacteristicRequest entity)
        {
            await PostAsync(Endpoint + "/create", entity);
        }

        public async Task UpdateAsync(CuratorCharacteristicRequest entity, int id)
        {
            await PutAsync(Endpoint + $"/{id}", entity);
        }

        public async Task DeleteAsync(int id)
        {
            await DeleteAsync(Endpoint + $"/{id}");
        }
    }
}
