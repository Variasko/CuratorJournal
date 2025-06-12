using CuratorJournal.DataAccess.Models;
using CuratorJournal.DataAccess.Repositories.Interfaces.Base;
using CuratorJournal.DataAccess.Services.Implementations.Base;
using CuratorJournal.DataAccess.Services.Interfaces;

namespace CuratorJournal.DataAccess.Services.Implementations
{
    public class TeacherCategoryService : BaseService<TeacherCategory>, ITeacherCategoryService
    {
        public TeacherCategoryService(IBaseRepository<TeacherCategory> repository)
            : base(repository)
        {
        }
    }
}