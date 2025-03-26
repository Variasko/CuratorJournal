using CuratorJournal.Desktop.Infrastructure.Services;

namespace CuratorJournal.Desktop.ViewModels
{
    internal class MainWindowViewModel
    {
        private readonly IUserDialog _userDialog;
        public MainWindowViewModel(IUserDialog userDialog)
        {
            _userDialog = userDialog;
        }
        public MainWindowViewModel()
        {
        }
    }
}
