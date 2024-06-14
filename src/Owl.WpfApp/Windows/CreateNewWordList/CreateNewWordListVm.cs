using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Owl.WpfApp.Windows.CreateNewWordList;

internal partial class CreateNewWordListVm : WindowViewModelBase
{
    public bool IsCanceled { get; private set; }

    [ObservableProperty]
    private string _name = string.Empty;

    [RelayCommand]
    private void Create()
    {
        Window.Close();
    }

    [RelayCommand]
    private void Cancel()
    {
        IsCanceled = true;
        Window.Close();
    }
}
