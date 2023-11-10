using Dnw.OneForTwelve.Core.Mappers;
using Dnw.OneForTwelve.Core.Repositories;
using Dnw.OneForTwelve.Core.Services;
using Dnw.OneForTwelve.Core.Utils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Dnw.OneForTwelve.Core.Extensions;

public static class GameServiceExtensions
{
    public static void AddGameServices(this IServiceCollection services)
    {
        services.AddSingleton<IEmbeddedFile, EmbeddedFile>();
        services.AddSingleton<IWordRepository, WordRepository>();
        services.AddSingleton<IQuestionCategoriesMapper, QuestionCategoriesMapper>();
        services.AddSingleton<IQuestionLevelsMapper, QuestionLevelsMapper>();
        services.AddSingleton<IQuestionMapper, QuestionMapper>();
        services.AddSingleton<IQuestionRepository, QuestionRepository>();
        services.AddSingleton<WordCache>();
        services.AddSingleton<IWordCache, WordCache>(x => x.GetRequiredService<WordCache>());
        services.AddSingleton<IInitCache, WordCache>(x => x.GetRequiredService<WordCache>());
        services.AddSingleton<QuestionCache>();
        services.AddSingleton<IQuestionCache, QuestionCache>(x => x.GetRequiredService<QuestionCache>());
        services.AddSingleton<IInitCache, QuestionCache>(x => x.GetRequiredService<QuestionCache>());   
        services.AddSingleton<IDemoGameFactory, DutchDemoGameFactory>();
        services.AddSingleton<IDemoGameFactory, EnglishDemoGameFactory>();
        services.AddSingleton<IGameService, GameService>();
        services.AddSingleton<IDutchRandomGameFactory, DutchRandomGameFactory>();
        services.AddSingleton<IQuestionSelectorFactory, QuestionSelectorFactory>();
        services.AddSingleton<IQuestionSelector, RandomQuestionSelector>();
        services.AddSingleton<IQuestionSelector, RandomOnlyEasyQuestionSelector>();
        services.AddSingleton<IQuestionSelector, RandomOnlyNormalQuestionSelector>();
        services.AddSingleton<IQuestionSelector, RandomOnlyEasyAndNormalQuestionSelector>();
        services.AddSingleton<IGameQuestionShuffler, GameQuestionShuffler>();
        services.AddSingleton<IRandomService, RandomService>();
        services.AddSingleton<IItemPicker, ItemPicker>();
        services.AddSingleton<IQuestionSelectorHelper, QuestionSelectorHelper>();
    }

    public static void UseGameServices(this IHost host)
    {
        var services = host.Services;
        var initCaches = services.GetRequiredService<IEnumerable<IInitCache>>();
        
        initCaches.ToList().ForEach(cache => cache.Init());
    }
}