using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Owl.WpfApp.Navigation;
using Owl.WpfApp.Windows.CreateNewWordList;
using Owl.WpfApp.Windows.Main.Parts;

namespace Owl.WpfApp.Windows.Main;

internal partial class MainVm : WindowViewModelBase, IDisposable
{
    private readonly ViewModelFactory _viewModelFactory;
    private readonly NavigationManager _navigationManager;

    private readonly Dictionary<Guid, WordListItemDetailsVm> _wordListDetailsCache = new();

    public MainVm(ViewModelFactory viewModelFactory, NavigationManager navigationManager)
    {
        _viewModelFactory = viewModelFactory;
        _navigationManager = navigationManager;
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
        var result = await _navigationManager.GoToWithResultAsync<CreateNewWordListResult>(
            Routes.CreateNewWordList, new Dictionary<string, object>(), Window);

        if (result.IsCanceled)
        {
            return;
        }


    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
