
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

    public async Task<WordListInfo> GetFullWordListAsync(Guid id)
    {
        var wordList = await _wordListRepository.GetWordListAsync(id);
        return new WordListInfo(wordList.Id, wordList.Name, []);
    }

    public async Task<WordListInfo> CreateWordListAsync(string name)
    {
        var wordList = new WordList { Name = name };
        await _wordListRepository.CreateWordListAsync(wordList);

        return new WordListInfo(wordList.Id, wordList.Name, []);
    }
}
