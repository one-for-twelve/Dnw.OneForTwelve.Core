using Dnw.OneForTwelve.Core.Models;

namespace Dnw.OneForTwelve.Core.Services;

internal class RandomOnlyNormalQuestionSelector : IQuestionSelector
{
    private readonly IQuestionSelectorHelper _questionSelectorHelper;
    
    public QuestionSelectionStrategies Strategy => QuestionSelectionStrategies.RandomOnlyNormal;
    
    public List<GameQuestion> GetQuestions(string word)
    {
        return _questionSelectorHelper.GetQuestions(word, Categories, Levels);
    }

    public RandomOnlyNormalQuestionSelector(IQuestionSelectorHelper questionSelectorHelper)
    {
        _questionSelectorHelper = questionSelectorHelper;
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

    internal static readonly QuestionLevels[] Levels = Enumerable.Range(0, 12).Select(_ => QuestionLevels.Normal).ToArray();
}