namespace FizzBuzz;

public class MessySolution : ISolution
{
    public IEnumerable<string> FizzBuzz(int n)
    {
        var results = new List<string>();
        var stringResult = string.Empty;

        for (var i = 1; i <= n; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                stringResult = "FizzBuzz";
            }
            else if (i % 3 == 0)
            {
                stringResult = "Fizz";
            }
            else if (i % 5 == 0)
            {
                stringResult = "Buzz";
            }
            else
            {
                stringResult = i.ToString();
            }

            results.Add(stringResult);
        }

        return results;
    }
}