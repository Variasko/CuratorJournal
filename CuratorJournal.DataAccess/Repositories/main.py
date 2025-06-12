import os

# Список классов для генерации репозиториев
classes = [
    "ClassHour",
    "CuratorCharacteristic",
    "Direction",
    "GroupPost",
    "Hobby",
    "IndividualWork",
    "Language",
    "Parent",
    "ParentMeeting",
    "Person",
    "SocialStatus",
    "Specialization",
    "Student",
    "StudentClassHour",
    "StudentInDormitory",
    "StudyGroup",
    "TeacherCategory",
    "Translation",
    "TranslationKey",
    "User"
]

# Корневая директория проекта
base_dir = os.getcwd()

# Пути к директориям
interfaces_dir = os.path.join(base_dir, "Interfaces")
implementations_dir = os.path.join(base_dir, "Implementations")
interfaces_base_dir = os.path.join(interfaces_dir, "Base")
implementations_base_dir = os.path.join(implementations_dir, "Base")

# Создаем директории, если их нет
os.makedirs(interfaces_dir, exist_ok=True)
os.makedirs(implementations_dir, exist_ok=True)
os.makedirs(interfaces_base_dir, exist_ok=True)
os.makedirs(implementations_base_dir, exist_ok=True)

# Шаблон для интерфейса репозитория
interface_template = """using CuratorJournal.DataAccess.Models;
using CuratorJournal.DataAccess.Repositories.Interfaces.Base;

namespace CuratorJournal.DataAccess.Repositories.Interfaces
{{
    public interface I{class_name}Repository : IBaseRepository<{class_name}>
    {{
    }}
}}
"""

# Шаблон для реализации репозитория
implementation_template = """using CuratorJournal.DataAccess.Database;
using CuratorJournal.DataAccess.Models;
using CuratorJournal.DataAccess.Repositories.Implementations.Base;
using CuratorJournal.DataAccess.Repositories.Interfaces;

namespace CuratorJournal.DataAccess.Repositories.Implementations
{{
    public class {class_name}Repository : BaseRepository<{class_name}>, I{class_name}Repository
    {{
        public {class_name}Repository(ApplicationContext context)
            : base(context) {{ }}
    }}
}}
"""

# Генерация файлов
for class_name in classes:
    # Генерация интерфейса
    interface_path = os.path.join(interfaces_dir, f"I{class_name}Repository.cs")
    if not os.path.exists(interface_path):
        with open(interface_path, "w", encoding="utf-8") as f:
            f.write(interface_template.format(class_name=class_name))
    
    # Генерация реализации
    implementation_path = os.path.join(implementations_dir, f"{class_name}Repository.cs")
    if not os.path.exists(implementation_path):
        with open(implementation_path, "w", encoding="utf-8") as f:
            f.write(implementation_template.format(class_name=class_name))

print("Генерация репозиториев завершена!")