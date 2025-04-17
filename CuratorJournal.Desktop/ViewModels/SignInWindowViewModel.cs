using CuratorJournal.Desktop.Helpers;
using CuratorJournal.Desktop.Infrastructure.Commands;
using CuratorJournal.Desktop.Infrastructure.Services;
using CuratorJournal.Desktop.Models.Settings;
using CuratorJournal.Desktop.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace CuratorJournal.Desktop.ViewModels
{
    internal class SignInWindowViewModel : BaseViewModel
    {
        #region Поля

        #region Заголовок окна
        private string _title;
        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }
        #endregion

        #region Хинты
        private string _loginHint;
        public string LoginHint
        {
            get => _loginHint;
            set => Set(ref _loginHint, value);
        }

        private string _passwordHint;
        public string PasswordHint
        {
            get => _passwordHint;
            set => Set(ref _passwordHint, value);
        }
        #endregion

        #region Надписи
        private string _authLabel;
        public string AuthLabel
        {
            get => _authLabel;
            set => Set(ref _authLabel, value);
        }

        private string _signInButtonText;
        public string SignInButtonText
        {
            get => _signInButtonText;
            set => Set(ref _signInButtonText, value);
        }
        #endregion

        #region Логин
        /// <summary> Определение полей логина </summary>
        private string _login;
        public string Login
        {
            get { return _login; }
            set { Set(ref _login, value); }
        }
        #endregion

        #region Пароль
        /// <summary> Определение полей пароля </summary>
        private string _password;
        public string Password
        {
            get { return _password; }
            set { Set(ref _password, value); }
        }
        #endregion

        #region Языки
        private LanguageItem _selectedLanguage;
        public LanguageItem SelectedLanguage
        {
            get => _selectedLanguage;
            set
            {
                if (Set(ref _selectedLanguage, value) && value != null)
                {
                    SettingsHelper.Instance.SetLanguage(value.Code);
                    ReloadTranslations();
                }
            }
        }

        public ObservableCollection<LanguageItem> Languages { get; } = new ObservableCollection<LanguageItem>();
        #endregion

        #endregion

        #region Команды

        public ICommand SignInCommand { get; }

        private bool CanSignInCommandExecute(object parameter)
        {
            return !(string.IsNullOrEmpty(_login) && string.IsNullOrEmpty(_password));
        }

        private void OnSignInCommandExecute(object parameter)
        {
            /* TODO Доделать эндпоинт авторизации */
            _userDialog.OpenMentorMainWindow();
        }

        #endregion

        #region Конструктор
        public SignInWindowViewModel(IUserDialog userDialog)
        {
            SignInCommand = new LambdaCommand(OnSignInCommandExecute, CanSignInCommandExecute);
            _userDialog = userDialog;

            #region Локализация
            // Инициализация языков
            Languages.Add(new LanguageItem("ru", "Русский"));
            Languages.Add(new LanguageItem("en", "English"));

            // Установка текущего языка
            var currentLang = SettingsHelper.Instance.GetCurrentLanguage();
            SelectedLanguage = Languages.FirstOrDefault(l => l.Code == currentLang) ?? Languages.First();

            InitializeTranslations();
            #endregion
        }
        public SignInWindowViewModel() { }

        private readonly IUserDialog _userDialog;
        #endregion

        #region Функции не для View
        private void InitializeTranslations()
        {
            Title = SettingsHelper.Instance.GetPhrase("Auth");
            LoginHint = SettingsHelper.Instance.GetPhrase("Login");
            PasswordHint = SettingsHelper.Instance.GetPhrase("Password");
            AuthLabel = SettingsHelper.Instance.GetPhrase("Auth");
            SignInButtonText = SettingsHelper.Instance.GetPhrase("SignIn");
        }
        private void ReloadTranslations()
        {
            Title = SettingsHelper.Instance.GetPhrase("Auth");
            LoginHint = SettingsHelper.Instance.GetPhrase("Login");
            PasswordHint = SettingsHelper.Instance.GetPhrase("Password");
            AuthLabel = SettingsHelper.Instance.GetPhrase("Auth");
            SignInButtonText = SettingsHelper.Instance.GetPhrase("SignIn");
            OnPropertyChanged(nameof(Title));
            OnPropertyChanged(nameof(LoginHint));
            OnPropertyChanged(nameof(PasswordHint));
            OnPropertyChanged(nameof(AuthLabel));
            OnPropertyChanged(nameof(SignInButtonText));
        }
        #endregion
    }
}
