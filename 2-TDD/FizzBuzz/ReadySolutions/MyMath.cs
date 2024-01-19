namespace FizzBuzz;

public interface IDoMath
{
    public bool IsDivisibleByNumber(int n, int divider);
}

public sealed class MyMath : IDoMath
{
    public bool IsDivisibleByNumber(int n, int divider)
    {
        return n % divider == 0;
    }
}