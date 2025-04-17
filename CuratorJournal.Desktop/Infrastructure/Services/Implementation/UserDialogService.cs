using CuratorJournal.Desktop.ViewModels;
using CuratorJournal.Desktop.Views.Pages;
using CuratorJournal.Desktop.Views.Windows;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace CuratorJournal.Desktop.Infrastructure.Services.Implementation
{
    internal class UserDialogService : IUserDialog
    {
        private readonly Func<ProfilePageViewModel> _profileVmFactory;
        private readonly Func<SocialPassportPageViewModel> _socialPassportVmFactory;
        private readonly Func<SignInWindow> _signInWindowFactory;
        private readonly Func<MentorMainWindow> _mentorMainWindowFactory;

        private SignInWindow _signInWindow;
        private MentorMainWindow _mentorMainWindow;

        public UserDialogService(
        Func<ProfilePageViewModel> profileVmFactory,
        Func<SocialPassportPageViewModel> socialPassportVmFactory,
        Func<SignInWindow> signInWindowFactory,
        Func<MentorMainWindow> mentorMainWindowFactory)
        {
            _profileVmFactory = profileVmFactory;
            _socialPassportVmFactory = socialPassportVmFactory;
            _signInWindowFactory = signInWindowFactory;
            _mentorMainWindowFactory = mentorMainWindowFactory;
        }

        public Page GetProfilePage()
        {
            var page = new ProfilePage();
            page.DataContext = _profileVmFactory();
            return page;
        }

        public Page GetSocialPassportPage()
        {
            var page = new SocialPassportPage();
            page.DataContext = _socialPassportVmFactory();
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
            _mentorMainWindow = _mentorMainWindowFactory();

            _mentorMainWindow.Closed += (s, e) => _mentorMainWindow = null;
        }

        private void CreateSignInWindow()
        {
            _signInWindow?.Close();
            _signInWindow = _signInWindowFactory();

            _signInWindow.Closed += (s, e) => _signInWindow = null;
        }
    }
}
