using Dnw.OneForTwelve.Core.Mappers;
using Dnw.OneForTwelve.Core.Models;
using Xunit;

namespace Dnw.OneForTwelve.Core.UnitTests.Mappers;

public class QuestionLevelsMapperTests
{
    [Theory]
    [InlineData("1", QuestionLevels.Easy)]
    [InlineData("3", QuestionLevels.Hard)]
    [InlineData("2", QuestionLevels.Normal)]
    [InlineData("SomethingElse", QuestionLevels.Normal)]
    public void MapFrom(string from, QuestionLevels expected)
    {
        // Given
        var mapper = new QuestionLevelsMapper();

        // When
        var actual = mapper.MapFrom(from);

        // Then
        Assert.Equal(expected, actual);
    }
}