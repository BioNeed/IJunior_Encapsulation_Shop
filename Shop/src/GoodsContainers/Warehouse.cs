namespace Shop
{
    public class Warehouse
    {
        private readonly List<GoodPosition> _goodPositions = new ();

        public IReadOnlyList<IReadOnlyGoodPosition> GoodPositions => _goodPositions;

        public void Init(Shop shop)
        {
            shop.GoodsBought += OnGoodsBought;
        }

        public void Delive(Good good, int count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            var newGoodPosition = new GoodPosition(good, count);

            int goodIndex = _goodPositions.FindIndex(goodPosition => goodPosition.Good == good);

            if (goodIndex == -1)
            {
                _goodPositions.Add(newGoodPosition);
            }
            else
            {
                _goodPositions[goodIndex].Merge(newGoodPosition);
            }
        }

        private void OnGoodsBought(List<IReadOnlyGoodPosition> boughtGoodPositions)
        {
            foreach (IReadOnlyGoodPosition boughtGoodPosition in boughtGoodPositions)
            {
                RemoveFromWarehouse(boughtGoodPosition);
            }
        }

        private void RemoveFromWarehouse(IReadOnlyGoodPosition boughtGoodPosition)
        {
            int goodIndex = _goodPositions.FindIndex(goodPosition => goodPosition.Good == boughtGoodPosition.Good);

            if (goodIndex == -1)
            {
                throw new InvalidOperationException("No ordered good in warehouse!");
            }
            else
            {
                _goodPositions[goodIndex].Order(boughtGoodPosition.Count);
            }
        }
    }
}
