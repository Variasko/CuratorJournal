using System.Collections.Generic;

namespace CuratorJournal.Desktop.Models.Settings
{
    public class LanguageDictionary
    {
        public Dictionary<string, Dictionary<string, string>> Translations { get; set; }
            = new Dictionary<string, Dictionary<string, string>>();
    }
}
