namespace BaseSample.Tests.Overview;

//Attribute to tell the test engine this is a test class (easy said)
[TestFixture]
public class OfATest
{
    //Attribute to tell the test engine this is a test
    [Test]
    /*
     * 1. Name with the UnitUnderTest_Condition_ExpectedResult convention
     * (other conventions exists, for example: GivenWhenThen, ShouldWhen,
     * pick up the most suitable and be consistent).
     *
     * 2. For most (if not all) test engines the test method must be public
     */
    public void Sum_GivenTwoIntegers_ReturnsSum()
    {
        /*
         * Prepare anything is then needed by the rest of the unit test
         */
        //Arrange 
        var a = 2;
        var b = 3;
        var expected = 5;
        var math = new MyMath();
        
        /*
         * This is the actual core of the test: call the unit under test
         */
        //Act
        var sum = math.Sum(a, b);
        
        /*
         * Compare the outcome of the unit under test with an expected outcome
         */
        //Assert
        Assert.That(sum, Is.EqualTo(expected));
    }
}