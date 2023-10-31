using Dnw.OneForTwelve.Core.Extensions;
using Dnw.OneForTwelve.Core.Models;
using Dnw.OneForTwelve.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace Dnw.OneForTwelve.Core.IntegrationTests;

public class GameServiceTests
{
    [Fact]
    public void StartGame()
    {
        // Given
        var hostBuilder = Host.CreateDefaultBuilder();
        hostBuilder.ConfigureServices(services => services.AddGameServices());
        var host = hostBuilder.Build();
        
        host.UseGameServices();

        var gameService = host.Services.GetRequiredService<IGameService>();
        
        // When
        var game = gameService.Start(Languages.Dutch, QuestionSelectionStrategies.Random);

        // Then
        Assert.NotNull(game);
    }
}