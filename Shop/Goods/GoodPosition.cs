namespace Shop
{
    public class GoodPosition : IReadOnlyGoodPosition
    {
        public GoodPosition(Good good, int count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            Good = good;
            Count = count;
        }

        public Good Good { get; private set; }

        public int Count { get; private set; }

        public void Merge(GoodPosition goodPosition)
        {
            Count += goodPosition.Count;
        }

        public void Order(int count)
        {
            Count -= count;
        }
    }
}
