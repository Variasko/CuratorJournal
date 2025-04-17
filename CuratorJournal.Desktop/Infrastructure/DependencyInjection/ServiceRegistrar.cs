using CuratorJournal.Desktop.Infrastructure.Services;
using CuratorJournal.Desktop.Infrastructure.Services.Implementation;
using CuratorJournal.Desktop.ViewModels;
using CuratorJournal.Desktop.Views.Pages;
using CuratorJournal.Desktop.Views.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace CuratorJournal.Desktop.Infrastructure.DependencyInjection;

public static class ServiceRegistrar
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
    {
        return services
            .RegisterCoreServices()
            .RegisterViewModels()
            .RegisterWindows()
            .RegisterPages()
            .RegisterFactories();
    }

    private static IServiceCollection RegisterCoreServices(this IServiceCollection services)
    {
        services.AddSingleton<IUserDialog, UserDialogService>();
        services.AddSingleton<IDialogService, DialogService>();
        return services;
    }

    private static IServiceCollection RegisterViewModels(this IServiceCollection services)
    {
        services.AddTransient<SignInWindowViewModel>();
        services.AddTransient<MentorMainWindowViewModel>();
        services.AddTransient<ProfilePageViewModel>();
        services.AddTransient<SocialPassportPageViewModel>();
        return services;
    }

    private static IServiceCollection RegisterWindows(this IServiceCollection services)
    {
        services.AddTransient(s => new SignInWindow
        {
            DataContext = s.GetRequiredService<SignInWindowViewModel>()
        });

        services.AddTransient(s => new MentorMainWindow
        {
            DataContext = s.GetRequiredService<MentorMainWindowViewModel>()
        });

        return services;
    }

    private static IServiceCollection RegisterPages(this IServiceCollection services)
    {
        services.AddTransient(s => new ProfilePage
        {
            DataContext = s.GetRequiredService<ProfilePageViewModel>()
        });

        services.AddTransient(s => new SocialPassportPage
        {
            DataContext = s.GetRequiredService<SocialPassportPageViewModel>()
        });

        return services;
    }

    private static IServiceCollection RegisterFactories(this IServiceCollection services)
    {
        services.AddTransient<Func<ProfilePageViewModel>>(sp =>
            sp.GetRequiredService<ProfilePageViewModel>);

        services.AddTransient<Func<SocialPassportPageViewModel>>(sp =>
            sp.GetRequiredService<SocialPassportPageViewModel>);

        services.AddTransient<Func<SignInWindow>>(sp =>
            sp.GetRequiredService<SignInWindow>);

        services.AddTransient<Func<MentorMainWindow>>(sp =>
            sp.GetRequiredService<MentorMainWindow>);

        return services;
    }
}