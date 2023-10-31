using System.Text.Json.Serialization;
using Dnw.OneForTwelve.Core.Utils;

namespace Dnw.OneForTwelve.Core.Models;

[JsonConverter(typeof(EnumStringJsonConverter<RemoteVideoSources>))]
public enum RemoteVideoSources {
  // ReSharper disable once UnusedMember.Global
  Youtube,
  Vimeo
}