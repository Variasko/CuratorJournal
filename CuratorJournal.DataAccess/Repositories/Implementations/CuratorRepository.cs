using CuratorJournal.DataAccess.Database;
using CuratorJournal.DataAccess.Models;
using CuratorJournal.DataAccess.Repositories.Implementations.Base;
using CuratorJournal.DataAccess.Repositories.Interfaces;

namespace CuratorJournal.DataAccess.Repositories.Implementations
{
    public class CuratorRepository : BaseRepository<Curator>, ICuratorRepository
    {
        public CuratorRepository(ApplicationContext context)
        : base(context) { }
    }
}
