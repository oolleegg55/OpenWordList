using System.Windows;

namespace Owl.WpfApp.Windows.Main;

internal partial class MainWindow : Window
{
    private readonly MainVm _vm;

    public MainWindow(MainVm vm)
    {
        ArgumentNullException.ThrowIfNull(vm, nameof(MainVm));

        _vm = vm;
        InitializeComponent();

        DataContext = _vm;
    }

    protected override void OnInitialized(EventArgs e)
    {
        base.OnInitialized(e);
        _vm.OnInitialized();
    }
}
