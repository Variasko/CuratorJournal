using CuratorJournal.Desktop.Infrastructure.Services;

namespace CuratorJournal.Desktop.ViewModels
{
    internal class MainWindowViewModel
    {
        public MainWindowViewModel()
        {

        }
        private readonly IUserDialog _userDialog;
        public MainWindowViewModel(IUserDialog userDialog) : this()
        {
            _userDialog = userDialog;
        }
    }
}
