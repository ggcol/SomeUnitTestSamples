namespace BaseSample.Tests.Overview;

[TestFixture]
public class OfATestUsingTestCases
{
    [TestCase(2, 3, 5)]
    [TestCase(5, 5, 10)]
    [TestCase(-1, 5, 4)]
    public void Sum_GivenTwoIntegers_ReturnsSum(int a, int b, int expected)
    {
        //Arrange
        var math = new MyMath();
        
        //Act
        var sum = math.Sum(a, b);
        
        //Assert
        Assert.That(sum, Is.EqualTo(expected));
    }
}