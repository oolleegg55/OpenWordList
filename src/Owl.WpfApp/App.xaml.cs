using System.Windows;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Owl.WpfApp.Windows.Main;

namespace Owl.WpfApp;

public partial class App : Application
{
    private readonly IHost _host;

    public App()
    {
        _host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddTransient<MainWindow>();
                services.AddTransient<MainVm>();
            })
            .Build();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        _host.Start();

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
