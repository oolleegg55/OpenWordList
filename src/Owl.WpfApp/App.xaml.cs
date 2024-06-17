using System.Windows;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Owl.CoreApplication.Integration;
using Owl.WpfApp.Navigation;
using Owl.WpfApp.Windows.CreateNewWordList;
using Owl.WpfApp.Windows.Main;

namespace Owl.WpfApp;

public partial class App : Application
{
    private readonly IHost _host;

    public App()
    {
        IHostBuilder hostBuilder = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddTransient<ViewModelFactory>();
                services.AddTransient<NavigationManager>();

                services.AddTransient<MainWindow>();
                services.AddTransient<MainVm>();

                services.AddTransient<CreateNewWordListWindow>();
                services.AddTransient<CreateNewWordListVm>();
            });

        hostBuilder.AddOwlCoreApp();

        _host = hostBuilder.Build();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        _host.Start();

        var navigationManager = _host.Services.GetRequiredService<NavigationManager>();
        navigationManager.RegisterRoute(Routes.CreateNewWordList, typeof(CreateNewWordListWindow));

        var mainWindow = _host.Services.GetRequiredService<MainWindow>();
        MainWindow = mainWindow;

        mainWindow.Show();
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        base.OnExit(e);
        // Dispose of the host on exit
        await _host.StopAsync(TimeSpan.FromSeconds(5));
        _host.Dispose();
    }
}
