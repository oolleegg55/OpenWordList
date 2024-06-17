using Owl.Domain;
using Owl.Domain.Model;

namespace Owl.Infrastructure;

public class DefaultWordListFactory : IWordListFactory
{
    public WordList CreateWordList(string name)
    {
        return new WordList
        {
            Id = Guid.NewGuid(),
            Name = name
        };
    }
}
