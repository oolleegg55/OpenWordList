namespace Owl.Domain.Model;

public class Word
{
    public Guid Id { get; init; }

    public Guid WordListId { get; init; }

    public required string Value { get; init; }
}
