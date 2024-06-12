using System.Diagnostics.CodeAnalysis;
using System.Windows;

using CommunityToolkit.Mvvm.ComponentModel;

namespace Owl.WpfApp;

internal abstract class BaseViewModel : ObservableObject
{
    [NotNull]
    public Window? Window { get; set; }

    public abstract void OnInitialized();

    internal void InitializeWithParameters(IDictionary<string, object> parameters)
    {
        throw new NotImplementedException();
    }
}
