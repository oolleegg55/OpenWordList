using System.Collections.ObjectModel;

using Owl.WpfApp.Windows.Main.Parts;

namespace Owl.WpfApp.Windows.Main;

internal class MainVm : BaseViewModel, IDisposable
{
    public override void OnInitialized()
    {
        WordLists.Add(new WordListItemVm(Guid.Empty, "My List 1"));
        WordLists.Add(new WordListItemVm(Guid.Empty, "My List 2"));
    }

    public ObservableCollection<WordListItemVm> WordLists { get; } = new();

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
