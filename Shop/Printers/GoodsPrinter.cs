namespace Shop
{
    public abstract class GoodsPrinter
    {
        public abstract void PrintGoods(IGoodsContainer container);

        protected abstract void Print(IReadOnlyGoodPosition readOnlyGoodPosition);
    }
}
