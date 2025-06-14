using CuratorJournal.DataAccess.Models;
using CuratorJournal.DataAccess.Repositories.Interfaces;
using CuratorJournal.DataAccess.Repositories.Implementation.Base;
using CuratorJournal.DataAccess.Database;

namespace CuratorJournal.DataAccess.Repositories.Implementation
{
    public class TeacherCategoryRepository : RepositoryBase<TeacherCategory>, ITeacherCategoryRepository
    {
        public TeacherCategoryRepository(ApplicationContext context) : base(context) { }
    }
}
