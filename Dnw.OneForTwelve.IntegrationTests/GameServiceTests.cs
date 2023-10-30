using Dnw.OneForTwelve.Core.Extensions;
using Dnw.OneForTwelve.Core.Models;
using Dnw.OneForTwelve.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Dnw.OneForTwelve.IntegrationTests;

public class GameServiceTests
{
    [Fact]
    public void StartGame()
    {
        // Given
        var services = new ServiceCollection();
        services.AddGameServices();
        
        var provider = services.BuildServiceProvider();
        var gameService = provider.GetRequiredService<IGameService>();
        
        // When
        var game = gameService.Start(Languages.Dutch, QuestionSelectionStrategies.Random);

        // Then
        Assert.NotNull(game);
    }
}