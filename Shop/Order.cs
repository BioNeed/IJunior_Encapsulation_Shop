namespace Shop
{
    public class Order
    {
        public readonly string Paylink;

        public Order(string paylink)
        {
            Paylink = paylink;
        }
    }
}
