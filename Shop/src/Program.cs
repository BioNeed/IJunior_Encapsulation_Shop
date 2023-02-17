namespace Shop
{
    public class Program
    {
        public static void Main()
        {
            var iPhone12 = new Good("IPhone 12");
            var iPhone11 = new Good("IPhone 11");

            var warehouse = new Warehouse();
            var shop = new Shop(warehouse);

            var shopPrinter = new ShopPrinter();
            var cartPrinter = new CartPrinter();

            warehouse.Delive(iPhone12, 10);
            warehouse.Delive(iPhone11, 1);

            shopPrinter.PrintGoods(shop);

            Cart cart = shop.CreateCart();
            cart.Add(iPhone12, 4);
            cart.Add(iPhone11, 1);
            cart.Add(iPhone12, 10);

            cartPrinter.PrintGoods(cart);

            Console.WriteLine(cart.Order().Paylink);

            cart.Add(iPhone12, 9); // Ошибка, после заказа со склада убираются заказанные товары
        }
    }
}