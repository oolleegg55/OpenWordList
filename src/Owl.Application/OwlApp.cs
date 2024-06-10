
using Owl.Application.ViewModels;
using Owl.Domain;

namespace Owl.Application;

public class OwlApp
{
    private readonly IWordListRepository _wordListRepository;

    public OwlApp(IWordListRepository wordListRepository)
    {
        _wordListRepository = wordListRepository;
    }

    public async Task<WordListFullInfo> GetFullWordListAsync(Guid id)
    {
        var wordList = await _wordListRepository.GetWordListAsync(id);
        return new WordListFullInfo(wordList.Id, wordList.Name);
    }
}
