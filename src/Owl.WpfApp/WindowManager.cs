using System.Diagnostics;
using System.Windows;

using Microsoft.Extensions.DependencyInjection;

namespace Owl.WpfApp;

class WindowManager
{
    private readonly IServiceProvider _serviceProvider;

    public WindowManager(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public T OpenWindow<T>(
        Window? parentWindow)
        where T : Window
    {
        return OpenWindow<T>(new Dictionary<string, object>(), parentWindow);
    }

    public T OpenWindow<T>(
        IDictionary<string, object> parameters,
        Window? parentWindow)
        where T : Window
    {
        return OpenWindow<T>(parameters, parentWindow, isDialog: false);
    }

    public T OpenWindowDialog<T>(
        IDictionary<string, object> parameters,
        Window parentWindow)
        where T : Window
    {
        return OpenWindow<T>(parameters, parentWindow, isDialog: true);
    }

    public Task<TWindow> OpenWindowAsync<TWindow>(
        Window parentWindow)
        where TWindow : Window
    {
        return OpenWindowAsync<TWindow>(new Dictionary<string, object>(), parentWindow);
    }

    public Task<TWindow> OpenWindowAsync<TWindow>(
        IDictionary<string, object> parameters,
        Window? parentWindow)
        where TWindow : Window
    {
        var window = _serviceProvider.GetRequiredService<TWindow>();
        window.Owner = parentWindow;

        if (window.DataContext is BaseViewModel typedVm)
        {
            typedVm.InitializeWithParameters(parameters);
            typedVm.Window = window;
        }

        var tcs = new TaskCompletionSource<TWindow>();

        try
        {
            window.Closed += (w, _) =>
            {
                tcs.SetResult((TWindow)w!);
            };

            window.Show();
        }
        catch (Exception ex)
        {
            tcs.SetException(ex);
        }

        return tcs.Task;
    }

    private T OpenWindow<T>(
        IDictionary<string, object> parameters,
        Window? parentWindow,
        bool isDialog)
        where T : Window
    {
        var window = _serviceProvider.GetRequiredService<T>();
        window.Owner = parentWindow;

        if (window.DataContext is BaseViewModel typedVm)
        {
            typedVm.InitializeWithParameters(parameters);
        }

        if (isDialog)
        {
            Debug.Assert(window.Owner is not null);
            window.ShowDialog();
        }
        else
        {
            window.Show();
        }

        return window;
    }
}
