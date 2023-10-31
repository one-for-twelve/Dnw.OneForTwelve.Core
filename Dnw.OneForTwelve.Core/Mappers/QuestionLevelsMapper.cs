using Dnw.OneForTwelve.Core.Models;

namespace Dnw.OneForTwelve.Core.Mappers;

internal interface IQuestionLevelsMapper
{
    QuestionLevels MapFrom(string value);
}

internal class QuestionLevelsMapper : IQuestionLevelsMapper
{
    public QuestionLevels MapFrom(string value)
    {
        return value switch
        {
            "1" => QuestionLevels.Easy,
            "3" => QuestionLevels.Hard,
            _ => QuestionLevels.Normal
        };
    }
}