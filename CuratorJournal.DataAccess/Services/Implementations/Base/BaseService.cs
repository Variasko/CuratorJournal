using CuratorJournal.DataAccess.Repositories.Interfaces.Base;
using CuratorJournal.DataAccess.Services.Interfaces.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CuratorJournal.DataAccess.Services.Implementations.Base
{
    public class BaseService<TEntity> : IBaseService<TEntity>
        where TEntity : class
    {
        private readonly IBaseRepository<TEntity> _repository;

        public BaseService(IBaseRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
            => await _repository.GetAllAsync();

        public async Task<TEntity?> GetByIdAsync(int id)
            => await _repository.GetByIdAsync(id);

        public async Task CreateAsync(TEntity entity)
        {
            await _repository.CreateAsync(entity);
            await _repository.SaveAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await _repository.UpdateAsync(entity);
            await _repository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
            await _repository.SaveAsync();
        }

        public async Task SaveAsync()
            => await _repository.SaveAsync();
    }
}