namespace Owl.Domain.Model;

public class WordList
{
    public Guid Id { get; init; }

    public required string Name { get; init; }

    public IReadOnlySet<Tag> Tags { get; init; } = new HashSet<Tag>();

    public int WordCount { get; init; }
}
