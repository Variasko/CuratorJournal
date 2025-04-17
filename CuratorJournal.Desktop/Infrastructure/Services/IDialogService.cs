namespace CuratorJournal.Desktop.Infrastructure.Services
{
    internal interface IDialogService
    {
        bool ShowConfirmation(string message, string title = "");
    }
}
