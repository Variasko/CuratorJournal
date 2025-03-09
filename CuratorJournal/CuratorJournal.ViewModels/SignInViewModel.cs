using System.Windows.Input;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace CuratorJournal.ViewModels
{
    public class SignInViewModel : ViewModelBase
    {

		private string _login;

		private string _password;
        public ICommand SignInCommand { get; }

        public SignInViewModel()
        {
            SignInCommand = new RelayCommand(SignIn, CanExecuteSignIn);
        }

        public string Password
		{
			get { return _password; }
			set 
            { 
                _password = value;
                OnPropertyChanged();
                RaiseCommandCanExecute(SignInCommand);
            }
		}

		public string Login
		{
			get { return _login; }
			set 
            { 
                _login = value;
                OnPropertyChanged();
                RaiseCommandCanExecute(SignInCommand);
            }
		}

        private bool CanExecuteSignIn(object parameter)
        {
            return !string.IsNullOrWhiteSpace(Login)
                && !string.IsNullOrWhiteSpace(Password);
        }

        private void SignIn(object parameter)
        {
            
        }
    }
}
