using Dnw.OneForTwelve.Core.Utils;

namespace Dnw.OneForTwelve.Core.Repositories;

public interface IWordRepository
{
    public IEnumerable<string> GetWords();
}

internal class WordRepository : IWordRepository
{
    private readonly IEmbeddedFile _embeddedFile;
    
    public WordRepository(IEmbeddedFile embeddedFile)
    {
        _embeddedFile = embeddedFile;
    }
    
    public IEnumerable<string> GetWords()
    {
        var words = new List<string>();
        using var reader = _embeddedFile.Read("words.csv");

        reader.ReadLine();
        while (reader.ReadLine() is { } line)
        {
            // There are some words that contain the Dutch letter ij and 
            // therefore become more that 12 characters
            if (line.Length <= 12)
            {
                words.Add(line);
            }
        }

        return words;
    }
}