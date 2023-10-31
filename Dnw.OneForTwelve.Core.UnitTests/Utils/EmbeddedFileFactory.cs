using System;
using System.IO;
using System.Text;
using Dnw.OneForTwelve.Core.Utils;
using NSubstitute;

namespace Dnw.OneForTwelve.Core.UnitTests.Utils;

internal static class EmbeddedFileFactory
{
    public static IEmbeddedFile Create(string fileName, string[] rows)
    {
        var fileContents = Encoding.UTF8.GetBytes(string.Join(Environment.NewLine, rows));
        var stream = new MemoryStream(fileContents);
        var streamReader = new StreamReader(stream);
        
        var embeddedFile = Substitute.For<IEmbeddedFile>();
        embeddedFile.Read(fileName).Returns(streamReader);

        return embeddedFile;
    }
}