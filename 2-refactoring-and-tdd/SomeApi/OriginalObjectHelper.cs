namespace SomeApi;

/*
 * this code is gently taken from THAT *well known* repo...
 *
 * I didn't change anything except for the fact that
 * the original class was static and exposed the method as static,
 * changed here in order to refactor in another class implementing the
 * same interface
 */
public interface IObjectHelper
{
    public bool IsNumeric(object expression, bool parse = true);
}

public class ObjectHelper : IObjectHelper
{
    public bool IsNumeric(object Expression, bool parse = true)
    {
        var result = false;

        if (Expression == null || Expression is DateTime || Expression is DateTimeOffset)
        {
            result = false;
        }
        else if (Expression is short || Expression is int || Expression is long || Expression is decimal || Expression is float || Expression is double || Expression is bool)
        {
            result = true;
        }
        else
        {
            try
            {
                if (parse)
                {
                    if (Expression is string)
                    {
                        _ = double.Parse(Expression as string);
                    }
                    else
                    {
                        _ = double.Parse(Expression.ToString());
                    }

                    result = true;
                }
            }
            catch
            {
                // just dismiss errors but return false
            }
        }
        return result;
    }
}