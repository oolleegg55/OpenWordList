namespace Owl.WpfApp.Windows.Main.Parts;

internal class WordListItemDetailsVm
{
    public WordListItemDetailsVm(Guid wordListId)
    {
        WordListId = wordListId;
    }

    public Guid WordListId { get; }
}
