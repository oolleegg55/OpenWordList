namespace Owl.Application.ViewModels;

public record class CreateWordRequest(
    Guid WordListId,
    string Value);
