using CuratorJournal.DataAccess.Models;
using CuratorJournal.DataAccess.Repositories.Interfaces.Base;
using CuratorJournal.DataAccess.Services.Implementations.Base;
using CuratorJournal.DataAccess.Services.Interfaces;

namespace CuratorJournal.DataAccess.Services.Implementations
{
    public class SpecializationService : BaseService<Specialization>, ISpecializationService
    {
        public SpecializationService(IBaseRepository<Specialization> repository)
            : base(repository)
        {
        }
    }
}