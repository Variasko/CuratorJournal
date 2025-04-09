using System.Collections.Generic;

namespace CuratorJournal.Desktop.Models.Settings;

public record LanguageDictionary(
    Dictionary<string, Dictionary<string, string>> Translations
)
{
    public LanguageDictionary()
        : this(new Dictionary<string, Dictionary<string, string>>())
    {
    }
}