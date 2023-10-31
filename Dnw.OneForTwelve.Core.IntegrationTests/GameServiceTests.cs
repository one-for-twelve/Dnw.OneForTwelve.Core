using Dnw.OneForTwelve.Core.Extensions;
using Dnw.OneForTwelve.Core.Models;
using Dnw.OneForTwelve.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace Dnw.OneForTwelve.Core.IntegrationTests;

public class GameServiceTests
{
    [Theory]
    [InlineData(Languages.Dutch,QuestionSelectionStrategies.Demo)]
    [InlineData(Languages.Dutch,QuestionSelectionStrategies.Random)]
    [InlineData(Languages.Dutch,QuestionSelectionStrategies.RandomOnlyEasy)]
    [InlineData(Languages.Dutch,QuestionSelectionStrategies.RandomOnlyEasyAndNormal)]
    [InlineData(Languages.English,QuestionSelectionStrategies.Demo)]
    [InlineData(Languages.English,QuestionSelectionStrategies.Random)]
    [InlineData(Languages.English,QuestionSelectionStrategies.RandomOnlyEasy)]
    [InlineData(Languages.English,QuestionSelectionStrategies.RandomOnlyEasyAndNormal)]
    public void StartGame(Languages language, QuestionSelectionStrategies strategy)
    {
        // Given
        var hostBuilder = Host.CreateDefaultBuilder();
        hostBuilder.ConfigureServices(services => services.AddGameServices());
        var host = hostBuilder.Build();
        
        host.UseGameServices();

        var gameService = host.Services.GetRequiredService<IGameService>();
        
        // When
        var game = gameService.Start(language, strategy);

        // Then
        Assert.NotNull(game);
    }
}