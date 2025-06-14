using CuratorJournal.DataAccess.Models;
using CuratorJournal.DataAccess.Services.Interfaces;
using CuratorJournal.DataAccess.Repositories.Interfaces;
using CuratorJournal.DataAccess.Services.Implementation.Base;

namespace CuratorJournal.DataAccess.Services.Implementation
{
    public class StudyGroupService : ServiceBase<StudyGroup>, IStudyGroupService
    {
        public StudyGroupService(IStudyGroupRepository repository) : base(repository) { }
    }
}
