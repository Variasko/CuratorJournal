using System.Collections.Generic;
using System.Threading.Tasks;

namespace CuratorJournal.DataAccess.Services.Interfaces.Base
{
    public interface IServiceBase<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
