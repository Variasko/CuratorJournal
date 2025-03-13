using System.Windows;

namespace CuratorJournal.Desktop.ViewModels
{
    public class SignInViewModel : ViewModelBase
    {

        private string _login;
        private string _password;

        private RelayCommand _shutDown;

        private RelayCommand _signIn;

        public RelayCommand SignIn
        {
            get { return _signIn ?? new RelayCommand(SignInCommand); }
        }


        public RelayCommand ShutDown
        {
            get { return _shutDown ?? new RelayCommand(_ => Application.Current.Shutdown()); }
        }

        public string Login
        {
            get { return _login; }
            set 
            { 
                _login = value;
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get { return _password; }
            set 
            { 
                _password = value;
                OnPropertyChanged();
            }
        }

        private void SignInCommand(object parameters)
        {
            MessageBox.Show($"{Login} {Password}");
        }

    }
}
