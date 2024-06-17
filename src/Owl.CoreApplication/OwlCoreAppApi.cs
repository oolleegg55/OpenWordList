using System.Collections.Immutable;

using Owl.CoreApplication.ViewModels;
using Owl.Domain;
using Owl.Domain.Specifications;

namespace Owl.CoreApplication;

public class OwlCoreAppApi
{
    private readonly IWordListRepository _wordListRepository;
    private readonly IWordRepository _wordRepository;

    private readonly IWordListFactory _wordListFactory;
    private readonly IWordFactory _wordFactory;

    public OwlCoreAppApi(
        IWordListRepository wordListRepository,
        IWordRepository wordRepository,
        IWordListFactory wordListFactory,
        IWordFactory wordFactory)
    {
        _wordListRepository = wordListRepository;
        _wordRepository = wordRepository;

        _wordListFactory = wordListFactory;
        _wordFactory = wordFactory;
    }

    public async Task<WordListHeaderInfo> GetWordListHeaderAsync(Guid id)
    {
        var wordList = await _wordListRepository.GetWordListAsync(id);
        return new WordListHeaderInfo(wordList.Id, wordList.Name, 0);
    }

    public async Task<IReadOnlyList<WordListHeaderInfo>> GetWordListHeadersAsync(
        int pageNumber, int pageSize)
    {
        var headers = await _wordListRepository.GetWordListsAsync(
            new WordListsSpec { PageNumber = pageNumber, PageSize = pageSize });

        return headers
            .Select(x => new WordListHeaderInfo(x.Id, x.Name, 0))
            .ToImmutableArray();
    }

    public async Task<WordListInfo> GetWordListAsync(Guid id)
    {
        var wordList = await _wordListRepository.GetWordListAsync(id);
        return new WordListInfo(wordList.Id, wordList.Name, []);
    }

    public async Task<WordListInfo> CreateWordListAsync(string name)
    {
        var wordList = _wordListFactory.CreateWordList(name);
        await _wordListRepository.SaveWordListAsync(wordList);

        var words = await _wordRepository.GetWordsAsync(wordList.Id);

        return new WordListInfo(
            Id: wordList.Id,
            Name: wordList.Name,
            Words: words
                .Select(x => new WordInfo(x.Id, x.Value))
                .ToImmutableArray());
    }

    public async Task<WordInfo> CreateWord(CreateWordRequest request)
    {
        var wordList = await _wordListRepository.GetWordListAsync(request.WordListId);
        var word = _wordFactory.CreateWord(wordList, request.Value);

        await _wordRepository.SaveWordAsync(word);

        return new WordInfo(word.Id, word.Value);
    }
}
