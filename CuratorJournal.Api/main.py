import os
import re

# Путь к файлу с DTO-классами
INPUT_FILE = "merged_file (1).txt"

# Регулярка для поиска классов и их свойств
CLASS_REGEX = r"public class (\w+)\s*\{([^}]*)\}"
PROPERTY_REGEX = r"required ([a-zA-Z0-9<>]+(?:\?)?) (\w+) { get; set; }|public ([a-zA-Z0-9<>]+(?:\?)?) (\w+) { get; set; }"

def extract_dto_classes(file_path):
    with open(file_path, 'r', encoding='utf-8') as f:
        content = f.read()

    classes = []

    for match in re.finditer(CLASS_REGEX, content):
        class_name = match.group(1)
        body = match.group(2)

        props = []
        for prop_match in re.finditer(PROPERTY_REGEX, body):
            # Группы: 1=тип если required, 2=имя, 3=тип без required, 4=имя
            if prop_match.group(1):
                prop_type = prop_match.group(1).strip()
                prop_name = prop_match.group(2)
                is_required = True
            else:
                prop_type = prop_match.group(3).strip()
                prop_name = prop_match.group(4)
                is_required = False

            props.append((is_required, prop_type, prop_name))

        classes.append({
            "name": class_name,
            "properties": props
        })

    return classes

def write_file(path, content):
    os.makedirs(os.path.dirname(path), exist_ok=True)
    with open(path, "w", encoding="utf-8") as f:
        f.write(content)

def generate_dtos(classes):
    for cls in classes:
        dto_name = cls["name"] + "Dto"
        dto_code = f'''using System.ComponentModel.DataAnnotations;

namespace CuratorJournal.Api.DTOs
{{
    public class {dto_name}
    {{
'''
        for is_required, prop_type, prop_name in cls["properties"]:
            if is_required:
                dto_code += "        [Required]\n"
            dto_code += f"        public {prop_type} {prop_name} {{ get; set; }}\n\n"

        dto_code += "    }\n}"

        write_file(f"DTO/{dto_name}.cs", dto_code)

def pluralize(name):
    """Простой метод для приведения имени к множественному числу"""
    if name.endswith('y'):
        return name[:-1] + "ies"
    elif name.endswith('s'):
        return name + "es"
    else:
        return name + "s"

def generate_mappers(classes):
    # IMapper interface
    mapper_interface = '''namespace CuratorJournal.Api.Mappers
{
    public interface IMapper<in TDto, out TEntity>
        where TDto : class
        where TEntity : class
    {
        TEntity Map(TDto dto);
        IEnumerable<TEntity> Map(IEnumerable<TDto> dtos);
    }
}'''
    write_file("Mappers/IMapper.cs", mapper_interface)

    for cls in classes:
        entity_name = cls["name"]
        dto_name = entity_name + "Dto"

        mapper_code = f'''using CuratorJournal.Api.DTOs;
using CuratorJournal.DataAccess.Models;

namespace CuratorJournal.Api.Mappers
{{
    public class {entity_name}Mapper : IMapper<{dto_name}, {entity_name}>
    {{
        public {entity_name} Map({dto_name} dto)
        {{
            return new {entity_name}
            {{
'''
        for _, _, prop_name in cls["properties"]:
            mapper_code += f"                {prop_name} = dto.{prop_name},\n"
        mapper_code += '''            };
        }

        public IEnumerable<''' + entity_name + '''> Map(IEnumerable<''' + dto_name + '''> dtos)
        {{
            return dtos.Select(Map);
        }}
    }
}}
'''

        write_file(f"Mappers/{entity_name}Mapper.cs", mapper_code)

def generate_controllers(classes):
    for cls in classes:
        entity_name = cls["name"]
        controller_name = entity_name + "Controller"
        dto_name = entity_name + "Dto"
        service_name = "I" + entity_name + "Service"
        folder_name = pluralize(entity_name)

        controller_code = f'''using Microsoft.AspNetCore.Mvc;
using CuratorJournal.Api.DTOs;
using CuratorJournal.Api.Mappers;
using CuratorJournal.DataAccess.Models;

namespace CuratorJournal.Api.Controllers
{{
    [ApiController]
    [Route("api/[controller]")]
    public class {controller_name} : ControllerBase
    {{
        private readonly {service_name} _service;
        private readonly IMapper<{dto_name}, {entity_name}> _mapper;

        public {controller_name}({service_name} service, IMapper<{dto_name}, {entity_name}> mapper)
        {{
            _service = service;
            _mapper = mapper;
        }}

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {{
            var entities = await _service.GetAllAsync();
            return Ok(entities);
        }}

        [HttpGet("{{id}}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {{
            var entity = await _service.GetByIdAsync(id);
            return entity == null ? NotFound() : Ok(entity);
        }}

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] {dto_name} dto)
        {{
            var entity = _mapper.Map(dto);
            await _service.CreateAsync(entity);
            return CreatedAtAction(nameof(GetByIdAsync), new {{ id = entity.GetType().GetProperty("Id")?.GetValue(entity) }}, entity);
        }}

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] {dto_name} dto)
        {{
            var entity = _mapper.Map(dto);
            await _service.UpdateAsync(entity);
            return NoContent();
        }}

        [HttpDelete("{{id}}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {{
            await _service.DeleteAsync(id);
            return NoContent();
        }}
    }}
}}
'''

        write_file(f"Controllers/{folder_name}/{controller_name}.cs", controller_code)

def main():
    print("[INFO] Чтение DTO моделей...")
    classes = extract_dto_classes(INPUT_FILE)

    print("[INFO] Создание папок и DTO...")
    generate_dtos(classes)

    print("[INFO] Создание мапперов...")
    generate_mappers(classes)

    print("[INFO] Создание контроллеров...")
    generate_controllers(classes)

    print("[OK] Успешно завершено: созданы DTO, мапперы и контроллеры")

if __name__ == "__main__":
    main()