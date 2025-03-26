using CuratorJournal.Desktop.Infrastructure.Commands.Base;

namespace CuratorJournal.Desktop.Infrastructure.Commands
{
    internal class Logout : Command
    {
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            
        }
    }
}
