using CuratorJournal.DataAccess.Models;
using CuratorJournal.DataAccess.Repositories.Interfaces.Base;
using CuratorJournal.DataAccess.Services.Implementations.Base;
using CuratorJournal.DataAccess.Services.Interfaces;

namespace CuratorJournal.DataAccess.Services.Implementations
{
    public class LanguageService : BaseService<Language>, ILanguageService
    {
        public LanguageService(IBaseRepository<Language> repository)
            : base(repository)
        {
        }
    }
}