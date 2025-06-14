import os

# Путь к Models
project_path = os.getcwd()
models_dir = os.path.join(project_path, "Models")
os.makedirs(models_dir, exist_ok=True)

# --- Модели, которые нужно создать ---
missing_models = {
    "GroupPost": {
        "request": {
            "fields": [
                ("Name", "string"),
            ]
        },
        "response": {
            "fields": [
                ("PostId", "int"),
                ("Name", "string"),
            ]
        }
    },
    "Student": {
        "request": {
            "fields": [
                ("IsDeduction", "bool?"),
                ("DateDeduction", "DateOnly"),
            ]
        },
        "response": {
            "fields": [
                ("StudentId", "int"),
                ("IsDeduction", "bool?"),
                ("DateDeduction", "DateOnly"),
            ]
        }
    },
    "StudentHobby": {
        "request": {
            "fields": [
                ("StudentId", "int"),
                ("HobbyId", "int"),
            ]
        },
        "response": {
            "fields": [
                ("StudentId", "int"),
                ("HobbyId", "int"),
            ]
        }
    },
    "StudentParent": {
        "request": {
            "fields": [
                ("StudentId", "int"),
                ("ParentId", "int"),
            ]
        },
        "response": {
            "fields": [
                ("StudentId", "int"),
                ("ParentId", "int"),
            ]
        }
    },
    "StudentSocialStatus": {
        "request": {
            "fields": [
                ("StudentId", "int"),
                ("SocialStatusId", "int"),
            ]
        },
        "response": {
            "fields": [
                ("StudentId", "int"),
                ("SocialStatusId", "int"),
            ]
        }
    },
    "StudentStudyGroup": {
        "request": {
            "fields": [
                ("StudentId", "int"),
                ("StudyGroupId", "int"),
            ]
        },
        "response": {
            "fields": [
                ("StudentId", "int"),
                ("StudyGroupId", "int"),
            ]
        }
    },
    "StudyGroupPost": {
        "request": {
            "fields": [
                ("StudentId", "int"),
                ("PostId", "int"),
            ]
        },
        "response": {
            "fields": [
                ("StudentId", "int"),
                ("PostId", "int"),
            ]
        }
    }
}

NAMESPACE = "CuratorJournal.Desktop.Models"

# --- Генерация файлов ---
for model_name, types in missing_models.items():
    for suffix, data in types.items():
        filename = f"{model_name}{suffix[0].upper() + suffix[1:]}.cs"
        filepath = os.path.join(models_dir, filename)

        with open(filepath, "w", encoding="utf-8") as f:
            f.write(f"namespace {NAMESPACE};\n\npublic class {model_name}{suffix.capitalize()}\n{{\n")

            for field_name, field_type in data["fields"]:
                f.write(f"    public {field_type} {field_name} {{ get; set; }}\n")

            f.write("}\n")

print("✅ Все недостающие модели успешно созданы.")