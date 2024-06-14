using System.Windows;

using Owl.WpfApp.AppWindow;

namespace Owl.WpfApp.Windows.Main;

internal partial class MainWindow : Window, IAppWindow
{
    private readonly MainVm _vm;

    public MainWindow(MainVm vm)
    {
        ArgumentNullException.ThrowIfNull(vm, nameof(MainVm));

        _vm = vm;
        _vm.Window = this;
        InitializeComponent();

        DataContext = _vm;
    }

    IAppWindow IAppWindow.Owner { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    protected override void OnInitialized(EventArgs e)
    {
        base.OnInitialized(e);
        _vm.OnInitialized();
    }
}
