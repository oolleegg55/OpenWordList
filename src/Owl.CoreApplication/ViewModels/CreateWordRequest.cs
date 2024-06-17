namespace Owl.CoreApplication.ViewModels;

public record class CreateWordRequest(
    Guid WordListId,
    string Value);
