using CommunityToolkit.Mvvm.ComponentModel;

namespace Owl.WpfApp;

internal abstract class BaseViewModel : ObservableObject
{
    public abstract void OnInitialized();
}
