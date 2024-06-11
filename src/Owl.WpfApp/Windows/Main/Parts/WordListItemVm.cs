namespace Owl.WpfApp.Windows.Main.Parts;

internal class WordListItemVm
{
    public WordListItemVm(Guid wordListId, string name)
    {
        WordListId = wordListId;
        Name = name;
    }

    public Guid WordListId { get; }

    public string Name { get; }
}
