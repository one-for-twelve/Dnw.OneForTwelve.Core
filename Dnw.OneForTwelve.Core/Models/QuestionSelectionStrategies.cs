using System.Text.Json.Serialization;
using Dnw.OneForTwelve.Core.Utils;

namespace Dnw.OneForTwelve.Core.Models;

[JsonConverter(typeof(EnumStringJsonConverter<QuestionSelectionStrategies>))]
public enum QuestionSelectionStrategies {
  Demo,
  RandomOnlyEasy,
  RandomOnlyEasyAndNormal,
  Random,
}