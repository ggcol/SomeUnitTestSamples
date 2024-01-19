namespace BaseSample.Tests.Samples;

public class MyPositiveMathTests
{
    [TestCase(-2, 2)]
    [TestCase(2, -2)]
    [TestCase(-2, -2)]
    public void MyPositiveMathSum_GivenAnyNegativeNumber_ThrowsArgumentException(int a, int b)
    {
        //Arrange
        var math = new MyPositiveMath(new MyCheckedMath());

        //Act
        var sum = new Action(() => { math.Sum(a, b); });

        //Assert
        Assert.That(sum, Throws.ArgumentException);
    }
    
    [TestCase(-2, 2)]
    [TestCase(2, -2)]
    [TestCase(-2, -2)]
    public void MyPositiveMathDiff_GivenAnyNegativeNumber_ThrowsArgumentException(int a, int b)
    {
        //Arrange
        var math = new MyPositiveMath(new MyCheckedMath());

        //Act
        var diff = new Action(() => { math.Diff(a, b); });

        //Assert
        Assert.That(diff, Throws.ArgumentException);
    }
}