namespace CuratorJournal.DataAccess.Repositories.Interfaces.Base
{
    public interface IBaseRepository<IEntity> where IEntity : class
    {
        Task<IEnumerable<IEntity>> GetAllAsync();
        Task<IEntity?> GetByIdAsync(int id);
        Task CreateAsync(IEntity entity);
        Task UpdateAsync(IEntity entity);
        Task DeleteAsync(int id);
        Task SaveAsync();
    }
}
