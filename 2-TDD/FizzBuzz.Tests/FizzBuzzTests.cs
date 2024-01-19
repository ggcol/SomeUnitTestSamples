namespace FizzBuzz.Tests;

[TestFixture]
public class FizzBuzzTests
{
    private ISolution _solution;
    
    [SetUp]
    public void Setup()
    {
        // _solution = new Solution(new MyMath());
        _solution = new MessySolution();
    }

    [TestCase(3, new []{"1", "2", "Fizz"})]
    [TestCase(5, new []{"1","2","Fizz","4","Buzz"})]
    [TestCase(15, new []{"1","2","Fizz","4","Buzz","Fizz","7","8","Fizz","Buzz","11","Fizz","13","14","FizzBuzz"})]
    public void FizzBuzz_GivenAnInteger_ReturnsProperResult(int input, string[] expected)
    {
        //Arrange
        
        //Act
        var actual = _solution.FizzBuzz(input).ToArray();

        //Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
}