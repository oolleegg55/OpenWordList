using Owl.Domain.Model;

namespace Owl.Domain;

public interface IWordListFactory
{
    WordList CreateWordList(string name);
}
