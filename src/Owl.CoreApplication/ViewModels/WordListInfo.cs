namespace Owl.CoreApplication.ViewModels;

public record class WordListInfo(
    Guid Id,
    string Name,
    IReadOnlyList<WordInfo> Words);
