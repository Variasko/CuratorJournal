using CuratorJournal.DataAccess.Models;
using CuratorJournal.DataAccess.Repositories.Interfaces.Base;
using CuratorJournal.DataAccess.Services.Implementations.Base;
using CuratorJournal.DataAccess.Services.Interfaces;

namespace CuratorJournal.DataAccess.Services.Implementations
{
    public class ClassHourService : BaseService<ClassHour>, IClassHourService
    {
        public ClassHourService(IBaseRepository<ClassHour> repository)
            : base(repository)
        {
        }
    }
}