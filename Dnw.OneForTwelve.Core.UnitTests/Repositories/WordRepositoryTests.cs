using Dnw.OneForTwelve.Core.Repositories;
using Dnw.OneForTwelve.Core.UnitTests.Utils;
using FluentAssertions;
using Xunit;

namespace Dnw.OneForTwelve.Core.UnitTests.Repositories;

public class WordRepositoryTests
{
    [Fact]
    public void GetWords()
    {
        // Given
        const string header = "word";
        const string word1 = "word1";
        const string word2 = "word2";
        var embeddedFile = EmbeddedFileFactory.Create("words.csv", new [] { header, word1, word2 });
        var repository = new WordRepository(embeddedFile);

        // When
        var actual = repository.GetWords();

        // Then
        var expected = new[] { word1, word2 };
        actual.Should().BeEquivalentTo(expected);
    }
    
    [Fact]
    public void GetWords_DoesNotReturnWordsWithLengthLargerThan12()
    {
        // Given
        const string header = "word";
        const string word1 = "word1";
        const string wordTooLong = "12345678911234";
        var embeddedFile = EmbeddedFileFactory.Create("words.csv", new [] { header, word1, wordTooLong });
        var repository = new WordRepository(embeddedFile);

        // When
        var actual = repository.GetWords();

        // Then
        var expected = new[] { word1 };
        actual.Should().BeEquivalentTo(expected);
    }
}