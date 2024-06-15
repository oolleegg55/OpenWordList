using Owl.Domain.Model;

namespace Owl.Domain;

public interface IWordRepository
{
    Task<Word> GetWordAsync(Guid id);

    Task<IReadOnlyList<Word>> GetWordsAsync(Guid wordListId);

    Task SaveWordAsync(Word word);

    Task DeleteWordAsync(Guid id);
}
