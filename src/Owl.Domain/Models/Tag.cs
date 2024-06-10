namespace Owl.Domain.Model;

public class Tag : IEquatable<Tag>
{
    public required string Name { get; init; }
    public string Description { get; init; } = string.Empty;

    public bool Equals(Tag? other)
    {
        if (other is null)
            return false;

        return Name == other.Name;
    }
}
