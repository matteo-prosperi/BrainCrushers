namespace BrainCrushersTests;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Tester
{
    public static Action? TimeoutCheckAction { get; set; }

    public async IAsyncEnumerable<string> TestAsync()
    {
        for (int n = 0; n <= 128; n = n == 0 ? 1 : 2 * n)
        {
            yield return $"{n} =>";
            await Task.Yield();

            long result;
            try
            {
                BrainCrushers.Exercise exercise = new();
                result = exercise.Fibonacci(n);
            }
            catch (Exception e)
            {
                throw new ApplicationException("Error while running test", e);
            }

            long expected = 0;
            if (n == 0)
            {
                expected = 0;
            }
            else if (n == 1)
            { 
                expected = 1;
            }
            else
            {
                long prev = 0;
                long curr = 1;
                for (int i = 2; i <= n; i++)
                {
                    long tmp = prev + curr;
                    prev = curr;
                    curr = tmp;
                }
                expected = curr;
            }

            bool success = result == expected;
            yield return $" {result} {(success ? '✓' : '✗')}{Environment.NewLine}";
            if (!success)
            {
                throw new ApplicationException("Invalid test result");
            }
        }
    }
}