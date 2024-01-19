namespace BaseSample;

public interface IDoMath
{
    public int Sum(int a, int b);
    public int Diff(int a, int b);
}

public class MyMath : IDoMath
{
    public int Sum(int a, int b)
    {
        return a + b;
    }

    public int Diff(int a, int b)
    {
        return a - b;
    }
}

public class MyCheckedMath : IDoMath
{
    public int Sum(int a, int b)
    {
        checked
        {
            return a + b;
        }
    }

    public int Diff(int a, int b)
    {
        checked
        {
            return a - b;
        }
    }
}

// ReSharper disable once SuggestBaseTypeForParameterInConstructor
public class MyPositiveMath(MyCheckedMath math) : IDoMath
{
    public int Sum(int a, int b)
    {
        if (a < 0 || b < 0) throw new ArgumentException("no negatives, pls");
        return math.Sum(a, b);
    }

    public int Diff(int a, int b)
    {
        if (a < 0 || b < 0) throw new ArgumentException("no negatives, pls");
        return math.Diff(a, b);
    }
}