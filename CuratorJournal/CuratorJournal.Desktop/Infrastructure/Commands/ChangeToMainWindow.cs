using CuratorJournal.Desktop.Infrastructure.Commands.Base;

namespace CuratorJournal.Desktop.Infrastructure.Commands
{
    internal class ChangeToMainWindow : Command
    {
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            
        }
    }
}
