import os

# Список моделей, которые есть в EF Core (берём из merged_file)
models = [
    "ClassHour", "Curator", "CuratorCharacteristic", "GroupPost", "Hobby",
    "IndividualWork", "Parent", "ParentMeeting", "Person", "Qualification",
    "SocialStatus", "Specification", "Student", "StudentClassHour",
    "StudentInDormitory", "StudyGroup", "TeacherCategory", "User"
]

# Путь к проекту (скрипт запускается внутри проекта)
project_path = os.getcwd()

# Создаем структуру папок
structure = {
    "Repositories": ["Interfaces", "Implementation"],
    "Services": ["Interfaces", "Implementation"]
}

for folder, subfolders in structure.items():
    for sub in subfolders:
        path = os.path.join(project_path, folder, sub, "Base")
        os.makedirs(path, exist_ok=True)

# --- Генерация базовых классов ---

# IRepositoryBase.cs
with open(os.path.join(project_path, "Repositories", "Interfaces", "Base", "IRepositoryBase.cs"), 'w', encoding='utf-8') as f:
    f.write("""using System.Collections.Generic;
using System.Threading.Tasks;

namespace CuratorJournal.DataAccess.Repositories.Interfaces.Base
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
""")

# RepositoryBase.cs
with open(os.path.join(project_path, "Repositories", "Implementation", "Base", "RepositoryBase.cs"), 'w', encoding='utf-8') as f:
    f.write("""using CuratorJournal.DataAccess.Repositories.Interfaces.Base;
using Microsoft.EntityFrameworkCore;
using CuratorJournal.DataAccess.Database;

namespace CuratorJournal.DataAccess.Repositories.Implementation.Base
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly ApplicationContext _context;
        protected DbSet<T> _dbSet;

        public RepositoryBase(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();
        public async Task<T> GetByIdAsync(int id) => await _dbSet.FindAsync(id);
        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
""")

# IServiceBase.cs
with open(os.path.join(project_path, "Services", "Interfaces", "Base", "IServiceBase.cs"), 'w', encoding='utf-8') as f:
    f.write("""using System.Collections.Generic;
using System.Threading.Tasks;

namespace CuratorJournal.DataAccess.Services.Interfaces.Base
{
    public interface IServiceBase<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
""")

# ServiceBase.cs
with open(os.path.join(project_path, "Services", "Implementation", "Base", "ServiceBase.cs"), 'w', encoding='utf-8') as f:
    f.write("""using CuratorJournal.DataAccess.Repositories.Interfaces.Base;
using CuratorJournal.DataAccess.Services.Interfaces.Base;

namespace CuratorJournal.DataAccess.Services.Implementation.Base
{
    public class ServiceBase<T> : IServiceBase<T> where T : class
    {
        private readonly IRepositoryBase<T> _repository;

        public ServiceBase(IRepositoryBase<T> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<T> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
        public async Task<T> CreateAsync(T entity) => await _repository.AddAsync(entity);
        public async Task UpdateAsync(T entity) => await _repository.UpdateAsync(entity);
        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
    }
}
""")

# --- Генерация конкретных репозиториев и сервисов ---
for model in models:
    # IModelRepository.cs
    repo_interface_path = os.path.join(project_path, "Repositories", "Interfaces", f"I{model}Repository.cs")
    with open(repo_interface_path, 'w', encoding='utf-8') as f:
        f.write(f"""using CuratorJournal.DataAccess.Models;
using CuratorJournal.DataAccess.Repositories.Interfaces.Base;

namespace CuratorJournal.DataAccess.Repositories.Interfaces
{{
    public interface I{model}Repository : IRepositoryBase<{model}>
    {{
    }}
}}
""")

    # ModelRepository.cs
    repo_impl_path = os.path.join(project_path, "Repositories", "Implementation", f"{model}Repository.cs")
    with open(repo_impl_path, 'w', encoding='utf-8') as f:
        f.write(f"""using CuratorJournal.DataAccess.Models;
using CuratorJournal.DataAccess.Repositories.Interfaces;
using CuratorJournal.DataAccess.Repositories.Implementation.Base;
using CuratorJournal.DataAccess.Database;

namespace CuratorJournal.DataAccess.Repositories.Implementation
{{
    public class {model}Repository : RepositoryBase<{model}>, I{model}Repository
    {{
        public {model}Repository(ApplicationContext context) : base(context) {{ }}
    }}
}}
""")

    # IModelService.cs
    service_interface_path = os.path.join(project_path, "Services", "Interfaces", f"I{model}Service.cs")
    with open(service_interface_path, 'w', encoding='utf-8') as f:
        f.write(f"""using CuratorJournal.DataAccess.Models;
using CuratorJournal.DataAccess.Services.Interfaces.Base;

namespace CuratorJournal.DataAccess.Services.Interfaces
{{
    public interface I{model}Service : IServiceBase<{model}>
    {{
    }}
}}
""")

    # ModelService.cs
    service_impl_path = os.path.join(project_path, "Services", "Implementation", f"{model}Service.cs")
    with open(service_impl_path, 'w', encoding='utf-8') as f:
        f.write(f"""using CuratorJournal.DataAccess.Models;
using CuratorJournal.DataAccess.Services.Interfaces;
using CuratorJournal.DataAccess.Repositories.Interfaces;
using CuratorJournal.DataAccess.Services.Implementation.Base;

namespace CuratorJournal.DataAccess.Services.Implementation
{{
    public class {model}Service : ServiceBase<{model}>, I{model}Service
    {{
        public {model}Service(I{model}Repository repository) : base(repository) {{ }}
    }}
}}
""")

print("✅ Полная структура репозиториев и сервисов успешно создана.")