using System.Diagnostics.CodeAnalysis;

using CommunityToolkit.Mvvm.ComponentModel;

using Owl.WpfApp.AppWindow;

namespace Owl.WpfApp;

internal abstract class WindowViewModelBase : ObservableObject
{
    [NotNull]
    public IAppWindow? Window { get; set; }

    public virtual void OnInitialized()
    {
    }

    public virtual void InitializeWithParameters(IDictionary<string, object> parameters)
    {
    }
}
