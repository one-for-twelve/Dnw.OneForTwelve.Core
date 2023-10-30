using Dnw.OneForTwelve.Core.Models;

namespace Dnw.OneForTwelve.Core.Services;

internal interface IDemoGameFactory {
  public Languages Language { get; }
  public Game GetGame();
}