using System.Text.Json.Serialization;
using Dnw.OneForTwelve.Core.Utils;

namespace Dnw.OneForTwelve.Core.Models;

[JsonConverter(typeof(EnumStringJsonConverter<Languages>))]
public enum Languages {
  English,
  Dutch
}