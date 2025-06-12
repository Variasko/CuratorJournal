using CuratorJournal.DataAccess.Models;
using CuratorJournal.DataAccess.Repositories.Interfaces.Base;
using CuratorJournal.DataAccess.Services.Implementations.Base;
using CuratorJournal.DataAccess.Services.Interfaces;

namespace CuratorJournal.DataAccess.Services.Implementations
{
    public class UserService : BaseService<User>, IUserService
    {
        public UserService(IBaseRepository<User> repository)
            : base(repository)
        {
        }
    }
}