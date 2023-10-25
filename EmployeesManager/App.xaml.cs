using EmployeesManager.Helpers;
using EmployeesManager.Repositories;
using EmployeesManager.Repositories.Interfaces;
using EmployeesManager.Services;
using EmployeesManager.Services.Interfaces;
using EmployeesManager.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace EmployeesManager
{
    public partial class App : Application
    {
        public static IHost? AppHost { get; private set; }

        public App()
        {
            AppHost = Host
                .CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton<MainWindow>();
                    services.AddSingleton<MainWindowViewModel>();
                    services.AddScoped<IEmployeesRepository, EmployeesRepository>();
                    services.AddScoped<IEmployeesService, EmployeesService>();
                    services.AddSingleton<Mapper>();
                    services.AddSingleton<IDialogService, DialogService>();
                    services.AddHttpClient();
                })
                .Build();

        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost.StartAsync();

            var startupForm = AppHost.Services.GetRequiredService<MainWindow>();
            startupForm.Show();

            base.OnStartup(e);
        }
    }
}
