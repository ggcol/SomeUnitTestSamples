using Moq;

namespace ALibrary.Tests.IsolationFrameworks.ShoppingCart;

[TestFixture]
public class ShoppingCartTests
{
    [TestCase("productId", 2, 5.5, 11)]
    [TestCase("productId", 4, 2.5, 10)]
    public void GetTotal_GivenAProductWithQuantity2_ReturnsTotalEqualToProductPricePerQuantity(
            string productId, int quantity, decimal productPrice,
            decimal expected)
    {
        // Arrange
        var priceRepository = new Mock<IPriceRepository>();
        priceRepository
            .Setup(x => x.GetPriceByProductId(productId))
            .Returns(productPrice);

        var cart = new ALibrary.ShoppingCart(priceRepository.Object);
        for (var i = 0; i < quantity; i++)
        {
            cart.Add(productId);
        }

        //Act
        var total = cart.GetTotal();

        //Assert
        Assert.That(total, Is.EqualTo(expected));
    }
}