using Owl.Domain;
using Owl.Domain.Model;
using Owl.Domain.Specifications;

namespace Owl.Infrastructure;

public class MemoryWordListRepository : IWordListRepository
{
    public Task DeleteWordListAsync(Guid wordListId)
    {
        throw new NotImplementedException();
    }

    public Task<WordList> GetWordListAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<WordList>> GetWordListsAsync(WordListsSpec spec)
    {
        throw new NotImplementedException();
    }

    public Task<WordList> SaveWordListAsync(WordList wordList)
    {
        throw new NotImplementedException();
    }
}
