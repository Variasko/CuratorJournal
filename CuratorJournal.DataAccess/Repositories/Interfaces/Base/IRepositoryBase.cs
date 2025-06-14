using System.Collections.Generic;
using System.Threading.Tasks;

namespace CuratorJournal.DataAccess.Repositories.Interfaces.Base
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
