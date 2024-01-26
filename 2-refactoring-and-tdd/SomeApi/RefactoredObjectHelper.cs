namespace SomeApi;

public class RefactoredObjectHelper : IObjectHelper
{
    public bool IsNumeric(object expression, bool parse = true)
    {
        return expression switch
        {
            short or int or long or decimal or float or double or bool => true,
            string anyString => parse && double.TryParse(anyString, out _),
            not null => parse && double.TryParse(expression.ToString(), out _),
            _ => false
        };
    }
}