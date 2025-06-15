using CuratorJournal.DataAccess.Models;
using CuratorJournal.DataAccess.Services.Interfaces;
using CuratorJournal.DataAccess.Repositories.Interfaces;
using CuratorJournal.DataAccess.Services.Implementation.Base;

namespace CuratorJournal.DataAccess.Services.Implementation
{
    public class CuratorService : ServiceBase<Curator>, ICuratorService
    {
        public CuratorService(ICuratorRepository repository) : base(repository) { }
    }
}
