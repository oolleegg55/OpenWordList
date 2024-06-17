using Owl.Domain;
using Owl.Domain.Model;

namespace Owl.Infrastructure;

public class MemoryWordRepository : IWordRepository
{
    public Task DeleteWordAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Word> GetWordAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Word>> GetWordsAsync(Guid wordListId)
    {
        throw new NotImplementedException();
    }

    public Task SaveWordAsync(Word word)
    {
        throw new NotImplementedException();
    }
}
