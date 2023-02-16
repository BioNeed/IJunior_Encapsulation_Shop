namespace Shop
{
    public class Shop : IGoodsContainer
    {
        private readonly Warehouse _warehouse;

        public Shop(Warehouse warehouse)
        {
            _warehouse = warehouse;
            _warehouse.Init(this);
        }

        public event Action<List<IReadOnlyGoodPosition>>? GoodsBought;

        public IReadOnlyList<IReadOnlyGoodPosition> GoodPositions => _warehouse.GoodPositions;

        public Cart CreateCart()
        {
            Cart cart = new Cart(GoodPositions);
            cart.Ordered += OnOrdered;
            return cart;
        }

        private void OnOrdered(List<IReadOnlyGoodPosition> goodPositions)
        {
            GoodsBought?.Invoke(goodPositions);
        }
    }
}