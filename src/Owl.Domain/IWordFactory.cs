using Owl.Domain.Model;

namespace Owl.Domain;

public interface IWordFactory
{
    Word CreateWord(WordList wordList, string value);
}
