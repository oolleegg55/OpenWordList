using Owl.Domain.Model;
using Owl.Domain.Specifications;

namespace Owl.Domain;

public interface IWordListRepository
{
    Task<WordList> GetWordListAsync(Guid id);

    Task<IEnumerable<WordList>> GetWordListsAsync(WordListsSpec spec);

    Task<WordList> SaveWordListAsync(WordList wordList);

    Task DeleteWordListAsync(Guid wordListId);
}
