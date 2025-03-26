using System;
using System.Windows;
using CuratorJournal.Desktop.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace CuratorJournal.Desktop
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static IServiceProvider _Services;

        public static IServiceProvider Services => _Services ?? InitializeServices().BuildServiceProvider();

        public static IServiceCollection InitializeServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<SignInWindowViewModel>();
            services.AddSingleton<MainWindowViewModel>();

            services.AddTransient<ProfilePageViewModel>();

            return services;
        }
    }
}
