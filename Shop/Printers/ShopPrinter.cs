namespace Shop
{
    public class ShopPrinter : GoodsPrinter
    {
        public override void PrintGoods(IGoodsContainer shop)
        {
            foreach (IReadOnlyGoodPosition goodPosition in shop.GoodPositions)
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
