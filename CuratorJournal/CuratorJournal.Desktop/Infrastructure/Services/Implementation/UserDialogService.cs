using CuratorJournal.Desktop.Views.Windows;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace CuratorJournal.Desktop.Infrastructure.Services.Implementation
{
    internal class UserDialogService : IUserDialog
    {
        private readonly IServiceProvider _Services;

        private SignInWindow _SignInWindow;
        private MainWindow _MainWindow;
        public UserDialogService(IServiceProvider Services) => _Services = Services;
        public void OpenMainWindow()
        {
            if (_MainWindow != null)
            {
                _MainWindow.Show();
                return;
            }

            _MainWindow = _Services.GetRequiredService<MainWindow>();
            _MainWindow.Closed += ((s, e) => _MainWindow = null);
            _MainWindow.Show();
        }

        public void OpenSignInWindow()
        {
            if (_SignInWindow != null)
            {
                _SignInWindow.Show();
                return;
            }

            _SignInWindow = _Services.GetRequiredService<SignInWindow>();
            _SignInWindow.Closed += ((s, e) => _SignInWindow = null);
            _SignInWindow.Show();
        }
    }
}
