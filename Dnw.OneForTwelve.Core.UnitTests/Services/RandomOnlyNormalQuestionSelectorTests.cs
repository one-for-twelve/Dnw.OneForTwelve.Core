using System.Collections.Generic;
using Dnw.OneForTwelve.Core.Models;
using Dnw.OneForTwelve.Core.Services;
using NSubstitute;
using Xunit;

namespace Dnw.OneForTwelve.Core.UnitTests.Services;

public class RandomOnlyNormalQuestionSelectorTests
{
    [Fact]
    public void Strategy()
    {
        // Given
        var selector = new RandomOnlyNormalQuestionSelector(Substitute.For<IQuestionSelectorHelper>());
        
        // Then
        Assert.Equal(QuestionSelectionStrategies.RandomOnlyNormal, selector.Strategy);
    }
    
    [Fact]
    public void GetQuestions()
    {
        // Given
        const string word = "aWord";
        
        var helper = Substitute.For<IQuestionSelectorHelper>();
        var expected = new List<GameQuestion>();
        helper
            .GetQuestions(word, RandomOnlyNormalQuestionSelector.Categories, RandomOnlyNormalQuestionSelector.Levels)
            .Returns(expected);
        
        var selector = new RandomOnlyNormalQuestionSelector(helper);

        // When
        var actual = selector.GetQuestions(word);

        // Then
        Assert.Equal(expected, actual);
    }
}