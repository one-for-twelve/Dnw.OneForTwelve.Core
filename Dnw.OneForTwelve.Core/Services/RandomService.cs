namespace Dnw.OneForTwelve.Core.Services;

internal interface IRandomService
{
    int Next(int minValue, int maxValue);
}

internal class RandomService : IRandomService
{
    public int Next(int minValue, int maxValue)
    {
        return Random.Shared.Next(minValue, maxValue);
    }
}