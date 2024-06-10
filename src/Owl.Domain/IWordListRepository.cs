using Owl.Domain.Model;
using Owl.Domain.Specifications;

namespace Owl.Domain;

public interface IWordListRepository
{
    Task<WordList> GetWordListAsync(Guid id);
    Task<IEnumerable<WordList>> GetWordListsAsync(WordListsSpec spec);
    Task<WordList> CreateWordListAsync(WordList wordList);
    Task<WordList> UpdateWordListAsync(WordList wordList);
    Task DeleteWordListAsync(Guid wordListId);
}
