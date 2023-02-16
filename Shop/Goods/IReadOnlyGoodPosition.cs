namespace Shop
{
    public interface IReadOnlyGoodPosition
    {
        public Good Good { get; }

        public int Count { get; }
    }
}
