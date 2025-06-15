import os
import subprocess

SOLUTION_NAME = "CuratorJournal"
DATA_ACCESS_PROJECT = "CuratorJournal.DataAccess"
API_PROJECT = "CuratorJournal.API"

def run_command(command: str, cwd: str = None):
    """Выполняет shell-команду с обработкой ошибок и UTF-8 кодировкой"""
    try:
        result = subprocess.run(
            command,
            shell=True,
            cwd=cwd,
            check=True,
            text=True,
            encoding='utf-8',
            stdout=subprocess.PIPE,
            stderr=subprocess.PIPE
        )
        print(f"[OK] {command}")
        return True
    except subprocess.CalledProcessError as e:
        print(f"[ERROR] {command}\n{e.stderr}")
        return False

def create_project_structure():
    # Создаем проекты
    projects = [
        (DATA_ACCESS_PROJECT, "classlib"),
        (API_PROJECT, "webapi")
    ]

    for name, template in projects:
        if not run_command(f"dotnet new {template} -n {name} -o {name}"):
            return False

    # Добавляем проекты в решение
    if not run_command(f"dotnet sln add {DATA_ACCESS_PROJECT}/{DATA_ACCESS_PROJECT}.csproj"):
        return False
    if not run_command(f"dotnet sln add {API_PROJECT}/{API_PROJECT}.csproj"):
        return False

    # Создаем структуру папок для DataAccess
    data_access_dirs = [
        "Entities",
        "Repositories/Interfaces",
        "Repositories/Implementations",
        "Context",
        "Migrations",
        "Extensions",
        "Services/Interfaces",
        "Services/Implementations"
    ]
    
    for directory in data_access_dirs:
        path = os.path.join(DATA_ACCESS_PROJECT, directory)
        os.makedirs(path, exist_ok=True)
        print(f"Created directory: {path}")

    # Создаем базовые файлы для DataAccess
    db_context_content = """using Microsoft.EntityFrameworkCore;

namespace {0}.Context
{{
    public class AppDbContext : DbContext
    {{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {{ }}

        // Добавьте DbSet для ваших сущностей
        // public DbSet<Entity> Entities {{ get; set; }}
    }}
}}""".format(DATA_ACCESS_PROJECT)

    with open(os.path.join(DATA_ACCESS_PROJECT, "Context/AppDbContext.cs"), "w") as f:
        f.write(db_context_content)

    # Создаем структуру папок для API
    api_dirs = [
        "Controllers",
        "DTOs",
        "Middleware",
        "Profiles",
        "Extensions"
    ]
    
    for directory in api_dirs:
        path = os.path.join(API_PROJECT, directory)
        os.makedirs(path, exist_ok=True)
        print(f"Created directory: {path}")

    # Обновляем Program.cs для API
    program_content = """var builder = WebApplication.CreateBuilder(args);

// Добавление DataAccess
builder.Services.AddDataAccess(builder.Configuration.GetConnectionString("DefaultConnection"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();"""

    with open(os.path.join(API_PROJECT, "Program.cs"), "w") as f:
        f.write(program_content)

    # Добавляем зависимость API от DataAccess
    csproj_path = os.path.join(API_PROJECT, f"{API_PROJECT}.csproj")
    with open(csproj_path, "a") as f:
        f.write(f"\n  <ItemGroup>\n    <ProjectReference Include=\"..\\{DATA_ACCESS_PROJECT}\\{DATA_ACCESS_PROJECT}.csproj\" />\n  </ItemGroup>\n")

    return True

if __name__ == "__main__":
    if not run_command("dotnet --version"):
        print("Пожалуйста, установите .NET SDK!")
        exit(1)

    if not os.path.exists(f"{SOLUTION_NAME}.sln"):
        if not run_command(f"dotnet new sln -n {SOLUTION_NAME}"):
            exit(1)

    if create_project_structure():
        print("\nПроекты успешно созданы!")
        print(f"Решение: {SOLUTION_NAME}.sln")
        print(f"DataAccess: {DATA_ACCESS_PROJECT}")
        print(f"API: {API_PROJECT}")
    else:
        print("\nСоздание проектов завершилось с ошибками!")