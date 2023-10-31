using Dnw.OneForTwelve.Core.Mappers;
using Dnw.OneForTwelve.Core.Models;
using Xunit;

namespace Dnw.OneForTwelve.Core.UnitTests.Mappers;

public class QuestionCategoriesMapperTests
{
    [Theory]
    // ReSharper disable once StringLiteralTypo
    [InlineData("AARD", QuestionCategories.Geography)]
    // ReSharper disable once StringLiteralTypo
    [InlineData("BIJB", QuestionCategories.Bible)]
    [InlineData("BIO", QuestionCategories.Biology)]
    // ReSharper disable once StringLiteralTypo
    [InlineData("CRYP", QuestionCategories.Cryptic)]
    [InlineData("ECO", QuestionCategories.Economy)]
    [InlineData("GES", QuestionCategories.History)]
    [InlineData("KUN", QuestionCategories.Art)]
    [InlineData("LIT", QuestionCategories.Literature)]
    [InlineData("MUZ", QuestionCategories.Music)]
    [InlineData("POL", QuestionCategories.Politics)]
    [InlineData("REK", QuestionCategories.ScienceOrMaths)]
    [InlineData("SPO", QuestionCategories.Sports)]
    [InlineData("SomethingElse", QuestionCategories.Unknown)]
    public void MapFrom(string from, QuestionCategories expected)
    {
        // Given
        var mapper = new QuestionCategoriesMapper();

        // When
        var actual = mapper.MapFrom(from);

        // Then
        Assert.Equal(expected, actual);
    }
}