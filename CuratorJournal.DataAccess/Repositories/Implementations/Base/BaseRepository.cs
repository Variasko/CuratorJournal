using CuratorJournal.DataAccess.Database;
using CuratorJournal.DataAccess.Repositories.Interfaces.Base;
using Microsoft.EntityFrameworkCore;

namespace CuratorJournal.DataAccess.Repositories.Implementations.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> 
        where TEntity : class
    {
        protected ApplicationContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        => await _dbSet.FindAsync(id);

        public async Task<IEnumerable<TEntity>> GetAllAsync()
            => await _dbSet.ToListAsync();

        public async Task CreateAsync(TEntity entity)
            => await _dbSet.AddAsync(entity);

        public async Task UpdateAsync(TEntity entity)
            => _dbSet.Update(entity);

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null) _dbSet.Remove(entity);
        }

        public async Task SaveAsync()
            => await _context.SaveChangesAsync();
    }
}
