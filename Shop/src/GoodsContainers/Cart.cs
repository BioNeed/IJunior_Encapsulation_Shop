namespace Shop
{
    public class Cart : IGoodsContainer
    {
        private readonly IReadOnlyList<IReadOnlyGoodPosition> _availableGoodPositions;
        private readonly List<IReadOnlyGoodPosition> _goodPositionsInCart = new ();

        public Cart(IReadOnlyList<IReadOnlyGoodPosition> goodPositions)
        {
            _availableGoodPositions = goodPositions;
        }

        public event Action<List<IReadOnlyGoodPosition>>? Ordered;

        public IReadOnlyList<IReadOnlyGoodPosition> GoodPositions => _goodPositionsInCart;

        public Order Order()
        {
            if (_goodPositionsInCart.Count == 0)
            {
                throw new InvalidOperationException("Fill your cart before order!");
            }

            Ordered?.Invoke(_goodPositionsInCart);
            _goodPositionsInCart.Clear();

            return new Order("Ordered!");
        }

        public void Add(Good good, int countToAdd)
        {
            if (countToAdd < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(countToAdd));
            }

            IReadOnlyGoodPosition? goodPosition =
                _availableGoodPositions.FirstOrDefault(goodPosition => goodPosition.Good == good);

            if (goodPosition == null)
            {
                throw new ArgumentException(nameof(good));
            }

            int goodIndexInCart =
                _goodPositionsInCart.FindIndex(goodPosition => goodPosition.Good == good);

            if (goodIndexInCart != -1)
            {
                int newGoodCount = _goodPositionsInCart[goodIndexInCart].Count + countToAdd;
                int maxGoodCount = goodPosition.Count;

                if (newGoodCount < maxGoodCount)
                {
                    _goodPositionsInCart[goodIndexInCart] = new GoodPosition(good, newGoodCount);
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Count to add in cart is greater than count on warehouse");
                }
            }
            else
                if (countToAdd <= goodPosition.Count)
            {
                AddToCart(good, countToAdd);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Count to add in cart is greater than count on warehouse");
            }
        }

        private void AddToCart(Good good, int countToAdd)
        {
            IReadOnlyGoodPosition cartGoodPosition = new GoodPosition(good, countToAdd);
            _goodPositionsInCart.Add(cartGoodPosition);
        }
    }
}