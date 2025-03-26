using CuratorJournal.Desktop.Views.Windows;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace CuratorJournal.Desktop.Infrastructure.Services.Implementation
{
    internal class UserDialogService : IUserDialog
    {
        private readonly IServiceProvider _services;

        private SignInWindow _signInWindow;
        private MainWindow _mainWindow;

        public UserDialogService(IServiceProvider services)
        {
            _services = services;
        }

        public void OpenMainWindow()
        {
            if (_mainWindow == null || !_mainWindow.IsLoaded)
            {
                CreateMainWindow();
            }

            _mainWindow.Show();
            _mainWindow.Activate();
        }

        public void OpenSignInWindow()
        {
            if (_signInWindow == null || !_signInWindow.IsLoaded)
            {
                CreateSignInWindow();
            }

            _signInWindow.Show();
            _signInWindow.Activate();
        }

        private void CreateMainWindow()
        {
            _mainWindow?.Close();

            _mainWindow = _services.GetRequiredService<MainWindow>();
            _mainWindow.Closed += (s, e) =>
            {
                _mainWindow = null;
            };
        }

        private void CreateSignInWindow()
        {
            _signInWindow?.Close();

            _signInWindow = _services.GetRequiredService<SignInWindow>();
            _signInWindow.Closed += (s, e) =>
            {
                _signInWindow = null;
            };
        }
    }
}