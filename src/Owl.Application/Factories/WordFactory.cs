using Owl.Domain;
using Owl.Domain.Model;

namespace Owl.Application.Factories;

public class WordFactory : IWordFactory
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
