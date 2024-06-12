using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Owl.WpfApp.Windows.CreateNewWordList;
using Owl.WpfApp.Windows.Main.Parts;

namespace Owl.WpfApp.Windows.Main;

internal partial class MainVm : BaseViewModel, IDisposable
{
    private readonly ViewModelFactory _viewModelFactory;
    private readonly WindowManager _windowManager;

    private readonly Dictionary<Guid, WordListItemDetailsVm> _wordListDetailsCache = new();

    public MainVm(ViewModelFactory viewModelFactory, WindowManager windowManager)
    {
        _viewModelFactory = viewModelFactory;
        _windowManager = windowManager;
    }

    public override void OnInitialized()
    {
        WordLists.Add(new WordListItemVm(Guid.NewGuid(), "My List 1"));
        WordLists.Add(new WordListItemVm(Guid.NewGuid(), "My List 2"));
    }

    public ObservableCollection<WordListItemVm> WordLists { get; } = new();

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(WordListDetails))]
    private WordListItemVm? _selectedWordList;

    public WordListItemDetailsVm? WordListDetails
    {
        get
        {
            if (SelectedWordList is null)
            {
                return null;
            }

            var id = SelectedWordList.WordListId;
            if (_wordListDetailsCache.TryGetValue(id, out var cachedDetails))
            {
                return cachedDetails;
            }

            var details = _viewModelFactory.CreateWordListItemDetails(id);
            _wordListDetailsCache.Add(id, details);

            return details;
        }
    }

    [RelayCommand]
    private async Task CreateNewWordListAsync()
    {
        await _windowManager.OpenWindowAsync<CreateNewWordListWindow>(Window);
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
