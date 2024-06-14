
using Owl.Application.ViewModels;
using Owl.Domain;
using Owl.Domain.Model;

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

    public async Task<WordList> CreateWordListAsync(string name)
    {
        var newWordList = new WordList { Name = name };
        return await _wordListRepository.CreateWordListAsync(newWordList);
    }
}
