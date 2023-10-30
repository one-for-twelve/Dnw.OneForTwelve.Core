using JetBrains.Annotations;

namespace Dnw.OneForTwelve.Core.Models;

public record Game(string Word, IEnumerable<GameQuestion> Questions)
{
    [UsedImplicitly] public int NumberOfQuestions => Questions.Count();
}