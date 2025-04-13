﻿using CuratorJournal.Desktop.Views.Pages;
using System.Windows.Controls;

namespace CuratorJournal.Desktop.Infrastructure.Services
{
    internal interface IUserDialog
    {
        void OpenSignInWindow();
        void OpenMentorMainWindow();
        Page GetProfilePage();
        Page GetSocialPassportPage();
    }
}
