using CuratorJournal.DataAccess.Models;
using CuratorJournal.DataAccess.Services.Interfaces;
using CuratorJournal.DataAccess.Repositories.Interfaces;
using CuratorJournal.DataAccess.Services.Implementation.Base;

namespace CuratorJournal.DataAccess.Services.Implementation
{
    public class SpecificationService : ServiceBase<Specification>, ISpecificationService
    {
        public SpecificationService(ISpecificationRepository repository) : base(repository) { }
    }
}
