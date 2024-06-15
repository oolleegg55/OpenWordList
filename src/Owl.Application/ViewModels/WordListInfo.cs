namespace Owl.Application.ViewModels;

public record class WordListInfo(
    Guid Id,
    string Name,
    IReadOnlyList<WordInfo> Words);
