using Dnw.OneForTwelve.Core.Repositories;

namespace Dnw.OneForTwelve.Core.Services;

internal interface IInitCache
{
    void Init();
}

internal interface IWordCache
{
    string GetRandom();
}

internal class WordCache : IWordCache, IInitCache
{
    private readonly IWordRepository _wordRepository;
    private readonly IRandomService _randomService;
    private string[] _words = Array.Empty<string>();

    public WordCache(IWordRepository wordRepository, IRandomService randomService)
    {
        _wordRepository = wordRepository;
        _randomService = randomService;
    }

    public string GetRandom()
    {
        var randomIndex = _randomService.Next(0, _words.Length);
        return _words[randomIndex];
    }
    
    public void Init()
    {
        _words = _wordRepository.GetWords().ToArray();
    }
}