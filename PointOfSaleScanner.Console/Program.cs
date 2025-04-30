namespace PointOfSaleScanner.Console
{
    using PointOfSaleScanner.Core;
    using PointOfSaleScanner.Core.Utility;
    using Console = System.Console;

    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "AAAABCDAAA";

            var builder = new PricingSheetBuilder();
            builder.WithItem("A").SetUnitPrice(1.25m).SetVolumePrice(3.00m, 3);
            builder.WithItem("B").SetUnitPrice(4.25m);
            builder.WithItem("C").SetUnitPrice(1.00m).SetVolumePrice(5.00m, 6);
            builder.WithItem("D").SetUnitPrice(0.75m);
            var priceSheet = builder.Build();

            ICartItemPriceCalculator cartItemPriceCalculator = new CartItemPriceCalculator(priceSheet);
            IShoppingCart shoppingCart = new ShoppingCart(cartItemPriceCalculator);

            foreach (char item in input)
            {
                shoppingCart.Scan(item.ToString());
            }

            decimal total = shoppingCart.GetTotal();

            Console.WriteLine($"Total: {total:C}");
        }
    }
}
