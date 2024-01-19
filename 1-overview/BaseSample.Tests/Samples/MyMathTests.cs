namespace BaseSample.Tests.Samples;

public class MyMathTests
{
    [TestCase(2, 3, 5)]
    [TestCase(3, 3, 6)]
    [TestCase(6, 3, 9)]
    public void Sum_GivenTwoIntegers_ReturnsSum(int a, int b,
        int expected)
    {
        //Arrange
        var math = new MyMath();

        //Act
        var sum = math.Sum(a, b);

        //Assert
        Assert.That(sum, Is.EqualTo(expected));
    }

    [TestCase(2, 3, -1)]
    [TestCase(3, 3, 0)]
    [TestCase(6, 3, 3)]
    public void Diff_GivenTwoIntegers_ReturnsDifference(int a, int b,
        int expected)
    {
        //Arrange
        var math = new MyMath();

        //Act
        var diff = math.Diff(a, b);

        //Assert
        Assert.That(diff, Is.EqualTo(expected));
    }

    #region corner case importance
    
    [Ignore("demo purpose")]
    [Test]
    public void Sum_TryingToSumTwoMaxedIntegers_GuessWhat()
    {
        //Arrange
        var a = int.MaxValue;
        var b = int.MaxValue;
        var expected = 4294967294;
        var math = new MyMath();

        //Act
        var sum = math.Sum(a, b);

        //Assert
       Assert.That(sum, Is.EqualTo(expected));
    }

    // [Ignore("demo purpose")]
    [Test]
    public void Sum_TryingTOSumTwoMaxedIntegers_ThrowsOverflowException()
    {
        //Arrange
        var a = int.MaxValue;
        var b = int.MaxValue;
        var math = new MyCheckedMath();

        //Act
        var sum = new Action(() =>
        {
            math.Sum(a, b);
        });

        //Assert
        Assert.That(sum, Throws.TypeOf<OverflowException>());
    }
    
    #endregion
}