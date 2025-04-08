using System;
using System.IO;
using Newtonsoft.Json;
using CuratorJournal.Desktop.Models.Settings;
using System.Collections.Generic;

namespace CuratorJournal.Desktop.Helpers
{
    public class SettingsHelper
    {
        private readonly AppSettings _settings;
        private LanguageDictionary _languageDictionary;

        private static readonly Lazy<SettingsHelper> _instance =
            new Lazy<SettingsHelper>(() => new SettingsHelper());

        public static SettingsHelper Instance => _instance.Value;

        private SettingsHelper()
        {
            _settings = LoadSettings() ?? new AppSettings();
            _languageDictionary = LoadLanguageDictionary() ?? new LanguageDictionary();

            // Инициализация дефолтных значений если словарь пустой
            if (_languageDictionary.Translations.Count == 0)
            {
                _languageDictionary.Translations = new Dictionary<string, Dictionary<string, string>>
                {
                    ["ru"] = new Dictionary<string, string>(),
                    ["en"] = new Dictionary<string, string>()
                };
            }
        }

        public string GetPhrase(string key)
        {
            var language = _settings.CurrentLanguage;

            // Проверка на null перед обращением к словарю
            if (_languageDictionary?.Translations == null)
                return $"!{key}!";

            // Проверка существования языка
            if (!_languageDictionary.Translations.ContainsKey(language))
                language = "en"; // Fallback to English

            var langDict = _languageDictionary.Translations[language];

            // Поиск фразы с защитой от null
            return langDict != null && langDict.TryGetValue(key, out var phrase)
                ? phrase
                : $"!{key}!";
        }

        private AppSettings LoadSettings()
        {
            try
            {
                var path = "settings.json";
                return File.Exists(path)
                    ? JsonConvert.DeserializeObject<AppSettings>(File.ReadAllText(path))
                    : new AppSettings();
            }
            catch
            {
                return new AppSettings();
            }
        }

        private LanguageDictionary LoadLanguageDictionary()
        {
            try
            {
                var path = "lang.json";
                if (!File.Exists(path))
                    return new LanguageDictionary();

                var json = File.ReadAllText(path);
                var result = JsonConvert.DeserializeObject<LanguageDictionary>(json);

                // Дополнительная проверка структуры
                if (result?.Translations == null)
                {
                    result = new LanguageDictionary();
                    result.Translations["ru"] = new Dictionary<string, string>();
                    result.Translations["en"] = new Dictionary<string, string>();
                }

                return result;
            }
            catch
            {
                return new LanguageDictionary();
            }
        }
        public string GetCurrentLanguage()
        {
            return _settings.CurrentLanguage;
        }

        public void SetLanguage(string languageCode)
        {
            _settings.CurrentLanguage = languageCode;
            SaveSettings();
            _languageDictionary = LoadLanguageDictionary();
        }

        private void SaveSettings()
        {
            try
            {
                var path = "settings.json";
                var json = JsonConvert.SerializeObject(_settings, Formatting.Indented);
                File.WriteAllText(path, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving settings: {ex.Message}");
            }
        }
    }
}