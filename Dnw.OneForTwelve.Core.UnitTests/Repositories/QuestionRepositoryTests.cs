using Dnw.OneForTwelve.Core.Mappers;
using Dnw.OneForTwelve.Core.Repositories;
using Dnw.OneForTwelve.Core.UnitTests.Utils;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Dnw.OneForTwelve.Core.UnitTests.Repositories;

public class QuestionRepositoryTests
{
    [Fact]
    public void GetQuestions()
    {
        // Given
        const string header = "number;category;answer;question;m;";
        const string row1 = "1;CAT1;A1;Q1;2;";
        const string row2 = "2;CAT2;A2;Q2;3;";

        var q1 = new TestQuestionBuilder().Build();
        var q2 = new TestQuestionBuilder().Build();
        var mapper = Substitute.For<IQuestionMapper>();
        mapper.MapFrom(row1).Returns(q1);
        mapper.MapFrom(row2).Returns(q2);

        var embeddedFile = EmbeddedFileFactory.Create(
            "questions.csv",
            new[] { header, row1, row2 });

        var repository = new QuestionRepository(embeddedFile, mapper);

        // When
        var actual = repository.GetQuestions();

        // Then
        var expected = new[] { q1, q2 };
        actual.Should().BeEquivalentTo(expected);
    }
}