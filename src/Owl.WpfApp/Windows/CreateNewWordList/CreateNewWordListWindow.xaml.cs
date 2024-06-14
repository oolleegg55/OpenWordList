using System.Windows;

using Owl.WpfApp.AppWindow;

namespace Owl.WpfApp.Windows.CreateNewWordList;

internal partial class CreateNewWordListWindow : Window, IAppWindowWithResult<CreateNewWordListResult>
{
    private readonly CreateNewWordListVm _vm;

    public CreateNewWordListWindow(CreateNewWordListVm vm)
    {
        _vm = vm;
        InitializeComponent();

        DataContext = _vm;
    }

    public CreateNewWordListResult Result => new CreateNewWordListResult(_vm.IsCanceled, _vm.Name);

    IAppWindow IAppWindow.Owner
    {
        get => (IAppWindow)Owner;
        set
        {
            Owner = (Window)value;
        }
    }

    protected override void OnInitialized(EventArgs e)
    {
        base.OnInitialized(e);
        _vm.OnInitialized();
    }
}
