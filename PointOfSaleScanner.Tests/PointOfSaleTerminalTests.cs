using Moq;
using PointOfSaleScanner.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSaleScanner.Tests
{
    [TestClass]
    public class PointOfSaleTerminalTests
    {
        private PointOfSaleTerminal terminal;

        public static IEnumerable<object[]> TestMethod1Data =>
        [
            ["AAAABCDAAA", 13.25m],
            ["CCCCCCC", 6.00m],
            ["CCCCCC", 5.00m],
            ["ABCD", 7.25m],
            ["AA", 2.50m],
            ["D", 0.75m],
            ["", 0.0m]
        ];

        [TestInitialize]
        public void Initialize()
        {
            IPriceSheetRepository priceSheetRepository = new PriceSheetRepository();
            ICartItemPriceCalculator priceCalculator = new StandardCartItemPriceCalculator(priceSheetRepository);
            IShoppingCart cart = new ShoppingCart(priceCalculator);

            terminal = new PointOfSaleTerminal(cart, priceSheetRepository);

            terminal.SetPricing("A", 1.25m, 3.00m, 3);
            terminal.SetPricing("B", 4.25m);
            terminal.SetPricing("C", 1.00m, 5.00m, 6);
            terminal.SetPricing("D", 0.75m);
        }

        [TestMethod]
        [DynamicData(nameof(TestMethod1Data))]
        public void CalculateTotal_PassCorrectData_CorrectCartTotalPriceCalculated(string code, decimal expectedTotal)
        {
            foreach (char item in code)
            {
                terminal.Scan(item.ToString());
            }

            decimal actualTotal = terminal.CalculateTotal();

            Assert.AreEqual(expectedTotal, actualTotal);
        }
    }
}
