using System.Windows;

namespace CuratorJournal.Desktop.Infrastructure.Services.Implementation
{
    internal class DialogService : IDialogService
    {
        public bool ShowConfirmation(string message, string title = "")
        {
            var result = MessageBox.Show(
            message,
            title,
            MessageBoxButton.YesNo,
            MessageBoxImage.Question
        );
            return result == MessageBoxResult.Yes;
        }
    }
}
