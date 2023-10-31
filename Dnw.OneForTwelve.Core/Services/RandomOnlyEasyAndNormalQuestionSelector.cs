using Dnw.OneForTwelve.Core.Models;

namespace Dnw.OneForTwelve.Core.Services;

internal class RandomOnlyEasyAndNormalQuestionSelector : IQuestionSelector
{
    private readonly IQuestionSelectorHelper _questionSelectorHelper;
    
    public QuestionSelectionStrategies Strategy => QuestionSelectionStrategies.RandomOnlyEasyAndNormal;
    
    public RandomOnlyEasyAndNormalQuestionSelector(IQuestionSelectorHelper questionSelectorHelper)
    {
        _questionSelectorHelper = questionSelectorHelper;
    }
    
    public List<GameQuestion> GetQuestions(string word)
    {
        return _questionSelectorHelper.GetQuestions(word, Categories, Levels);
    }
    
    internal static readonly QuestionCategories[] Categories =
    {
        QuestionCategories.Geography,
        QuestionCategories.Geography,
        QuestionCategories.Biology,
        QuestionCategories.Cryptic,
        QuestionCategories.Economy,
        QuestionCategories.History,
        QuestionCategories.Art,
        QuestionCategories.Literature,
        QuestionCategories.Music,
        QuestionCategories.Politics,
        QuestionCategories.Sports,
        QuestionCategories.ScienceOrMaths
    };

    private static readonly IEnumerable<QuestionLevels> EasyLevels = Enumerable.Range(0, 6).Select(_ => QuestionLevels.Easy);
    private static readonly IEnumerable<QuestionLevels> NormalLevels = Enumerable.Range(0, 6).Select(_ => QuestionLevels.Normal);
    
    internal static readonly QuestionLevels[] Levels = EasyLevels.Concat(NormalLevels).ToArray();
}