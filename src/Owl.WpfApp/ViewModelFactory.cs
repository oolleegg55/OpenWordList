using Owl.WpfApp.Windows.Main.Parts;

namespace Owl.WpfApp;

internal class ViewModelFactory
{
    public WordListItemDetailsVm CreateWordListItemDetails(Guid wordListId)
    {
        return new WordListItemDetailsVm(wordListId);
    }
}
