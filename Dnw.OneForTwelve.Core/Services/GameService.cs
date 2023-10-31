using Dnw.OneForTwelve.Core.Models;

namespace Dnw.OneForTwelve.Core.Services;

public interface IGameService {
  Game? Start(Languages languages, QuestionSelectionStrategies questionSelectionStrategy);
}

internal class GameService : IGameService
{
  private readonly IDutchRandomGameFactory _dutchRandomGameFactory;
  private readonly Dictionary<string, IDemoGameFactory> _demoGameFactoriesByLanguage;
  
  public GameService(IDutchRandomGameFactory dutchRandomGameFactory, IEnumerable<IDemoGameFactory> demoGameFactories)
  {
    _dutchRandomGameFactory = dutchRandomGameFactory;
    _demoGameFactoriesByLanguage = demoGameFactories.ToDictionary(f => f.Language.ToString());
  }

  public Game Start(Languages language, QuestionSelectionStrategies questionSelectionStrategy)
  {
    if (questionSelectionStrategy == QuestionSelectionStrategies.Demo || language == Languages.English)
    {
      return GetDemoGameFactory(language).GetGame();
    }

    return _dutchRandomGameFactory.Get(questionSelectionStrategy);
  }

  private IDemoGameFactory GetDemoGameFactory(Languages language)
  {
    return _demoGameFactoriesByLanguage[language.ToString()];
  }
}