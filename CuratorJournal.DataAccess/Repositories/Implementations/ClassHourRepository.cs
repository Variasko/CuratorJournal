using CuratorJournal.DataAccess.Database;
using CuratorJournal.DataAccess.Models;
using CuratorJournal.DataAccess.Repositories.Implementations.Base;
using CuratorJournal.DataAccess.Repositories.Interfaces;

namespace CuratorJournal.DataAccess.Repositories.Implementations
{
    public class ClassHourRepository : BaseRepository<ClassHour>, IClassHourRepository
    {
        public ClassHourRepository(ApplicationContext context)
            : base(context) { }
    }
}
