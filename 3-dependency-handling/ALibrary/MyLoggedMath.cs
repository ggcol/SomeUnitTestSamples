using Microsoft.Extensions.Logging;

namespace ALibrary;

public interface IDoMath
{
    public int Sum(int a, int b);
}

public class MyLoggedMath(ILogger _logger) : IDoMath
{
    public int Sum(int a, int b)
    {
        _logger.LogInformation("Performing {a}+{b}", a, b);
        checked
        {
            return a + b;
        }
    }
}