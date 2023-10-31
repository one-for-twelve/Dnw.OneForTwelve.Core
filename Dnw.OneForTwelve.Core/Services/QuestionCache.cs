using Dnw.OneForTwelve.Core.Models;
using Dnw.OneForTwelve.Core.Repositories;

namespace Dnw.OneForTwelve.Core.Services;

internal interface IQuestionCache
{
    Question? GetRandom(string firstLetterAnswer, QuestionCategories category, QuestionLevels level, HashSet<int> invalidQuestionIds);
}

internal class QuestionCache : IQuestionCache, IInitCache
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IRandomService _randomService;
    private Dictionary<string, List<Question>> _questionsByFirstLetterAnswer = new();

    public QuestionCache(IQuestionRepository questionRepository, IRandomService randomService)
    {
        _questionRepository = questionRepository;
        _randomService = randomService;
    }

    public Question? GetRandom(string firstLetterAnswer, QuestionCategories category, QuestionLevels level, HashSet<int> invalidQuestionIds)
    {
        if (!_questionsByFirstLetterAnswer.TryGetValue(firstLetterAnswer, out var questionsWithFirstLetterAnswer))
        {
            return null;
        }
        
        var possibleQuestions =
            questionsWithFirstLetterAnswer.Where(q => q.Category == category && q.Level == level && !invalidQuestionIds.Contains(q.Id)).ToList();

        if (!possibleQuestions.Any()) return null;

        var randomQuestionIndex = _randomService.Next(0, possibleQuestions.Count);
        return possibleQuestions[randomQuestionIndex];
    }
    
    public void Init()
    {
        _questionsByFirstLetterAnswer = _questionRepository.GetQuestions().GroupBy(q => q.FirstLetterAnswer).ToDictionary(g => g.Key, g => g.ToList());
    }
}