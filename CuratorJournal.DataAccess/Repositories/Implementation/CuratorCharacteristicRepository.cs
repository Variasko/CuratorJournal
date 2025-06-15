using CuratorJournal.DataAccess.Models;
using CuratorJournal.DataAccess.Repositories.Interfaces;
using CuratorJournal.DataAccess.Repositories.Implementation.Base;
using CuratorJournal.DataAccess.Database;

namespace CuratorJournal.DataAccess.Repositories.Implementation
{
    public class CuratorCharacteristicRepository : RepositoryBase<CuratorCharacteristic>, ICuratorCharacteristicRepository
    {
        public CuratorCharacteristicRepository(ApplicationContext context) : base(context) { }
    }
}
