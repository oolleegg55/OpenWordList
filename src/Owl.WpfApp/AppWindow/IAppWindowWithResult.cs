namespace Owl.WpfApp.AppWindow;

internal interface IAppWindowWithResult<TResult> : IAppWindow
{
    TResult Result { get; }
}
