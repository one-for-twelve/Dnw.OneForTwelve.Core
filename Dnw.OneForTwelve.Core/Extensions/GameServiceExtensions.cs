using Dnw.OneForTwelve.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Dnw.OneForTwelve.Core.Extensions;

public static class GameServiceExtensions
{
    public static void AddGameServices(this IServiceCollection services)
    {
        var fileService = new FileService();
        var randomService = new RandomService();

        var wordCache = new WordCache(fileService, randomService);
        wordCache.Init();
        services.AddSingleton<IWordCache>(wordCache);

        var questionCache = new QuestionCache(fileService, randomService);
        questionCache.Init();
        services.AddSingleton<IQuestionCache>(questionCache);

        services.AddSingleton<IDemoGameFactory, DutchDemoGameFactory>();
        services.AddSingleton<IDemoGameFactory, EnglishDemoGameFactory>();
        services.AddSingleton<IGameService, GameService>();
        services.AddSingleton<IDutchRandomGameFactory, DutchRandomGameFactory>();
        services.AddSingleton<IQuestionSelectorFactory, QuestionSelectorFactory>();
        services.AddSingleton<IQuestionSelector, RandomQuestionSelector>();
        services.AddSingleton<IQuestionSelector, RandomOnlyEasyQuestionSelector>();
        services.AddSingleton<IGameQuestionShuffler, GameQuestionShuffler>();
        services.AddSingleton<IRandomService, RandomService>();
        services.AddSingleton<IItemPicker, ItemPicker>();
        services.AddSingleton<IQuestionSelectorHelper, QuestionSelectorHelper>();
    }
}