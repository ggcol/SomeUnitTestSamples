namespace SomeApi.Tests;

[TestFixture]
public class ObjectHelperTests
{
    private readonly IObjectHelper _helper = new ObjectHelper();
    // private readonly IObjectHelper _helper = new RefactoredObjectHelper();

    [Test]
    public void IsNumeric_GivenNull_ReturnFalse()
    {
        //Arrange
        
        //Act
        var isNumeric = _helper.IsNumeric(null);

        //Assert
        Assert.That(isNumeric, Is.False);
    }
    
    [TestCase(typeof(DateTime))]
    [TestCase(typeof(DateTimeOffset))]
    public void IsNumeric_GivenDateTime_ReturnFalse(Type dateTimeType)
    {
        //Arrange
        var obj = Activator.CreateInstance(dateTimeType);
        
        //Act
        var isNumeric = _helper.IsNumeric(obj);

        //Assert
        Assert.That(isNumeric, Is.False);
    }

    [TestCase(typeof(short))]
    [TestCase(typeof(int))]
    [TestCase(typeof(long))]
    [TestCase(typeof(decimal))]
    [TestCase(typeof(float))]
    [TestCase(typeof(double))]
    [TestCase(typeof(bool))]
    public void IsNumeric_GivenANumeric_ReturnTrue(Type numericType)
    {
        //Arrange
        var obj = Activator.CreateInstance(numericType);
        
        //Act
        var isNumeric = _helper.IsNumeric(obj);

        //Assert
        Assert.That(isNumeric, Is.True);
    }
    
    [TestCase("any")]
    [TestCase("42")]
    public void IsNumeric_GivenAStringWithParseDisabled_ReturnFalse(string aString)
    {
        //Arrange
        var doNotParse = false;
        
        //Act
        var isNumeric = _helper.IsNumeric(aString, doNotParse);

        //Assert
        Assert.That(isNumeric, Is.False);
    }
    
    [TestCase("any", false)]
    [TestCase("42", true)]
    public void IsNumeric_GivenAStringWithParseEnabled_ReturnTrueIfParsableFalseOtherwise(
        string aString, bool expected)
    {
        //Arrange
        var doParse = true;
        
        //Act
        var isNumeric = _helper.IsNumeric(aString, doParse);

        //Assert
        Assert.That(isNumeric, Is.EqualTo(expected));
    }

    [Test]
    public void IsNumeric_GivenAParsableObjectAndParsingEnabled_ReturnTrue()
    {
        //Arrange
        var parsableObject = new NumericParsableObject(42);
        var doParse = true;
        
        //Act
        var isNumeric = _helper.IsNumeric(parsableObject, doParse);
        
        //Assert
        Assert.That(isNumeric, Is.True);
    }
    
    [Test]
    public void IsNumeric_GivenAnNonParsableObjectAndParsingEnabled_ReturnFalse()
    {
        //Arrange
        var parsableObject = new NumericNonParsableObject(42);
        var doParse = true;
        
        //Act
        var isNumeric = _helper.IsNumeric(parsableObject, doParse);
        
        //Assert
        Assert.That(isNumeric, Is.False);
    }

    private class NumericParsableObject(int aNumber)
    {
        public override string ToString()
        {
            return aNumber.ToString();
        }
    }

    private class NumericNonParsableObject(int aNumber)
    {
        public override string ToString()
        {
            return aNumber.ToString($"I'm a: {aNumber}");
        }
    }
}