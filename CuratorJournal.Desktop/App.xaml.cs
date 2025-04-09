﻿using System;
using System.Windows;
using CuratorJournal.Desktop.Infrastructure.Commands;
using CuratorJournal.Desktop.Infrastructure.Services;
using CuratorJournal.Desktop.Infrastructure.Services.Implementation;
using CuratorJournal.Desktop.ViewModels;
using CuratorJournal.Desktop.Views.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace CuratorJournal.Desktop;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private static IServiceProvider _Services;

    public static IServiceProvider Services => _Services ?? InitializeServices().BuildServiceProvider();

    public static IServiceCollection InitializeServices()
    {
        var services = new ServiceCollection();

        services.AddSingleton<IUserDialog, UserDialogService>();

        services.AddTransient<SignInWindow>();
        services.AddTransient<SignInWindowViewModel>();
        services.AddTransient<MentorMainWindow>();
        services.AddTransient<MentorMainWindowViewModel>();



        services.AddTransient(
            s =>
            {
                var model = s.GetRequiredService<SignInWindowViewModel>();
                var window = new SignInWindow { DataContext = model };

                return window;
            });
        services.AddTransient(
            s =>
            {
                var model = s.GetRequiredService<MentorMainWindowViewModel>();
                var window = new MentorMainWindow { DataContext = model };

                return window;
            });

        return services;
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        Services.GetRequiredService<IUserDialog>().OpenSignInWindow();
    }
}