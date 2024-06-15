using Owl.Domain;
using Owl.Domain.Model;

namespace Owl.Application.Factories;

public class WordListFactory : IWordListFactory
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
