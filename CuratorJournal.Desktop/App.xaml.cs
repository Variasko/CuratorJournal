using CuratorJournal.Desktop.Infrastructure.DependencyInjection;
using CuratorJournal.Desktop.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace CuratorJournal.Desktop
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            InitializeServices().GetRequiredService<IUserDialog>().OpenSignInWindow();
        }

        private static IServiceProvider InitializeServices()
        {
            var services = new ServiceCollection();
            services.RegisterApplicationServices();
            return services.BuildServiceProvider();
        }
    }
}