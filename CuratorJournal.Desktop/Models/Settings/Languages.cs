using System.Collections.Generic;

namespace CuratorJournal.Desktop.Models.Settings;

public record Languages(
    string Name,
    List<LanguageDictionary> Words
);