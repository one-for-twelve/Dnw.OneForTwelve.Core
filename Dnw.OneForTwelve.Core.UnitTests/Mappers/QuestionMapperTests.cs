using Dnw.OneForTwelve.Core.Mappers;
using Dnw.OneForTwelve.Core.Models;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Dnw.OneForTwelve.Core.UnitTests.Mappers;

public class QuestionMapperTests
{
    private readonly IQuestionCategoriesMapper _categoriesMapper;
    private readonly IQuestionLevelsMapper _levelsMapper;
    
    private readonly QuestionMapper _mapper;
    
    public QuestionMapperTests()
    {
        _categoriesMapper = Substitute.For<IQuestionCategoriesMapper>();
        _levelsMapper = Substitute.For<IQuestionLevelsMapper>();
        
        _mapper = new QuestionMapper(_categoriesMapper, _levelsMapper);
    }
    
    [Fact]
    public void MapFrom()
    {
        // Given
        var expected = Question.CreateText(1, QuestionCategories.Economy, "question", "answer", QuestionLevels.Hard);
        const string category = "aCategory";
        const string level = "aLevel";
        var questionRow = string.Join(";", expected.Id.ToString(), category, expected.Answer, expected.Text, level);

        _categoriesMapper.MapFrom(category).Returns(expected.Category);
        _levelsMapper.MapFrom(level).Returns(expected.Level);
        
        // When
        var actual = _mapper.MapFrom(questionRow);

        // Then
        actual.Should().BeEquivalentTo(expected);
    }
}