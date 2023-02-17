namespace Shop
{
    public class CartPrinter : GoodsPrinter
    {
        public override void PrintGoods(IGoodsContainer cart)
        {
            foreach (IReadOnlyGoodPosition goodPosition in cart.GoodPositions)
            {
                Print(goodPosition);
            }
        }

        protected override void Print(IReadOnlyGoodPosition goodPosition)
        {
            Console.WriteLine(goodPosition.Good.Name + " " + goodPosition.Count);
        }
    }
}
