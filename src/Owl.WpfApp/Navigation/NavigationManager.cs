using System.Collections.Concurrent;

using Microsoft.Extensions.DependencyInjection;

using Owl.WpfApp.AppWindow;

namespace Owl.WpfApp.Navigation;

class NavigationManager
{
    private readonly IServiceProvider _serviceProvider;
    private IAppWindow? _parentWindow;
    private static readonly ConcurrentDictionary<string, Type> s_routes = new();

    public NavigationManager(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public void RegisterRoute(string route, Type type)
    {
        s_routes.TryAdd(route, type);
    }

    public void SetParentWindow(IAppWindow parentWindow)
    {
        _parentWindow = parentWindow;
    }

    public Task<TResult> GoToWithResultAsync<TResult>(
        string route,
        IDictionary<string, object> parameters,
        IAppWindow parentWindow)
    {
        if (!s_routes.TryGetValue(route, out var windowType))
        {
            throw new InvalidOperationException($"No window registered for route '{route}'");
        }

        if (!typeof(IAppWindowWithResult<TResult>).IsAssignableFrom(windowType))
        {
            throw new InvalidOperationException($"Type '{windowType}' is not a IAppWindow");
        }

        var window = (IAppWindowWithResult<TResult>)_serviceProvider.GetRequiredService(windowType);
        window.Owner = parentWindow;

        if (window.DataContext is WindowViewModelBase typedVm)
        {
            typedVm.InitializeWithParameters(parameters);
            typedVm.Window = window;
        }

        var tcs = new TaskCompletionSource<TResult>();

        try
        {
            window.Closed += (w, _) =>
            {
                tcs.SetResult((w as IAppWindowWithResult<TResult>)!.Result);
            };

            window.Show();
        }
        catch (Exception ex)
        {
            tcs.SetException(ex);
        }

        return tcs.Task;
    }
}
