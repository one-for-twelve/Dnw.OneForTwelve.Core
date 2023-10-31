using System.Linq;
using Dnw.OneForTwelve.Core.Repositories;
using Dnw.OneForTwelve.Core.Services;
using NSubstitute;
using Xunit;

namespace Dnw.OneForTwelve.Core.UnitTests.Services;

public class WordCacheTests
{
    [Fact]
    public void GetRandom()
    {
       // Given
       var wordRepository = Substitute.For<IWordRepository>();
       var expectedWords = Enumerable.Range(0, 20).Select(i => $"word{i}").ToList();
       wordRepository.GetWords().Returns(expectedWords);
       
       var randomService = Substitute.For<IRandomService>();
       const int expectedWordIndex = 10;
       randomService.Next(0, expectedWords.Count).Returns(expectedWordIndex);

       var wordCache = new WordCache(wordRepository, randomService);
       wordCache.Init();

       // When
       var actual = wordCache.GetRandom();

       // Then
       var expected = expectedWords[expectedWordIndex];
       Assert.Equal(expected, actual);
    }
}