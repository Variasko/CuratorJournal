using CuratorJournal.DataAccess.Repositories.Interfaces.Base;
using CuratorJournal.DataAccess.Services.Interfaces.Base;

namespace CuratorJournal.DataAccess.Services.Implementation.Base
{
    public class ServiceBase<T> : IServiceBase<T> where T : class
    {
        private readonly IRepositoryBase<T> _repository;

        public ServiceBase(IRepositoryBase<T> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<T> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
        public async Task<T> CreateAsync(T entity) => await _repository.AddAsync(entity);
        public async Task UpdateAsync(T entity) => await _repository.UpdateAsync(entity);
        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
    }
}
