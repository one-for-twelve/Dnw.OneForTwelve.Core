namespace Dnw.OneForTwelve.Core.Utils;

internal interface IEmbeddedFile
{
    StreamReader Read(string fileName);
}

internal class EmbeddedFile : IEmbeddedFile
{
    public StreamReader Read(string fileName)
    {
        var assembly = typeof(EmbeddedFile).Assembly;
        return new StreamReader(assembly.GetManifestResourceStream($"Dnw.OneForTwelve.Core.Resources.{fileName}")!);
    }
}