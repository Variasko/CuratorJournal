using CuratorJournal.DataAccess.Models;
using CuratorJournal.DataAccess.Repositories.Interfaces.Base;
using CuratorJournal.DataAccess.Services.Implementations.Base;
using CuratorJournal.DataAccess.Services.Interfaces;

namespace CuratorJournal.DataAccess.Services.Implementations
{
    public class GroupPostService : BaseService<GroupPost>, IGroupPostService
    {
        public GroupPostService(IBaseRepository<GroupPost> repository)
            : base(repository)
        {
        }
    }
}