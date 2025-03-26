using CuratorJournal.Desktop.Infrastructure.Commands.Base;
using System;

namespace CuratorJournal.Desktop.Infrastructure.Commands
{
    internal class SignInCommand : Command
    {
        public override bool CanExecute(object parameter) => false;

        public override void Execute(object parameter)
        {
                
        }
    }
}
