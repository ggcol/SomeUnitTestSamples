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
        #region hard-static-dependency
        // Log.LogInformation("Performing {a}+{b}", a, b);
        #endregion
        checked
        {
            return a + b;
        }
    }
}

#region hard-static-dependency
public static class Log
{
    public static void LogInformation(string trace, params object[] args)
    {
        //logging logic
    }
}
#endregion