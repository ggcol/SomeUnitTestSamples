using Moq;

namespace ALibrary.Tests.IsolationFrameworks.ShoppingCart;

[TestFixture]
public class ShoppingCartTests
{
    [TestCase("productId", 2, 5.5, 11)]
    [TestCase("productId", 4, 2.5, 10)]
    public void
        GetTotal_GivenAProductWithQuantity_ReturnsTotalEqualToProductPricePerQuantity(
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

    [TestCase("product1", "product2", 2, 4, 3, 2, 14)]
    [TestCase("product1", "product2", 4, 3, 10, 5, 55)]
    public void GetTotal_GivenTwoProductsWithDifferentQuantity_ReturnTotalEqualToProductsPricePerQuantities(
        string productId1, string productId2, int quantity1, int quantity2, 
        decimal price1, decimal price2, decimal expected)
    {
        //Arrange
        var priceRepository = new Mock<IPriceRepository>();
        priceRepository
            .Setup(x => x.GetPriceByProductId(productId1))
            .Returns(price1);
        priceRepository
            .Setup(x => x.GetPriceByProductId(productId2))
            .Returns(price2);
        
        var cart = new ALibrary.ShoppingCart(priceRepository.Object);
        for (var i = 0; i < quantity1; i++)
        {
            cart.Add(productId1);
        }   
        for (var i = 0; i < quantity2; i++)
        {
            cart.Add(productId2);
        }   
        
        //Act
        var total = cart.GetTotal();
    
        //Assert
        Assert.That(total, Is.EqualTo(expected));
    }
}