using CuratorJournal.Desktop.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace CuratorJournal.Desktop
{
    /// <summary>
    /// Логика взаимодействия для SignInWindow.xaml
    /// </summary>
    public partial class SignInWindow : Window
    {
        public SignInWindow()
        {
            InitializeComponent();
        }

        private void PasswordEneter_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((SignInWindowViewModel)this.DataContext).Password = ((PasswordBox)sender).Password; }
        }
    }
}
