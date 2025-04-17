using CuratorJournal.Desktop.Models.Settings;
using Newtonsoft.Json;
using System.IO;

namespace CuratorJournal.Desktop.Helpers
{
    public sealed class SettingsHelper
    {
        private AppSettings _settings;
        private LanguageDictionary _languageDictionary;

        private static readonly Lazy<SettingsHelper> _instance = new(() => new SettingsHelper());
        public static SettingsHelper Instance => _instance.Value;

        private SettingsHelper()
        {
            _settings = LoadSettings();
            _languageDictionary = LoadLanguageDictionary();
        }

        public string GetPhrase(string key)
        {
            var language = _settings.CurrentLanguage;

            if (!_languageDictionary.Translations.TryGetValue(language, out var langDict))
                langDict = _languageDictionary.Translations.GetValueOrDefault("en");

            return langDict?.TryGetValue(key, out var phrase) == true ? phrase : $"!{key}!";
        }

        public string GetCurrentLanguage() => _settings.CurrentLanguage;

        public void SetLanguage(string languageCode)
        {
            _settings = _settings with { CurrentLanguage = languageCode };
            SaveSettings();
        }

        private AppSettings LoadSettings()
        {
            try
            {
                var path = "settings.json";

                if (File.Exists(path))
                {
                    var jsonContent = File.ReadAllText(path);
                    var settings = JsonConvert.DeserializeObject<AppSettings>(jsonContent);

                    if (settings != null)
                    {
                        return settings;
                    }
                    return new AppSettings("ru");
                }
                return new AppSettings("ru");
            }
            catch
            {
                return new AppSettings("ru");
            }
        }

        private LanguageDictionary LoadLanguageDictionary()
        {
            try
            {
                var path = "lang.json";
                if (!File.Exists(path))
                    return new LanguageDictionary(new Dictionary<string, Dictionary<string, string>>());

                var json = File.ReadAllText(path);
                var result = JsonConvert.DeserializeObject<LanguageDictionary>(json);

                if (result != null && result.Translations != null)
                {
                    return result;
                }
                return new LanguageDictionary(new Dictionary<string, Dictionary<string, string>>());
            }
            catch
            {
                return new LanguageDictionary(new Dictionary<string, Dictionary<string, string>>());
            }
        }

        private void SaveSettings()
        {
            try
            {
                File.WriteAllText("settings.json", JsonConvert.SerializeObject(_settings, Formatting.Indented));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving settings: {ex.Message}");
            }
        }
    }
}