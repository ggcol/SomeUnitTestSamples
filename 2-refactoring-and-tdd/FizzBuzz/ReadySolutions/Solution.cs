namespace FizzBuzz;

public class Solution(IDoMath math) : ISolution
{
    private const string DivisibleBy3Answer = "Fizz";
    private const string DivisibleBy5Answer = "Buzz";

    public IEnumerable<string> FizzBuzz(int n)
    {
        for (var i = 1; i <= n; i++)
        {
            yield return Evaluate(i);
        }
    }

    private string Evaluate(int n)
    {
        if (IsDivisibleBy3(n) && IsDivisibleBy5(n))
        {
            return DivisibleBy3Answer + DivisibleBy5Answer;
        }

        if (IsDivisibleBy3(n))
        {
            return DivisibleBy3Answer;
        }

        if (IsDivisibleBy5(n))
        {
            return DivisibleBy5Answer;
        }

        return n.ToString();
    }

    private bool IsDivisibleBy3(int n)
    {
        return math.IsDivisibleByNumber(n, 3);
    }

    private bool IsDivisibleBy5(int n)
    {
        return math.IsDivisibleByNumber(n, 5);
    }
}