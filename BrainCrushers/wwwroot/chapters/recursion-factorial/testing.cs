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
        for (int n = 0; n < 8; n++)
        {
            yield return $"{n} =>";
            await Task.Yield();

            int result;
            try
            {
                BrainCrushers.Exercise exercise = new();
                result = exercise.Factorial(n);
            }
            catch (Exception e)
            {
                throw new ApplicationException("Error while running test", e);
            }

            int expected = 1;
            for (int i = 2; i <= n; i++)
            {
                expected *= i;
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