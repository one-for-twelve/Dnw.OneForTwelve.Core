using System.Collections.Generic;
using Dnw.OneForTwelve.Core.Models;
using Dnw.OneForTwelve.Core.Services;
using NSubstitute;
using Xunit;

namespace Dnw.OneForTwelve.Core.UnitTests.Services;

public class RandomOnlyEasyAndNormalQuestionSelectorTests
{
    [Fact]
    public void Strategy()
    {
        // Given
        var selector = new RandomOnlyEasyAndNormalQuestionSelector(Substitute.For<IQuestionSelectorHelper>());

        // When
        var actual = selector.Strategy;

        // Then
        Assert.Equal(QuestionSelectionStrategies.RandomOnlyEasyAndNormal, actual);
    }
    
    [Fact]
    public void GetQuestions()
    {
        // Given
        const string word = "aWord";
        
        var helper = Substitute.For<IQuestionSelectorHelper>();
        var expected = new List<GameQuestion>();
        helper
            .GetQuestions(word, RandomOnlyEasyAndNormalQuestionSelector.Categories, RandomOnlyEasyAndNormalQuestionSelector.Levels)
            .Returns(expected);
        
        var selector = new RandomOnlyEasyAndNormalQuestionSelector(helper);

        // When
        var actual = selector.GetQuestions(word);

        // Then
        Assert.Equal(expected, actual);
    }
}