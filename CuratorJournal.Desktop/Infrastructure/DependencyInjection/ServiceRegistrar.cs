using CuratorJournal.Desktop.ApiConnectors;
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
            .RegisterConnectors()
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
    private static IServiceCollection RegisterConnectors(this IServiceCollection services)
    {
        services.AddSingleton<UserConnector>();
        return services;
    }

    private static IServiceCollection RegisterViewModels(this IServiceCollection services)
    {
        services.AddTransient<SignInWindowViewModel>();
        services.AddTransient<MentorMainWindowViewModel>();
        services.AddTransient<ProfilePageViewModel>();
        services.AddTransient<SocialPassportPageViewModel>();
        services.AddTransient<DormitoryPageViewModel>();
        services.AddTransient<ParentConferencePageViewModel>();
        services.AddTransient<ClassHourPageViewModel>();
        services.AddTransient<CharacteristicPageViewModel>();
        services.AddTransient<HobiePageViewModel>();
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
        services.AddTransient(s => new DormitoryPage
        {
            DataContext = s.GetRequiredService<DormitoryPageViewModel>()
        });
        services.AddTransient(s => new ParentConferencePage
        {
            DataContext = s.GetRequiredService<ParentConferencePageViewModel>()
        });
        services.AddTransient(s => new ClassHourPage
        {
            DataContext = s.GetRequiredService<ClassHourPageViewModel>()
        });
        services.AddTransient(s => new CharacteristicPage
        {
            DataContext = s.GetRequiredService<CharacteristicPageViewModel>()
        });
        services.AddTransient(s => new HobiePage
        {
            DataContext = s.GetRequiredService<HobiePageViewModel>()
        });

        return services;
    }

    private static IServiceCollection RegisterFactories(this IServiceCollection services)
    {
        services.AddTransient<Func<ProfilePageViewModel>>(sp =>
            sp.GetRequiredService<ProfilePageViewModel>);

        services.AddTransient<Func<SocialPassportPageViewModel>>(sp =>
            sp.GetRequiredService<SocialPassportPageViewModel>);

        services.AddTransient<Func<DormitoryPageViewModel>>(sp =>
            sp.GetRequiredService<DormitoryPageViewModel>);

        services.AddTransient<Func<ParentConferencePageViewModel>>(sp =>
        sp.GetRequiredService<ParentConferencePageViewModel>);

        services.AddTransient<Func<ClassHourPageViewModel>>(sp =>
            sp.GetRequiredService<ClassHourPageViewModel>);

        services.AddTransient<Func<CharacteristicPageViewModel>>(sp =>
            sp.GetRequiredService<CharacteristicPageViewModel>);

        services.AddTransient<Func<HobiePageViewModel>>(sp =>
            sp.GetRequiredService<HobiePageViewModel>);

        services.AddTransient<Func<SignInWindow>>(sp =>
            sp.GetRequiredService<SignInWindow>);

        services.AddTransient<Func<MentorMainWindow>>(sp =>
            sp.GetRequiredService<MentorMainWindow>);

        return services;
    }
}