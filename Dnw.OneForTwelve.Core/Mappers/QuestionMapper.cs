using Dnw.OneForTwelve.Core.Models;

namespace Dnw.OneForTwelve.Core.Mappers;

internal interface IQuestionMapper
{
    Question MapFrom(string row);
}

internal class QuestionMapper : IQuestionMapper
{
    private readonly IQuestionCategoriesMapper _categoriesMapper;
    private readonly IQuestionLevelsMapper _levelsMapper;

    public QuestionMapper(IQuestionCategoriesMapper categoriesMapper, IQuestionLevelsMapper levelsMapper)
    {
        _categoriesMapper = categoriesMapper;
        _levelsMapper = levelsMapper;
    }

    public Question MapFrom(string row)
    {
        var fieldValues = row.Split(";");
        var number = int.Parse(fieldValues[0]);
        var category = _categoriesMapper.MapFrom(fieldValues[1]);
        var answer = fieldValues[2];
        var questionText = fieldValues[3];
        var level = _levelsMapper.MapFrom(fieldValues[4]);

        return Question.CreateText(number, category, questionText, answer, level);
    }
}