using CuratorJournal.DataAccess.Models;
using CuratorJournal.DataAccess.Repositories.Interfaces.Base;
using CuratorJournal.DataAccess.Services.Implementations.Base;
using CuratorJournal.DataAccess.Services.Interfaces;

namespace CuratorJournal.DataAccess.Services.Implementations
{
    public class StudentInDormitoryService : BaseService<StudentInDormitory>, IStudentInDormitoryService
    {
        public StudentInDormitoryService(IBaseRepository<StudentInDormitory> repository)
            : base(repository)
        {
        }
    }
}