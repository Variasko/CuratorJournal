using CuratorJournal.DataAccess.Database;
using CuratorJournal.DataAccess.Models;
using CuratorJournal.DataAccess.Repositories.Implementations.Base;
using CuratorJournal.DataAccess.Repositories.Interfaces;

namespace CuratorJournal.DataAccess.Repositories.Implementations
{
    public class DirectionRepository : BaseRepository<Direction>, IDirectionRepository
    {
        public DirectionRepository(ApplicationContext context)
            : base(context) { }
    }
}
