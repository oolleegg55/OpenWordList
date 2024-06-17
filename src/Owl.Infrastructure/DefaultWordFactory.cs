using Owl.Domain;
using Owl.Domain.Model;

namespace Owl.Infrastructure;

public class DefaultWordFactory : IWordFactory
{
    public Word CreateWord(WordList wordList, string value)
    {
        return new Word
        {
            Id = Guid.NewGuid(),
            WordListId = wordList.Id,
            Value = value
        };
    }
}
