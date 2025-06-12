using CuratorJournal.DataAccess.Models;
using CuratorJournal.DataAccess.Repositories.Interfaces.Base;
using CuratorJournal.DataAccess.Services.Implementations.Base;
using CuratorJournal.DataAccess.Services.Interfaces;

namespace CuratorJournal.DataAccess.Services.Implementations
{
    public class ParentService : BaseService<Parent>, IParentService
    {
        public ParentService(IBaseRepository<Parent> repository)
            : base(repository)
        {
        }
    }
}