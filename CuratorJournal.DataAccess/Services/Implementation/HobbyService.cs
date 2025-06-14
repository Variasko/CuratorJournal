using CuratorJournal.DataAccess.Models;
using CuratorJournal.DataAccess.Services.Interfaces;
using CuratorJournal.DataAccess.Repositories.Interfaces;
using CuratorJournal.DataAccess.Services.Implementation.Base;

namespace CuratorJournal.DataAccess.Services.Implementation
{
    public class HobbyService : ServiceBase<Hobby>, IHobbyService
    {
        public HobbyService(IHobbyRepository repository) : base(repository) { }
    }
}
