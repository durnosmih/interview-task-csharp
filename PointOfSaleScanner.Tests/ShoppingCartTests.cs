using Moq;
using PointOfSaleScanner.Core;

namespace PointOfSaleScanner.Tests;

[TestClass]
public class ShoppingCartTests
{
    [TestMethod]
    public void Scan_AddsItemToCart_AllItemsCalculatedCorrectly()
    {
        decimal expectedTotal = 18.00m;

        var calculatorMock = new Mock<ICartItemPriceCalculator>();
        calculatorMock.Setup(m => m.GetTotal("A", 1)).Returns(5.00m);
        calculatorMock.Setup(m => m.GetTotal("B", 1)).Returns(10.00m);
        calculatorMock.Setup(m => m.GetTotal("C", 2)).Returns(3.00m);
        calculatorMock.Setup(m => m.GetTotal("X", It.IsAny<int>())).Returns(10.00m);

        var shoppingCart = new ShoppingCart(calculatorMock.Object);
        
        shoppingCart.Scan("A");
        shoppingCart.Scan("C");
        shoppingCart.Scan("B");
        shoppingCart.Scan("C");

        Assert.AreEqual(expectedTotal, shoppingCart.GetTotal());
    }
}
