﻿using CuratorJournal.Desktop.Infrastructure.Commands.Base;
using System.Windows;

namespace CuratorJournal.Desktop.Infrastructure.Commands
{
    internal class CloseApplicationCommand : Command
    {
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            Application.Current.Shutdown();
        }
    }
}
