namespace Dnw.OneForTwelve.Core.Services;

internal interface IItemPicker
{
    T PickRandom<T>(IList<T> items);
}

internal class ItemPicker : IItemPicker
{
    private readonly IRandomService _randomService;

    public ItemPicker(IRandomService randomService)
    {
        _randomService = randomService;
    }
    
    public T PickRandom<T>(IList<T> items)
    {
        var randomIndex = _randomService.Next(0, items.Count);
        return items[randomIndex];
    }
}