namespace ALibrary.Tests.TheManualWay.MyLoggedMath;

public class MyLoggedMathTests
{
    private IDoMath? _math;

    [SetUp]
    public void Setup()
    {
        var logger = new FakeLogger<ALibrary.MyLoggedMath>();
        _math = new ALibrary.MyLoggedMath(logger);
    }

    [TestCase(2, 2, 4)]
    [TestCase(3, 7, 10)]
    [TestCase(-5, 6, 1)]
    public void Sum_GivenTwoIntegers_ReturnsSum(int a, int b, int expected)
    {
        //Act
        var sum = _math?.Sum(a, b);

        //Assert
        Assert.That(sum, Is.EqualTo(expected));
    }
}