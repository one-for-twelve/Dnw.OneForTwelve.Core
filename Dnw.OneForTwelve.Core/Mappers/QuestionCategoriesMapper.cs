using Dnw.OneForTwelve.Core.Models;

namespace Dnw.OneForTwelve.Core.Mappers;

internal interface IQuestionCategoriesMapper
{
    QuestionCategories MapFrom(string value);
}

internal class QuestionCategoriesMapper : IQuestionCategoriesMapper
{
    public QuestionCategories MapFrom(string value)
    {
        return value switch
        {
            // ReSharper disable once StringLiteralTypo
            "AARD" => QuestionCategories.Geography,
            // ReSharper disable once StringLiteralTypo
            "BIJB" => QuestionCategories.Bible,
            "BIO" => QuestionCategories.Biology,
            // ReSharper disable once StringLiteralTypo
            "CRYP" => QuestionCategories.Cryptic,
            "ECO" => QuestionCategories.Economy,
            "GES" => QuestionCategories.History,
            "KUN" => QuestionCategories.Art,
            "LIT" => QuestionCategories.Literature,
            "MUZ" => QuestionCategories.Music,
            "POL" => QuestionCategories.Politics,
            "REK" => QuestionCategories.ScienceOrMaths,
            "SPO" => QuestionCategories.Sports,
            "WET" => QuestionCategories.ScienceOrMaths,
            _ => QuestionCategories.Unknown
        };
    }
}