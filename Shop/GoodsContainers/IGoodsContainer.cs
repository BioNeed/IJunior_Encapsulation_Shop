namespace Shop
{
    public interface IGoodsContainer
    {
        IReadOnlyList<IReadOnlyGoodPosition> GoodPositions
        {
            get;
        }
    }
}
