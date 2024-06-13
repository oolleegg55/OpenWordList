using System.Windows;

namespace Owl.WpfApp.Windows.CreateNewWordList;

internal partial class CreateNewWordListWindow : Window
{
    private readonly CreateNewWordListVm _vm;

    public CreateNewWordListWindow(CreateNewWordListVm vm)
    {
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
