using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Owl.CoreApplication;
using Owl.WpfApp.Navigation;
using Owl.WpfApp.Windows.CreateNewWordList;
using Owl.WpfApp.Windows.Main.Parts;

namespace Owl.WpfApp.Windows.Main;

internal partial class MainVm : WindowViewModelBase, IDisposable
{
    private readonly ViewModelFactory _viewModelFactory;
    private readonly NavigationManager _navigationManager;
    private readonly OwlCoreAppApi _api;

    private readonly Dictionary<Guid, WordListItemDetailsVm> _wordListDetailsCache = new();

    public MainVm(
        ViewModelFactory viewModelFactory,
        NavigationManager navigationManager,
        OwlCoreAppApi api)
    {
        _viewModelFactory = viewModelFactory;
        _navigationManager = navigationManager;
        _api = api;
    }

    public override async void OnInitialized()
    {
        var headers = await _api.GetWordListHeadersAsync(pageNumber: 0, pageSize: 10);

        foreach (var header in headers)
        {
            WordLists.Add(new WordListItemVm(header.Id, header.Name));
        }
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
