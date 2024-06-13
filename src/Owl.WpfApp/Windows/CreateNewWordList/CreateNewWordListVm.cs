using System.Diagnostics;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Owl.WpfApp.Windows.CreateNewWordList;

internal partial class CreateNewWordListVm : BaseViewModel
{
    public override void OnInitialized()
    {
    }

    [ObservableProperty]
    private string _name = string.Empty;

    [RelayCommand]
    private Task CreateAsync()
    {
        Debug.WriteLine("CreateAsync");
        return Task.CompletedTask;
    }

    [RelayCommand]
    private void Cancel()
    {
        Debug.WriteLine("Cancel");
        Window?.Close();
    }
}
