namespace BaseSample.Tests.Overview;

[TestFixture]
public class OfATestClass
{
    private string? _aString;
    private int _testCounter;
    
    /*
     * Execute this method once before ALL tests. Must be public.
     */
    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _aString = "hello";
    }

    /*
     * Execute this method before EACH test. Must be public.
     */
    [SetUp]
    public void SetUp()
    {
        if (_testCounter == 1) _aString += " world!";
    }

    /*
     * Execute this method after EACH test. Must be public
     */
    [TearDown]
    public void TearDown()
    {
        _testCounter++;
    }

    /*
     * Execute this method after ALL tests. Must be public
     */
    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        /*
         * not used in this example, often used for clean filesystem
         * or other external resources
         */
    }

    [Test]
    public void Playground1()
    {
        //Assert
        Assert.That(_aString, Is.EqualTo("hello"));
    }

    [Test]
    public void Playground2()
    {
        //Assert
        Assert.That(_aString, Is.EqualTo("hello world!"));
    }
    
    /*
     * Run this test instead of "Playground2" to see that tests in this
     * class are not independent and therefore not good tests
     */
    // [Test]
    // public void APlayground2()
    // {
    //     //Assert
    //     Assert.That(_aString, Is.EqualTo("hello world!"));
    // }
}