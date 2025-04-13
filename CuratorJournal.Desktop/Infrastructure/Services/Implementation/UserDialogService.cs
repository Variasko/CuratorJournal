using CuratorJournal.Desktop.ViewModels;
using CuratorJournal.Desktop.Views.Pages;
using CuratorJournal.Desktop.Views.Windows;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace CuratorJournal.Desktop.Infrastructure.Services.Implementation
{
    internal class UserDialogService : IUserDialog
    {
        private readonly IServiceProvider _services;

        private SignInWindow _signInWindow;
        private MentorMainWindow _mentorMainWindow;

        public UserDialogService(IServiceProvider serviceProvider)
        {
            _services = serviceProvider;
        }

        public Page GetProfilePage()
        {
            var page = new ProfilePage();
            page.DataContext = _services.GetRequiredService<ProfilePageViewModel>();
            return page;
        }
        public Page GetSocialPassportPage()
        {
            var page = new SocialPassportPage();
            page.DataContext = _services.GetRequiredService<SocialPassportPageViewModel>();
            return page;
        }

        public void OpenMentorMainWindow()
        {
            if (_mentorMainWindow == null || !_mentorMainWindow.IsLoaded)
            {
                CreateMentorMainWindow();
            }
            _mentorMainWindow.Show();
            _signInWindow?.Close();
            _mentorMainWindow.Activate();
        }

        public void OpenSignInWindow()
        {
            if (_signInWindow == null || !_signInWindow.IsLoaded)
            {
                CreateSignInWindow();
            }

            _signInWindow.Show();
            _mentorMainWindow?.Close();
            _signInWindow.Activate();
        }
        private void CreateMentorMainWindow()
        {
            _mentorMainWindow?.Close();

            _mentorMainWindow = _services.GetRequiredService<MentorMainWindow>();
            _mentorMainWindow.Closed += (s, e) =>
            {
                _mentorMainWindow = null;
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
