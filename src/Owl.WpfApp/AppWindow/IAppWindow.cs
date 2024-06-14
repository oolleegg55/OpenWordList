namespace Owl.WpfApp.AppWindow;

internal interface IAppWindow
{
    IAppWindow Owner { get; set; }
    object? DataContext { get; set; }

    event EventHandler Closed;

    void Close();
    void Show();
}
