using CuratorJournal.DataAccess.Models;
using CuratorJournal.DataAccess.Repositories.Interfaces.Base;
using CuratorJournal.DataAccess.Services.Implementations.Base;
using CuratorJournal.DataAccess.Services.Interfaces;

namespace CuratorJournal.DataAccess.Services.Implementations
{
    public class TranslationKeyService : BaseService<TranslationKey>, ITranslationKeyService
    {
        public TranslationKeyService(IBaseRepository<TranslationKey> repository)
            : base(repository)
        {
        }
    }
}